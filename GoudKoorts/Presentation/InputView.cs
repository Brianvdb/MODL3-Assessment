using GoudKoorts.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoudKoorts.Presentation
{
    public class InputView
    {
        public void WisselInput(){
            
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        VeranderWissel(key.Key);
                        break;
                    case ConsoleKey.D2:
                        VeranderWissel(key.Key);
                        break;
                    case ConsoleKey.D3:
                        VeranderWissel(key.Key);
                        break;
                    case ConsoleKey.D4:
                        VeranderWissel(key.Key);
                        break;
                    case ConsoleKey.D5:
                        VeranderWissel(key.Key);
                        break;
                    case ConsoleKey.Q:
                        throw new AnnuleerSpelException();
                    default:
                        throw new InputActieNietGevondenException(key.Key);
                }
            }
        }

        public void VeranderWissel(ConsoleKey key)
        {
            throw new VeranderWisselException(key);
        }

    }
}
