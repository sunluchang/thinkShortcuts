using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ThinkVantage
{
    public partial class ThinkSUN : Form
    {
        private string[] buttonName = new string[4];
        private int fst = 0;
        Random red = new Random();
        Random green = new Random();
        Random blue = new Random();

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
                        buttonName[lineNum - 1] = content;
                        content = line.ReadLine();
                    }
                    line.Close();
                    config.Close();
                }
                catch { ; }
                loadPic(4);
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

        private void loadPic(int c)
        {
            for (int i=0; i < c; i++)
            {
                string[] temp = buttonName[i].Split('\\');
                string name = temp[temp.Length-1];
                buttons[i].Text = getName(name.Split('.')[0]);
                buttons[i].Tag = name.Split('.')[0];
                buttons[i].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(red.Next(256))))), ((int)(((byte)(red.Next(50, 200))))), ((int)(((byte)(red.Next(230, 256))))));
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
            if (buttonName[0] == "" || !File.Exists(buttonName[0]))
            {
                if (fst == 0)
                    MessageBox.Show("无效的程序路径！\n");
                buttonName[0] = getNewApp(buttonName[0]);
                return;
            }
            Process.Start(buttonName[0]);
            quitAndSave();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (buttonName[1] == "" || !File.Exists(buttonName[1]))
            {
                if (fst == 0)
                    MessageBox.Show("无效的程序路径！\n");
                buttonName[1] = getNewApp(buttonName[1]);
                return;
            }
            Process.Start(buttonName[1]);
            quitAndSave();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (buttonName[2] == "" || !File.Exists(buttonName[2]))
            {
                if (fst == 0)
                    MessageBox.Show("无效的程序路径！\n");
                buttonName[2] = getNewApp(buttonName[2]);
                return;
            }
            Process.Start(buttonName[2]);
            quitAndSave();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (buttonName[3] == "" || !File.Exists(buttonName[3]))
            {
                if (fst == 0)
                    MessageBox.Show("无效的程序路径！\n");
                buttonName[3] = getNewApp(buttonName[3]);
                return;
            }
            Process.Start(buttonName[3]);
            quitAndSave();
        }

        private void 更改应用ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonName[0] = getNewApp(buttonName[0]);
            int[] a = new int[1];
            a[0] = 1;
            loadPic(1);
        }

        private void 更改应用ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            buttonName[1] = getNewApp(buttonName[1]);
            int[] a = new int[1];
            a[0] = 2;
            loadPic(2);
        }

        private void 更换应用ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonName[2] = getNewApp(buttonName[2]);
            int[] a = new int[1];
            a[0] = 3;
            loadPic(3);
        }

        private void 更换应用ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            buttonName[3] = getNewApp(buttonName[3]);
            int[] a = new int[1];
            a[0] = 4;
            loadPic(4);
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
                mySw.WriteLine(buttonName[i]);
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
