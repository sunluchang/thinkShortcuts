using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;//引用DLL申明


namespace ThinkVantage
{
    public partial class ThinkSUN : Form
    {
        private string buttonone = "";
        private string buttontwo = "";
        private string buttonthree = "";
        private string buttonfour = "";
        private int fst = 0;
        Random red = new Random();
        Random green = new Random();
        Random blue = new Random();

        [StructLayout(LayoutKind.Sequential)]
        public struct MARGINS
        {
            public int Left;
            public int Right;
            public int Top;
            public int Bottom;
        }

        [DllImport("dwmapi.dll", PreserveSig = false)]
        static extern void DwmExtendFrameIntoClientArea(IntPtr hwnd, ref MARGINS
        margins);

        //DLL申明
        [DllImport("dwmapi.dll", PreserveSig = false)]
        static extern bool DwmIsCompositionEnabled();

        //直接添加代码
        protected override void OnLoad(EventArgs e)
        {
            if (DwmIsCompositionEnabled())
            {
                MARGINS margins = new MARGINS();
                margins.Right = margins.Left = margins.Top = margins.Bottom =
        this.Width + this.Height;
                DwmExtendFrameIntoClientArea(this.Handle, ref margins);
            }
            base.OnLoad(e);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            if (DwmIsCompositionEnabled())
            {
                e.Graphics.Clear(Color.Black);
            }
        }


        public ThinkSUN()
        {
            InitializeComponent();
            if (!File.Exists(@"./config.dat"))
            {
                fst = 1;
                FileStream newConfig = new FileStream("./config.dat", FileMode.Create);
                newConfig.Close();
            }
            else
            {
                FileStream config = null;
                StreamReader line = null;
                try
                {
                    config = new FileStream("config.dat", FileMode.Open, FileAccess.Read);
                    line = new StreamReader(config, Encoding.Default);
                    config.Seek(0, SeekOrigin.Begin);
                    int lineNum = 0;
                    string content = line.ReadLine();
                    while (content != null)
                    {
                        lineNum++;
                        if (lineNum == 1)
                            buttonone = content;
                        if (lineNum == 2)
                            buttontwo = content;
                        if (lineNum == 3)
                            buttonthree = content;
                        if (lineNum == 4)
                            buttonfour = content;
                        content = line.ReadLine();
                    }
                    line.Close();
                    config.Close();
                }
                catch { ; }
                int[] arr = new int[4];
                arr[0] = 1;
                arr[1] = 2;
                arr[2] = 3;
                arr[3] = 4;
                loadPic(arr, 4);
            }
        }

        private string getName(string name)
        {
            string[] namesOLD = new string[] {"QQ", "Photoshop", "AfterEffects", "Dreamweaver", "Counter-Strike", "devenv" };
            string[] namesNEW = new string[] {"QQ", "Ps", "Ae", "Dw", "CS", "Vs" };
            string ret = name;
            int flag = 0;
            int i = 0;
            for (i=0; i < namesOLD.Length; i++)
            {
                if (string.Compare(namesOLD[i], name) == 0)
                {
                    flag = 1;
                    break;
                }
            }
            if (flag == 1) { ret = namesNEW[i]; }
            return ret;
        }

