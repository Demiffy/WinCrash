namespace WinCrash
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            maintextLabel = new Label();
            faceLabel = new Label();
            qrcode = new PictureBox();
            percentageLabel = new Label();
            infoLabel = new Label();
            infoText = new Label();
            stopcodeLabel = new Label();
            percentTimer = new System.Windows.Forms.Timer(components);
            winLogo = new PictureBox();
            loadingAnimPicturebox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)qrcode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)winLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)loadingAnimPicturebox).BeginInit();
            SuspendLayout();
            // 
            // maintextLabel
            // 
            maintextLabel.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 238);
            maintextLabel.ForeColor = Color.White;
            maintextLabel.Location = new Point(218, 297);
            maintextLabel.Name = "maintextLabel";
            maintextLabel.Size = new Size(821, 154);
            maintextLabel.TabIndex = 0;
            maintextLabel.Text = "Your PC ran into a problem and needs to restart. We're just collecting some error info, and then we'll restart for you.";
            // 
            // faceLabel
            // 
            faceLabel.Font = new Font("Segoe UI", 120F);
            faceLabel.ForeColor = Color.White;
            faceLabel.Location = new Point(181, 65);
            faceLabel.Name = "faceLabel";
            faceLabel.Size = new Size(196, 218);
            faceLabel.TabIndex = 1;
            faceLabel.Text = ":(";
            // 
            // qrcode
            // 
            qrcode.BackgroundImage = (Image)resources.GetObject("qrcode.BackgroundImage");
            qrcode.BackgroundImageLayout = ImageLayout.Zoom;
            qrcode.Location = new Point(218, 542);
            qrcode.Name = "qrcode";
            qrcode.Size = new Size(126, 125);
            qrcode.TabIndex = 2;
            qrcode.TabStop = false;
            // 
            // percentageLabel
            // 
            percentageLabel.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 238);
            percentageLabel.ForeColor = Color.White;
            percentageLabel.Location = new Point(218, 463);
            percentageLabel.Name = "percentageLabel";
            percentageLabel.Size = new Size(335, 51);
            percentageLabel.TabIndex = 3;
            percentageLabel.Text = "0% complete";
            // 
            // infoLabel
            // 
            infoLabel.Font = new Font("Segoe UI", 12F);
            infoLabel.ForeColor = Color.White;
            infoLabel.Location = new Point(362, 542);
            infoLabel.Name = "infoLabel";
            infoLabel.Size = new Size(823, 29);
            infoLabel.TabIndex = 4;
            infoLabel.Text = "For more information about this issue and possible fixes, visit https://www.windows.com/stopcode";
            // 
            // infoText
            // 
            infoText.Font = new Font("Segoe UI", 11F);
            infoText.ForeColor = Color.White;
            infoText.Location = new Point(362, 589);
            infoText.Name = "infoText";
            infoText.Size = new Size(384, 29);
            infoText.TabIndex = 5;
            infoText.Text = "If you call a support person, give them this info:";
            // 
            // stopcodeLabel
            // 
            stopcodeLabel.Font = new Font("Segoe UI", 11F);
            stopcodeLabel.ForeColor = Color.White;
            stopcodeLabel.Location = new Point(362, 618);
            stopcodeLabel.Name = "stopcodeLabel";
            stopcodeLabel.Size = new Size(335, 29);
            stopcodeLabel.TabIndex = 6;
            stopcodeLabel.Text = "Stop code: 0x00000000";
            // 
            // percentTimer
            // 
            percentTimer.Enabled = true;
            percentTimer.Interval = 1000;
            percentTimer.Tick += percentTimer_Tick;
            // 
            // winLogo
            // 
            winLogo.BackgroundImage = (Image)resources.GetObject("winLogo.BackgroundImage");
            winLogo.BackgroundImageLayout = ImageLayout.Zoom;
            winLogo.Location = new Point(867, 297);
            winLogo.Name = "winLogo";
            winLogo.Size = new Size(200, 208);
            winLogo.TabIndex = 7;
            winLogo.TabStop = false;
            winLogo.Visible = false;
            // 
            // loadingAnimPicturebox
            // 
            loadingAnimPicturebox.BackColor = Color.Black;
            loadingAnimPicturebox.BackgroundImageLayout = ImageLayout.Zoom;
            loadingAnimPicturebox.Image = Properties.Resources._3013_ezgif_com_speed;
            loadingAnimPicturebox.Location = new Point(934, 683);
            loadingAnimPicturebox.Name = "loadingAnimPicturebox";
            loadingAnimPicturebox.Size = new Size(68, 76);
            loadingAnimPicturebox.TabIndex = 8;
            loadingAnimPicturebox.TabStop = false;
            loadingAnimPicturebox.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 120, 215);
            ClientSize = new Size(1213, 758);
            Controls.Add(loadingAnimPicturebox);
            Controls.Add(winLogo);
            Controls.Add(stopcodeLabel);
            Controls.Add(infoText);
            Controls.Add(infoLabel);
            Controls.Add(percentageLabel);
            Controls.Add(qrcode);
            Controls.Add(faceLabel);
            Controls.Add(maintextLabel);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "BSOD";
            TopMost = true;
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)qrcode).EndInit();
            ((System.ComponentModel.ISupportInitialize)winLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)loadingAnimPicturebox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label maintextLabel;
        private Label faceLabel;
        private PictureBox qrcode;
        private Label percentageLabel;
        private Label infoLabel;
        private Label infoText;
        private Label stopcodeLabel;
        private System.Windows.Forms.Timer percentTimer;
        private PictureBox winLogo;
        private PictureBox loadingAnimPicturebox;
    }
}
