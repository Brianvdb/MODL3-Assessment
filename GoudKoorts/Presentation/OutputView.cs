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

        public void TekenWereld(Spel spel)
        {
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
                    Console.Write("[]");
                }
                
                Console.Write("");
            }
        }
    }
}
