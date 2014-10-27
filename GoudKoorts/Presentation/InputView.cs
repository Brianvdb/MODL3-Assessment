using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoudKoorts.Presentation
{
    public class InputView
    {
        public bool WisselInput(){
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.Q:
                        Console.WriteLine("You pressed F1!");
                        return true;
                        break;
                    default:
                        break;
                }
            }

            return false;
        }

    }
}
