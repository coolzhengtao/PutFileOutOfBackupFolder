using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PutFileOutOfFolder
{
    class Program
    {
        //This is Applications entry.
        static void Main(string[] args)
        {
            string strInput = null;
            while (true)
            {
                Console.WriteLine("Please input source of folder,if you don't input it,will use this app's folder:");
                strInput = Console.ReadLine().Trim();
                if (Directory.Exists(strInput) || strInput == "")
                    break;
                else
                    Console.WriteLine("Input folder don't exists.");
            }
            string strSource = strInput == "" ? Directory.GetCurrentDirectory() : strInput;
            string[] strFolders = Directory.GetDirectories(strSource);
            Console.WriteLine("Please input target of folder,if you don't input it,will use this app's folder.");
            strInput = Console.ReadLine().Trim();
            string strTarget = strInput == "" ? Directory.GetCurrentDirectory() : strInput;
            //make sure that target folder is exists.
            if (!Directory.Exists(strTarget))
            {
                Console.WriteLine("Target folder don't exists,app will create it.");
                Directory.CreateDirectory(strTarget);
            }
            foreach (var folder in strFolders)
            {
                //遍历每个文件夹
                var files = Directory.GetFiles(folder);
                foreach (var file in files)
                {
                    var fileInfo = new FileInfo(file);
                    File.Move(file, strTarget + "\\" + fileInfo.Name);
                    Console.WriteLine("{0} file move to {1}", file, strTarget);
                }
            }
            Console.Read();
        }
    }
}
