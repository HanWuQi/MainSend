using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MailSend
{
    public partial class Form1 : Form
    {
        public static List<string> pathList = new List<string>();//定义list变量，存放获取到的路径
        public static List<string> infoList = new List<string>();
        public Form1()
        {
            InitializeComponent();
            label2.Text = "共0个";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "请选择文件夹路径";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = fbd.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            infoList.Clear();
            pathList.Clear();
            getPath(textBox1.Text);
            pathList.ForEach(x => {
                Read(x);
            });
            label2.Text = "共" + infoList.Count() + "个";
            var str = "";
            infoList.ForEach(x => str += (x+"\r\n"));
            richTextBox1.Text = str;
        }


        /// <summary>
        /// 遍历所有路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static void getPath(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] fil = dir.GetFiles();
            DirectoryInfo[] dii = dir.GetDirectories();
            foreach (FileInfo f in fil)
            {
                pathList.Add(f.FullName);//添加文件的路径到列表
            }
            //获取子文件夹内的文件列表，递归遍历
            foreach (DirectoryInfo d in dii)
            {
                getPath(d.FullName);
                //list.Add(d.FullName);//添加文件夹的路径到列表
            }
        }

        /// <summary>
        /// 读文件
        /// </summary>
        /// <param name="path"></param>
        public static void Read(string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.Default);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                infoList.Add(line.ToString().Trim() + "@qq.com");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
