namespace WinFormsApp1
{
    partial class FormQR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormQR));
            pictureBoxQR = new PictureBox();
            timerHide = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBoxQR).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxQR
            // 
            pictureBoxQR.Dock = DockStyle.Fill;
            pictureBoxQR.Location = new Point(0, 0);
            pictureBoxQR.Name = "pictureBoxQR";
            pictureBoxQR.Size = new Size(300, 300);
            pictureBoxQR.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxQR.TabIndex = 0;
            pictureBoxQR.TabStop = false;
            // 
            // timerHide
            // 
            timerHide.Interval = 10000;
            timerHide.Tick += timerHide_Tick;
            // 
            // FormQR
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(300, 300);
            ControlBox = false;
            Controls.Add(pictureBoxQR);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormQR";
            ShowInTaskbar = false;
            Text = "QuickQR";
            TopMost = true;
            FormClosing += FormQR_FormClosing;
            Shown += FormQR_Shown;
            ((System.ComponentModel.ISupportInitialize)pictureBoxQR).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBoxQR;
        private System.Windows.Forms.Timer timerHide;
    }
}
