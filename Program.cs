using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Provodnik
{
    internal class Program
    {
        static void Main(string[] args)
        {
            showdrive();
        }


        static void showdrive()
        {
            Console.WriteLine("                                                Этот компьютер");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo disk in allDrives)
            {
                Console.WriteLine("     " + disk.Name);
                if (disk.IsReady == true)
                {
                    Console.WriteLine("Total available space:          {0, 15} ГБ", disk.TotalFreeSpace / 1024 / 1024 / 1024);
                    Console.WriteLine("Total size of drive:            {0, 15} ГБ", disk.TotalSize / 1024 / 1024 / 1024);
                }
            }
        }
        static void showpapka(string p)
        {
            
            Console.Clear();
            string[] paths = Directory.GetDirectories(p);
            string[] filepaths = Directory.GetFiles(p);
            Console.WriteLine("------------------------------------------------------------------------------------------------------");
            foreach (string path in paths)
            {
                Console.WriteLine("   " + path);
            }
            foreach (string path in filepaths)
            {
                Console.WriteLine("   " + path);
            }

            int pos = Menu.Show(0, paths.Length + 1);
            if (pos == -1)
            {
                return;
            }
            else
            {
                showpapka(paths[pos]);
            }
        }
    }
}
