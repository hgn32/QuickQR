using CSClipboardListener;
using QRCoder;

namespace WinFormsApp1
{
    public partial class FormQR : Form
    {
        private readonly ClipboardListener clipListener;
        QRCodeGenerator qrGenerator = new QRCodeGenerator();
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
            timerHide.Interval = 1000 * 5;
            timerHide.Start();
        }
        private void FormQR_FormClosing(object sender, FormClosingEventArgs e)
        {
            clipListener.DestroyHandle();
        }

        private void timerHide_Tick(object sender, EventArgs e)
        {
            this.Hide();
            timerHide.Stop();
        }

    }
}
