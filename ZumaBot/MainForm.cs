using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace ZumaBot
{
    public class RealGame : Zuma.IZumaGame
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetDesktopWindow();

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }


        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int X;
            public int Y;
        }

        [DllImport("user32.dll")]
        private static extern bool ClientToScreen(IntPtr hWnd, ref POINT pt);

        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowRect(IntPtr hWnd, ref RECT rect);

        [DllImport("user32.dll")]
        private static extern IntPtr GetClientRect(IntPtr hWnd, ref RECT rect);

        [DllImport("user32.dll")]
        private static extern bool IsWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool SetForgroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string className, string windowName);

        [DllImport("user32.dll")]
        private static extern bool PrintWindow(IntPtr hWnd, IntPtr hdcBlt, int nFlags);

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("user32.dll")]
        private static extern void mouse_event(UInt32 dwFlags, UInt32 dx, UInt32 dy, UInt32 cButtons, IntPtr extraInfo);
        private const UInt32 MOUSEEVENTF_LEFTDOWN = 0x02;
        private const UInt32 MOUSEEVENTF_LEFTUP = 0x04;
        private const UInt32 MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const UInt32 MOUSEEVENTF_RIGHTUP = 0x010;
        private const UInt32 MOUSEEVENTF_MOVE = 0x0001;

        private static void DoMouseLClick()
        {
            //perform click            
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, IntPtr.Zero);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, IntPtr.Zero);
        }

        private static void DoMouseRClick()
        {
            //perform click            
            mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, IntPtr.Zero);
            mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, IntPtr.Zero);
        }


        private IntPtr _hZumaWnd;

        private RealGame(IntPtr hwnd)
        {
            _hZumaWnd = hwnd;
        }

        public static RealGame Create()
        {

            IntPtr hZumaWnd = FindWindow("MainWindow", "Zuma Deluxe 1.0.0.1");

            if (!IsWindow(hZumaWnd))
            {
                System.Diagnostics.Debug.WriteLine("Zuma window not found!");
                return null;
            }

            return new RealGame(hZumaWnd);
        }
        
        public string GameDir
        {
            get { return "D:\\Games\\Zuma";  }
        }

        public event Zuma.ScreenChangedEventHandler ScreenChanged;

        public void Click(Point XY)
        {
            POINT pt = new POINT() { X = XY.X, Y = XY.Y };
            ClientToScreen(_hZumaWnd, ref pt);
            Cursor.Position = new Point(pt.X, pt.Y);
            DoMouseLClick();
        }

        public void ShootBall(Point XY)
        {
            Click(XY);
            Thread.Sleep(500);
        }

        public void SwapBall()
        {
            DoMouseRClick();
            Thread.Sleep(200);
        }

        public void Tick()
        {
            IntPtr hwnd = GetForegroundWindow();

            if (_hZumaWnd != GetForegroundWindow())
            {
                System.Diagnostics.Debug.WriteLine("Zuma window not active!");
                return;
            }

            RECT r = new RECT();
            GetClientRect(_hZumaWnd, ref r);

            if (r.Right != 640 || r.Bottom != 480)
            {
                System.Diagnostics.Debug.WriteLine("Zuma window size incorrect:{0}x{1}", r.Right, r.Bottom);
                return;
            }

            GetWindowRect(_hZumaWnd, ref r);

            Bitmap screen = new Bitmap(640, 480);
            if (r.Right == 0 && r.Bottom == 0)
            {
                // full screen
                using (var gs = Graphics.FromImage(screen))
                {
                    gs.CopyFromScreen(new Point(0, 0), new Point(0, 0), screen.Size);
                }
            }
            else
            {
                using (var graphics = Graphics.FromImage(screen))
                {
                    IntPtr hdc = graphics.GetHdc();
                    PrintWindow(_hZumaWnd, hdc, 1);
                    graphics.ReleaseHdc(hdc);
                }
            }

            ScreenChanged(screen);
        }
    }

    public class RecordedGame : Zuma.IZumaGame
    {
        string[] _frames;

        private void LoadScreen()
        {
            ScreenChanged(new Bitmap(_frames[CurrentFrame]));
        }

        private RecordedGame(string[] frames)
        {
            _frames = frames;
        }

        public int TotalFrames
        {
            get
            {
                return _frames.Length;
            }
        }

        public int CurrentFrame
        {
            get;
            private set;
        }

        public string GameDir
        {
            get { return "D:\\Games\\Zuma"; }
        }

        public event Zuma.ScreenChangedEventHandler ScreenChanged;

        public void Click(Point XY)
        {

        }

        public void ShootBall(Point XY)
        {
        }

        public void SwapBall()
        {
        }

        public void Forward()
        {
            if (CurrentFrame < TotalFrames - 1)
            {
                CurrentFrame++;
                LoadScreen();
            }
        }

        public void Backward()
        {
            if (CurrentFrame > 0)
            {
                CurrentFrame--;
                LoadScreen();
            }
        }

        public void Seek(int frame)
        {
            if (frame >= TotalFrames)
            {
                frame = TotalFrames - 1;
            }
            else if (frame < 0)
            {
                frame = 0;
            }

            CurrentFrame = frame;
            LoadScreen();
        }

        public static RecordedGame Create()
        {
            var frames = Directory.GetFiles("screenshots", "SCR_?????.jpg").OrderBy(x => x).ToArray();
            if (frames.Length < 1)
            {
                return null;
            }

            return new RecordedGame(frames);
        }
    }

    public class ScreenRecorder
    {
        private int frame;

        public ScreenRecorder()
        {
            var outDir = "screenshots";

            if (Directory.Exists(outDir))
            {
                foreach(var file in Directory.GetFiles(outDir, "SCR_*.jpg"))
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            else
            {
                Directory.CreateDirectory(outDir);
            }

            frame = 0;
        }

        public void Record(Bitmap screen)
        {
            var fname = Path.Combine("screenshots", string.Format("SCR_{0:00000}.jpg", frame ++));
            screen.Save(fname);
        }
    }

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            var game = RealGame.Create();
            if (game == null)
            {
                MessageBox.Show("Zuma game window not found!");
                return;
            }

            if (checkBox1.Checked)
            {
                var recorder = new ScreenRecorder();
                game.ScreenChanged += recorder.Record;
            }

            var player = new Zuma.Player(game);
            timerCapture.Tick += (o, i) => {
                game.Tick();
                textLevelId.Text = player.LevelId;
                textLifeCount.Text = player.LifeCount;
                currentScreen.Image = player.State;
            };

            timerCapture.Interval = 1000;
            timerCapture.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timerCapture.Stop();

            var game = RecordedGame.Create();
            if (game == null)
            {
                MessageBox.Show("Zuma game window not found!");
                return;
            }

            hScrollBar1.Minimum = 0;
            hScrollBar1.Maximum = game.TotalFrames;

            var player = new Zuma.Player(game);

            hScrollBar1.ValueChanged += (o, i) =>
            {
                game.Seek(hScrollBar1.Value);
                textLevelId.Text = player.LevelId;
                textLifeCount.Text = player.LifeCount;
                currentScreen.Image = player.State;
            };
        }
    }
}
