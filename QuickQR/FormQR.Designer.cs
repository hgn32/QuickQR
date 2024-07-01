using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickQR
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
            notifyIconMain = new NotifyIcon(components);
            contextMenuStripMain = new ContextMenuStrip(components);
            toolStripMenuItemConfig = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripMenuItemExit = new ToolStripMenuItem();
            tableLayoutPanel1 = new TableLayoutPanel();
            labelCountDown = new Label();
            textBoxClipText = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxQR).BeginInit();
            contextMenuStripMain.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBoxQR
            // 
            tableLayoutPanel1.SetColumnSpan(pictureBoxQR, 2);
            pictureBoxQR.Dock = DockStyle.Fill;
            pictureBoxQR.Location = new Point(3, 3);
            pictureBoxQR.Name = "pictureBoxQR";
            pictureBoxQR.Size = new Size(294, 294);
            pictureBoxQR.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxQR.TabIndex = 0;
            pictureBoxQR.TabStop = false;
            // 
            // timerHide
            // 
            timerHide.Interval = 10000;
            timerHide.Tick += timerHide_Tick;
            // 
            // notifyIconMain
            // 
            notifyIconMain.BalloonTipIcon = ToolTipIcon.Info;
            notifyIconMain.BalloonTipText = "QRにしたいテキストをコピーしてください";
            notifyIconMain.BalloonTipTitle = "QuickQR";
            notifyIconMain.ContextMenuStrip = contextMenuStripMain;
            notifyIconMain.Icon = (Icon)resources.GetObject("notifyIconMain.Icon");
            notifyIconMain.Text = "QuickQR";
            notifyIconMain.Visible = true;
            // 
            // contextMenuStripMain
            // 
            contextMenuStripMain.Items.AddRange(new ToolStripItem[] { toolStripMenuItemConfig, toolStripSeparator1, toolStripMenuItemExit });
            contextMenuStripMain.Name = "contextMenuStripMain";
            contextMenuStripMain.Size = new Size(99, 54);
            contextMenuStripMain.Text = "QuickQR";
            // 
            // toolStripMenuItemConfig
            // 
            toolStripMenuItemConfig.Name = "toolStripMenuItemConfig";
            toolStripMenuItemConfig.Size = new Size(98, 22);
            toolStripMenuItemConfig.Text = "設定";
            toolStripMenuItemConfig.Click += toolStripMenuItemConfig_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(95, 6);
            // 
            // toolStripMenuItemExit
            // 
            toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            toolStripMenuItemExit.Size = new Size(98, 22);
            toolStripMenuItemExit.Text = "終了";
            toolStripMenuItemExit.Click += toolStripMenuItemExit_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.Controls.Add(pictureBoxQR, 0, 0);
            tableLayoutPanel1.Controls.Add(labelCountDown, 1, 1);
            tableLayoutPanel1.Controls.Add(textBoxClipText, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.Size = new Size(300, 360);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // labelCountDown
            // 
            labelCountDown.AutoSize = true;
            labelCountDown.Dock = DockStyle.Fill;
            labelCountDown.Font = new Font("Yu Gothic UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            labelCountDown.Location = new Point(243, 300);
            labelCountDown.Name = "labelCountDown";
            labelCountDown.Size = new Size(54, 60);
            labelCountDown.TabIndex = 1;
            labelCountDown.Text = "60";
            labelCountDown.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxClipText
            // 
            textBoxClipText.Dock = DockStyle.Fill;
            textBoxClipText.Location = new Point(3, 303);
            textBoxClipText.Multiline = true;
            textBoxClipText.Name = "textBoxClipText";
            textBoxClipText.ReadOnly = true;
            textBoxClipText.Size = new Size(234, 54);
            textBoxClipText.TabIndex = 2;
            // 
            // FormQR
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(300, 360);
            ControlBox = false;
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormQR";
            ShowInTaskbar = false;
            Text = "QuickQR";
            TopMost = true;
            FormClosing += FormQR_FormClosing;
            Shown += FormQR_Shown;
            ((System.ComponentModel.ISupportInitialize)pictureBoxQR).EndInit();
            contextMenuStripMain.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBoxQR;
        private System.Windows.Forms.Timer timerHide;
        private NotifyIcon notifyIconMain;
        private TableLayoutPanel tableLayoutPanel1;
        private ContextMenuStrip contextMenuStripMain;
        private ToolStripMenuItem toolStripMenuItemConfig;
        private ToolStripMenuItem toolStripMenuItemExit;
        private Label labelCountDown;
        private TextBox textBoxClipText;
        private ToolStripSeparator toolStripSeparator1;
    }
}
