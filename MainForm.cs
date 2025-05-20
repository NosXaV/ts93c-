using System;
using System.Windows.Forms;

namespace PhoenixTS93
{
    public class MainForm : Form
    {
        public MainForm()
        {
            Text = "TS93 Bot - by ChatGPT & XaV";
            Width = 400;
            Height = 200;

            Label info = new Label();
            info.Text = "Automatyczne przechodzenie TS93";
            info.Dock = DockStyle.Top;
            info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Controls.Add(info);
        }
    }
}