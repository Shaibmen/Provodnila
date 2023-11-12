using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Provodnik
{
    internal class Menu
    {
        private int minStrelochka;
        private int maxStrelochka;

        public Menu(int min, int max)
        {
            minStrelochka = min;
            maxStrelochka = max;
        }

        public static int Show(int minstrelochka, int maxstrelochka)
        {
            int pos = 0;
            ConsoleKeyInfo key;
            do
            {
                Console.SetCursorPosition(0, pos);
                Console.WriteLine("->");


                key = Console.ReadKey();

                Console.SetCursorPosition(0, pos);
                Console.WriteLine("  ");

                if (key.Key == ConsoleKey.UpArrow) 
                {
                    pos--;
                    if (pos == -1)
                    {
                        pos = maxstrelochka - 1;
                    }
               
                }

                if (key.Key == ConsoleKey.DownArrow)
                {
                    pos++;
                    if (pos == maxstrelochka)
                    {
                        pos = minstrelochka;
                    }
                }

                if (key.Key == ConsoleKey.Escape)
                {
                    pos = -2;
                    return pos;
                }

            } while (key.Key != ConsoleKey.Enter);
            return pos;

        }
    }
}
