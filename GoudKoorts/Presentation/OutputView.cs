using GoudKoorts.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoudKoorts.Presentation
{
    public class OutputView
    {
        public OutputView()
        {
            Console.Title = "Goudkoorts";
        }

        public void TekenTijd(int tijd)
        {
            if (tijd == 0)
            {
                Console.WriteLine("> ACTIE!");
            }
            else
            {
                Console.WriteLine("> Tijd over: " + tijd + ", verander de wissels.");
            }
        }

        public void TekenWereld(Spel spel)
        {
            Console.WriteLine("> Score: " + spel.Score);
            Console.WriteLine();

            Loods l1 = spel.Loodsen[0];
            for (Baanvak b = l1; b != null; b = b.Volgende)
            {
                if (b is Loods)
                {
                    Console.Write("[X]");
                }
                else if (b is WisselIn)
                {
                    Console.Write("<");
                }
                else if (b is WisselUit)
                {
                    Console.Write(">");
                }
                else if (b is Kade)
                {
                    Console.Write("[K]");
                }
                else
                {
                    if (b.Kar != null)
                    {
                        Console.Write("[k]");
                    }
                    else
                    {
                        Console.Write("[]");
                    }
                    
                }
                
                Console.Write("");
            }
        }

        public void ToonBoodschap(string boodschap)
        {
            Console.Clear();
            Console.WriteLine("> " + boodschap);
            Console.WriteLine("Druk op een toets om verder te gaan...");
            Console.ReadKey();
        }
    }
}
