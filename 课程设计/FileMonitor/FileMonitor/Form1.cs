using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FileMonitor
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            Control.CheckForIllegalCrossThreadCalls = false;   
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i;
            string[] filen;
            string filea;
            textBox1.Clear();
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.ShowDialog();
            textBox1.Text = folderBrowserDialog1.SelectedPath;
            if (folderBrowserDialog1.SelectedPath == "") return;
            if (!Directory.Exists(folderBrowserDialog1.SelectedPath))
                MessageBox.Show(folderBrowserDialog1.SelectedPath + "文件夹不存在", "信息提示", MessageBoxButtons.OK);
            else
            {
                filen = Directory.GetFiles(folderBrowserDialog1.SelectedPath);
                
                Console.WriteLine("ni"+filen);
                

            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string filea = textBox1.Text;
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = @filea;
            textBox2.AppendText("开始监视\n");


            /*监视LastAcceSS和LastWrite时间的更改以及文件或目录的重命名*/
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite |
                   NotifyFilters.FileName | NotifyFilters.DirectoryName;
            //只监视文本文件
            //watcher.Filter = "*.txt";
            //添加事件句柄
            //当由FileSystemWatcher所指定的路径中的文件或目录的
            //大小、系统属性、最后写时间、最后访问时间或安全权限
            //发生更改时，更改事件就会发生
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            //由FileSystemWatcher所指定的路径中文件或目录被创建时，创建事件就会发生
            watcher.Created += new FileSystemEventHandler(OnChanged);
            //当由FileSystemWatcher所指定的路径中文件或目录被删除时，删除事件就会发生
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            //当由FileSystemWatcher所指定的路径中文件或目录被重命名时，重命名事件就会发生
            watcher.Renamed += new RenamedEventHandler(OnRenamed);
            //开始监视
            watcher.EnableRaisingEvents = true;
            //等待用户退出程序
            
        }



        //定义事件处理程序
        public  void OnCreated(object sender, FileSystemEventArgs e)
        {
            textBox2.AppendText("file:" + e.FullPath + "    " + e.ChangeType + "\n");
        }

        //定义事件处理程序
        public void OnChanged(object sender, FileSystemEventArgs e)
        {

            textBox2.AppendText("file:" + e.FullPath + "    " + e.ChangeType + "\n");
        }
        public  void OnRenamed(object sender, RenamedEventArgs e)
        {
            textBox2.AppendText("Fi]e:"+e.OldFullPath+" renamed to"+ e.FullPath + "\n");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