        private void loadPic(int[] num, int c)
        {
            for (int i=0; i < c; i++)
            {
                switch (num[i])
                {
                    case 1:
                        string[] temp = buttonone.Split('\\');
                        string name = temp[temp.Length-1];
                        button1.Text = getName(name.Split('.')[0]);
                        button1.Tag = name.Split('.')[0];
                        button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(red.Next(256))))), ((int)(((byte)(red.Next(50, 200))))), ((int)(((byte)(red.Next(230, 256))))));
                        break;
                    case 2:
                        string[] temp2 = buttontwo.Split('\\');
                        string name2 = temp2[temp2.Length - 1];
                        button2.Text = getName(name2.Split('.')[0]);
                        button2.Tag = name2.Split('.')[0];
                        button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(red.Next(256))))), ((int)(((byte)(red.Next(50, 200))))), ((int)(((byte)(red.Next(230, 256))))));
                        break;
                    case 3:
                        string[] temp3 = buttonthree.Split('\\');
                        string name3 = temp3[temp3.Length - 1];
                        button3.Text = getName(name3.Split('.')[0]);
                        button3.Tag = name3.Split('.')[0];
                        button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(red.Next(256))))), ((int)(((byte)(red.Next(50, 200))))), ((int)(((byte)(red.Next(230, 256))))));
                        break;
                    case 4:
                        string[] temp4 = buttonfour.Split('\\');
                        string name4 = temp4[temp4.Length - 1];
                        button4.Text = getName(name4.Split('.')[0]);
                        button4.Tag = name4.Split('.')[0];
                        button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(red.Next(256))))), ((int)(((byte)(red.Next(50, 200))))), ((int)(((byte)(red.Next(230, 256))))));
                        break;
                }
            }
        }

        private string getNewApp(string old)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "应用程序|*.exe*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog.FileName;
            }
            return old;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (buttonone == "" || !File.Exists(buttonone))
            {
                if (fst == 0)
                    MessageBox.Show("无效的程序路径！\n");
                buttonone = getNewApp(buttonone);
                return;
            }
            Process.Start(buttonone);
            quitAndSave();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (buttontwo == "" || !File.Exists(buttontwo))
            {
                if (fst == 0)
                    MessageBox.Show("无效的程序路径！\n");
                buttontwo = getNewApp(buttontwo);
                return;
            }
            Process.Start(buttontwo);
            quitAndSave();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (buttonthree == "" || !File.Exists(buttonthree))
            {
                if (fst == 0)
                    MessageBox.Show("无效的程序路径！\n");
                buttonthree = getNewApp(buttonthree);
                return;
            }
            Process.Start(buttonthree);
            quitAndSave();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (buttonfour == "" || !File.Exists(buttonfour))
            {
                if (fst == 0)
                    MessageBox.Show("无效的程序路径！\n");
                buttonfour = getNewApp(buttonfour);
                return;
            }
            Process.Start(buttonfour);
            quitAndSave();
        }

        private void 更改应用ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonone = getNewApp(buttonone);
            int[] a = new int[1];
            a[0] = 1;
            loadPic(a, 1);
        }

        private void 更改应用ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            buttontwo = getNewApp(buttontwo);
            int[] a = new int[1];
            a[0] = 2;
            loadPic(a, 1);
        }

        private void 更换应用ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonthree = getNewApp(buttonthree);
            int[] a = new int[1];
            a[0] = 3;
            loadPic(a, 1);
        }

        private void 更换应用ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            buttonfour = getNewApp(buttonfour);
            int[] a = new int[1];
            a[0] = 4;
            loadPic(a, 1);
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            quitAndSave();
        }

        private void 退出ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            quitAndSave();
        }

        private void 退出ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            quitAndSave();
        }

        private void 退出ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            quitAndSave();
        }
        private void quitAndSave()
        {
            FileStream myFs = new FileStream("config.dat", FileMode.Open, FileAccess.Write);
            StreamWriter mySw = new StreamWriter(myFs);
            for (int i = 0; i < 4; i++)
            {
                switch (i)
                {
                    case 0:
                        mySw.WriteLine(buttonone);
                        break;
                    case 1:
                        mySw.WriteLine(buttontwo);
                        break;
                    case 2:
                        mySw.WriteLine(buttonthree);
                        break;
                    case 3:
                        mySw.WriteLine(buttonfour);
                        break;
                }
            }   
            mySw.Close();
            myFs.Close();
            Application.Exit();
        }

        private void ThinkSUN_Click(object sender, EventArgs e)
        {
            quitAndSave();
        }
    }
}
