using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ThinkVantage
{
    public partial class ThinkSUN : Form
    {
        public ThinkSUN()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("C:/Program Files/Adobe/Adobe Photoshop CC 2015/Photoshop.exe");
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\Program Files (x86)\\Tencent\\QQ\\Bin/QQ.exe");
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("C:/Program Files (x86)/Microsoft Visual Studio 14.0/Common7/IDE/devenv.exe");
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process.Start("F:/Games/counter-strike source/Counter-Strike.exe");
            Application.Exit();
        }
    }
}
