namespace ZumaBot
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.currentScreen = new System.Windows.Forms.PictureBox();
            this.btnCapture = new System.Windows.Forms.Button();
            this.timerCapture = new System.Windows.Forms.Timer(this.components);
            this.textLevelId = new System.Windows.Forms.TextBox();
            this.textLifeCount = new System.Windows.Forms.TextBox();
            this.btnReplay = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnBrowseDir = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            ((System.ComponentModel.ISupportInitialize)(this.currentScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // currentScreen
            // 
            this.currentScreen.Location = new System.Drawing.Point(0, 28);
            this.currentScreen.Name = "currentScreen";
            this.currentScreen.Size = new System.Drawing.Size(640, 480);
            this.currentScreen.TabIndex = 0;
            this.currentScreen.TabStop = false;
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(15, 552);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnCapture.Size = new System.Drawing.Size(70, 29);
            this.btnCapture.TabIndex = 1;
            this.btnCapture.Text = "Start";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // textLevelId
            // 
            this.textLevelId.Location = new System.Drawing.Point(47, 2);
            this.textLevelId.Name = "textLevelId";
            this.textLevelId.ReadOnly = true;
            this.textLevelId.Size = new System.Drawing.Size(92, 20);
            this.textLevelId.TabIndex = 7;
            // 
            // textLifeCount
            // 
            this.textLifeCount.Location = new System.Drawing.Point(175, 2);
            this.textLifeCount.Name = "textLifeCount";
            this.textLifeCount.ReadOnly = true;
            this.textLifeCount.Size = new System.Drawing.Size(92, 20);
            this.textLifeCount.TabIndex = 7;
            // 
            // btnReplay
            // 
            this.btnReplay.Location = new System.Drawing.Point(201, 552);
            this.btnReplay.Name = "btnReplay";
            this.btnReplay.Size = new System.Drawing.Size(70, 29);
            this.btnReplay.TabIndex = 11;
            this.btnReplay.Text = "Replay";
            this.btnReplay.UseVisualStyleBackColor = true;
            this.btnReplay.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Level";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(149, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Life";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(356, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(257, 20);
            this.textBox1.TabIndex = 15;
            // 
            // btnBrowseDir
            // 
            this.btnBrowseDir.Location = new System.Drawing.Point(613, 2);
            this.btnBrowseDir.Name = "btnBrowseDir";
            this.btnBrowseDir.Size = new System.Drawing.Size(24, 20);
            this.btnBrowseDir.TabIndex = 16;
            this.btnBrowseDir.Text = "...";
            this.btnBrowseDir.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(303, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "ZumaDir";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(112, 559);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(70, 17);
            this.checkBox1.TabIndex = 18;
            this.checkBox1.Text = "recording";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(0, 511);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(640, 17);
            this.hScrollBar1.TabIndex = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 591);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBrowseDir);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textLifeCount);
            this.Controls.Add(this.textLevelId);
            this.Controls.Add(this.btnReplay);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.currentScreen);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.currentScreen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox currentScreen;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.Timer timerCapture;
        private System.Windows.Forms.TextBox textLevelId;
        private System.Windows.Forms.TextBox textLifeCount;
        private System.Windows.Forms.Button btnReplay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnBrowseDir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.HScrollBar hScrollBar1;
    }
}

