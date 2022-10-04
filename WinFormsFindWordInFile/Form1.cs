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
{ public struct Word
    {
        public static string word;
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        static public Word GetWord = new Word();
            private void btnStart_Click(object sender, EventArgs e)
        {
            if(txtWord.Text.Length==0)
            {
                MessageBox.Show("Нет слова для поиска!");
            }
            else
            {
                Word.word = txtWord.Text;
                _ = new MyTask();
                lstFiles.Items.AddRange(MyTask.KeyWord(txtWord.Text).ToArray());

            }

        }
    }
}
