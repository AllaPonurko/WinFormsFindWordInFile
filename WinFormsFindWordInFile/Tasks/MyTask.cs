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
        public static Action<int, List<string>> OnCountChanged;
       static int count = 0;
        static Semaphore sem = new Semaphore(drives.Length, 10);
        Thread MyThread;
        public MyTask()
        {
            MyThread = new Thread(FindFile);
            MyThread.Start();
            Thread.Sleep(1000);
        }
        public void FindFile()
        {
            KeyWord(Word.word);
        }
        public static List<string> KeyWord(string str)
        {  
            List<string> vs = new List<string>();
            IEnumerable<string> allfiles = new List<string>();
            sem.WaitOne();
            foreach (var item in drives)
            {
                allfiles = Directory.EnumerateFiles(item.Name);
                
            }
                foreach(var s in allfiles)
                {StreamReader file = new StreamReader(s);
                    if (file.ReadLine().Contains(str))
                    {
                        vs.Add(s);
                        count++;
                        OnCountChanged?.Invoke(count,vs);
                    }
                }
            sem.Release();
            
            return vs;
        }
       

        
    }
}
