
using System.Diagnostics;
using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSClipboardListener
{
    public class ClipboardEventArgs : EventArgs
    {
        private string text;
        public string Text { get { return this.text; } }
        public ClipboardEventArgs(string str) => this.text = str;
    }

    public delegate void cbEventHandler(object sender, ClipboardEventArgs ev);

    public class ClipboardListener : NativeWindow
    {
        private Form Parent;                            //イベント通知先
        private const int WM_CLIPBOARDUPDATE = 0x031D;  //クリップボードの内容変更時に送信される
        public event cbEventHandler ClipboardHandler;   //

        //Win32API
        private static class NativeMethods
        {
            [DllImport("user32.dll", SetLastError = true)]
            internal extern static void AddClipboardFormatListener(IntPtr hWnd);
            [DllImport("user32.dll", SetLastError = true)]
            internal extern static void RemoveClipboardFormatListener(IntPtr hWnd);
        }

#nullable disable warnings
        public ClipboardListener(Form f)
        {
            f.HandleCreated += new EventHandler(OnHandleCreated);
            f.HandleDestroyed += new EventHandler(OnHandleDestroyed);
            this.Parent = f;
        }
#nullable restore warnings

        internal void OnHandleCreated(object sender, EventArgs e)
        {
            AssignHandle(((Form)sender).Handle);
            NativeMethods.AddClipboardFormatListener(this.Handle);
        }
        internal void OnHandleDestroyed(object sender, EventArgs e)
        {
            NativeMethods.RemoveClipboardFormatListener(this.Handle);
            this.ReleaseHandle();
        }

        protected override void WndProc(ref Message msg)
        {
            if ((msg.Msg == WM_CLIPBOARDUPDATE) && Clipboard.ContainsText())
            {
                //if (ClipboardHandler != null) 
                //{   
                //    ClipboardHandler(this, new ClipboardEventArgs(Clipboard.GetText()));
                //}
                 string clip= Clipboard.GetText();
                //clip=clip.Replace("\t","[tab]");
                ClipboardHandler?.Invoke(this, new ClipboardEventArgs(clip));
            }
            base.WndProc(ref msg);
        }
    }
}
