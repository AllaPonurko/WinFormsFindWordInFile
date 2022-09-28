using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsFindWordInFile.Tasks
{
    public class MyTask
    {
        public Action FindWord => new Action(MethodFindWord);
        public void MethodFindWord()
        {

        }
    }
}
