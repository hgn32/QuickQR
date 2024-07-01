using CSClipboardListener;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace QuickQR
{
    public partial class FormQR : Form
    {
        private readonly ClipboardListener clipListener;
        QRCodeGenerator qrGenerator = new QRCodeGenerator();

        int CountDown = 0;
        public FormQR()
        {
            clipListener = new ClipboardListener(this);
            clipListener.ClipboardHandler += this.OnClipBoardChanged;

            InitializeComponent();
        }

        private void FormQR_Shown(object sender, EventArgs e)
        {

            this.Hide();
        }

        private void OnClipBoardChanged(object sender, ClipboardEventArgs args)
        {
            textBoxClipText.Text = args.Text;
            QRCodeData qRCodeData = qrGenerator.CreateQrCode(args.Text, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qRCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            pictureBoxQR.Image = qrCodeImage;
            if (Screen.PrimaryScreen != null)
            {
                int left = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
                int top = Screen.PrimaryScreen.WorkingArea.Height - this.Height;
                this.DesktopBounds = new Rectangle(left, top, this.Width, this.Height);//右下に表示
                //DesktopBounds = new Rectangle(left, 0, this.Width, this.Height);//右上に表示
                //DesktopBounds = new Rectangle(0, 0, this.Width, this.Height);//左上に表示
                //DesktopBounds = new Rectangle(0, top, this.Width, this.Height);//左下に表示

            }
            this.Show();
            CountDown = 5;
            timerHide.Interval = 1000 ;
            timerHide.Start();
        }
        private void FormQR_FormClosing(object sender, FormClosingEventArgs e)
        {
            clipListener.DestroyHandle();
        }


        private void toolStripMenuItemConfig_Click(object sender, EventArgs e) {
            new FormConfig().ShowDialog();
        }
        private void toolStripMenuItemExit_Click(object sender, EventArgs e) {
            if (MessageBox.Show("終了してもいいですか？", "QuickQR", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void timerHide_Tick(object sender, EventArgs e)
        {
            if (CountDown <= 0)
            {
                textBoxClipText.Text = "";
                this.Hide();
                timerHide.Stop();
            }
            else
            {
                CountDown--;
                labelCountDown.Text = CountDown.ToString();
            }
        }

    }
}
