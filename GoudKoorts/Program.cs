using GoudKoorts.Domain;
using GoudKoorts.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoudKoorts
{
    class Program
    {
        static void Main(string[] args)
        {
            Spel spel = new Spel();

            Loods l2 = spel.Loodsen[1];

            Kar kar = new Kar(l2);
            spel.Karren.AddLast(kar);

            spel.Wissels[1].Switch();
            spel.Wissels[3].Switch();

            for (int i = 0; i < 50; i++)
            {
                spel.VerplaatsKarren();

                Console.WriteLine(kar.Positie);
            }


            new Controller();
        }
    }
}
