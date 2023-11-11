using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Diagnostics;

namespace Provodnik
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*showpapka("C:\\Program Files");*/
            showdrive();
        }


        static void showdrive()
        {
            while (true)
            {
                DriveInfo[] allDrives = DriveInfo.GetDrives();
                Console.Clear();
                Console.WriteLine("                                                Этот компьютер");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

                foreach (var disk in allDrives)
                {
                    Console.WriteLine("     " + disk.Name + "   Cвободное место: " + disk.TotalFreeSpace / 1024 / 1024 / 1024 + "ГБ" + "  из " + disk.TotalSize / 1024 / 1024 / 1024 + "ГБ");
                }
                int pos = Menu.Show(3, allDrives.Length + 3);
                if (pos == -1)
                {
                    return;
                }
                else
                {
                    showpapka(allDrives[pos - 3].RootDirectory.FullName);
                }

            }
        }

        static void showpapka(string p)
        {
                
                while (true)
                {
                    Console.Clear();
                    string[] paths = Directory.GetDirectories(p);
                    string[] filepaths = Directory.GetFiles(p);
                    string[] combined = paths.Concat(filepaths).ToArray();
                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                    Console.SetCursorPosition(5, Console.CursorTop);
                    Console.WriteLine("Имя файла" + "                                         " + "Дата изменения" + "                            " + "Тип");
                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");

                    foreach (string i in combined)
                    {
                        var date = Directory.GetLastWriteTime(i);
                        string rashirenie = Path.GetExtension(i);
                        Console.Write("   " + i);
                        Console.SetCursorPosition(30, Console.CursorTop);
                        Console.Write("          " + "             " + date);
                        Console.SetCursorPosition(70, Console.CursorTop);
                        Console.WriteLine("          " + "             " + rashirenie);
                    }


                    int pos = Menu.Show(3, combined.Length + 2);
                    if (pos == -1)
                    {
                        return;
                    }
                    else
                    {
                        showpapka(combined[pos - 3]);
                    }
                }
        }
    }   
}
