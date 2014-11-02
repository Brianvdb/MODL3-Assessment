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
            Console.WindowHeight = 40;
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
            int bordBreedte = ((spel.Loodsen.Count-1)*4)+1;

            string[,] tekenArray = new string[30, bordBreedte];

            foreach(Loods loods in spel.Loodsen){

                int rijIndex = 0;
                Baanvak b = loods;

                ZetRouteOm(rijIndex, b, ref tekenArray, ref spel);
                
            }

            PrintAlles(ref tekenArray, bordBreedte);
        }

        public void ZetRouteOm(int rijIndex, Baanvak b, ref string[,] tekenArray, ref Spel spel) {
            while (b != null)
            {
                if (b is Wissel)
                {
                    Wissel wissel;

                    if (b is WisselIn)
                    {
                        wissel = b as WisselIn;
                    }
                    else
                    {
                        wissel = b as WisselUit;
                        ZetRouteOm(rijIndex, (wissel as WisselUit).Ongekoppeld, ref tekenArray, ref spel);
                    }

                    string numberOfWissel = (spel.Wissels.IndexOf(wissel) + 1).ToString();
                    string wisselWeergave = wissel.Kar == null ? "_" : "O";

                    if (wissel.Gekoppeld.Laan > b.Laan)
                    {
                        tekenArray[rijIndex - 1, b.Laan * 2 - 1] = numberOfWissel;
                        tekenArray[rijIndex - 1, b.Laan * 2 + 1] = wisselWeergave;
                    }
                    else
                    {
                        tekenArray[rijIndex - 1, b.Laan * 2 + 1] = numberOfWissel;
                        tekenArray[rijIndex - 1, b.Laan * 2 - 1] = wisselWeergave;
                    }
                }
                else
                {
                    tekenArray[rijIndex, b.Laan * 2] = GetCharacterVanBaanvak(b);
                    rijIndex++;
                }

                b = b.Volgende;
            }
        }

        private string GetCharacterVanBaanvak(Baanvak b){
            if (b is Kade)
            {
                return "K";
            }
            else if (b is Loods)
            {
                return ((b.Laan / 2) + 1).ToString();
            }
            else
            {
                if (b.Kar != null)
                {
                    return "O";
                }
                else
                {
                    return "|";
                }

            }
        }

        private int GetLoodsIndex(ref Spel spel, Loods loods){
            return spel.Loodsen.IndexOf(loods) * 4;
        }

        private void PrintAlles(ref string[,] tekenArray, int bordBreedte){
            for (int x = 0; x < 30; x++)
            {
                for (int y = 0; y < bordBreedte; y++)
                {
                    if (tekenArray[x,y] == null)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write(tekenArray[x, y]);
                    }
                }
                Console.Write("\n");
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
