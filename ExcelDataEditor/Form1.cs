using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace ExcelDataEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            groupBox1.AllowDrop = true;
            groupBox2.AllowDrop = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExcelEditor.CreateFile(nameNew.Text, pathNew.Text);
        }

        private void groupBox1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                DirectoryInfo d;
                d = new DirectoryInfo(((string[])e.Data.GetData(DataFormats.FileDrop))[0]);
                pathNew.Text = d.FullName;
            }
        }

        private void groupBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
        private void groupBox2_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                DirectoryInfo d;
                d = new DirectoryInfo(((string[])e.Data.GetData(DataFormats.FileDrop))[0]);
                pathEdit.Text = d.FullName;
            }
        }

        private void groupBox2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExcelEditor.EditAreaFile(pathEdit.Text);
        }
    }
}
