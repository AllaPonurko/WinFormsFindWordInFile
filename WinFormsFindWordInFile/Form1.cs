using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsFindWordInFile.Tasks;

namespace WinFormsFindWordInFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static public MyTask task = new MyTask();
        static Semaphore sem = new Semaphore(MyTask.drives.Length, 10);
        
        private void btnStart_Click(object sender, EventArgs e)
        {
            if(txtWord.Text.Length==0)
            {
                MessageBox.Show("Нет слова для поиска!");
            }
            else
            lstFiles.Items.AddRange((task.KeyWord(txtWord.Text)).ToArray());

        }
    }
}
