using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace WinFormsFindWordInFile.Tasks
{
    public class MyTask
    {
        public static DriveInfo[] drives = DriveInfo.GetDrives();
        //int count = drives.Length;
        //static List<DirectoryInfo> GetDirectoryInfo()
        //{ 
        //    List<DirectoryInfo> ts = new List<DirectoryInfo>();
        //    foreach (var item in drives)
        //    {
        //        ts.Add(new DirectoryInfo(item.Name));
        //    }
        //    return ts;
        //}
        public Action<int> OnCountChanged;
        int count = 0;
        public void KeyWord(/*string str*/)
        {  
            List<string> vs = new List<string>();
            IEnumerable<string> allfiles ;
            foreach (var item in drives)
            {
                allfiles = Directory.EnumerateFiles(item.Name);
                foreach(var s in allfiles)
                {StreamReader file = new StreamReader(s);
                    if (file.ReadLine().Contains(str))
                    {
                        vs.Add(s);
                        count++;
                    }
                }
            }    
        }
        
    }
}
