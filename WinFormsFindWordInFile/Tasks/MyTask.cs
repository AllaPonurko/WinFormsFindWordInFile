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
        static List<string> GetFilesInDir()
        {
            List<string> files=new List<string>();
            foreach(var item in drives)
            {
                files.AddRange(Directory.GetFiles(item.Name));
            }
            return files;
        }
        
        public List<string> KeyWord(string str)
        {
            List<string> vs = new List<string>();
            foreach (var item in GetFilesInDir())
            {
                StreamReader file = new StreamReader(item);
                if(file.ReadLine().Contains(str))
                {
                    vs.Add(item);
                }
            }
            return vs;
        }
        
    }
}
