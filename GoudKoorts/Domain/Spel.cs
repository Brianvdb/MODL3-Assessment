using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoudKoorts.Domain
{
    public class Spel
    {
        public List<Loods> Loodsen { get; set; }
        public List<Wissel> Wissels { get; set; }
        public List<Kade> Kades { get; set; }

        public int Score { get; set; }

        public int KarrenOpKadesSchepen
        {
            get
            {
                int i = 0;
                foreach (Kade k in Kades)
                {
                    if (k.Schip != null)
                    {
                        i++;
                    }
                }
                return i;
            }
        }

        public Spel()
        {
            Loodsen = new List<Loods>();
            Wissels = new List<Wissel>();
            Kades = new List<Kade>();
            MaakWereld();
        }

        private void MaakWereld()
        {
            Loods l1 = new Loods();
            Loods l2 = new Loods();
            Loods l3 = new Loods();

            Kade k1 = new Kade();
            Kade k2 = new Kade();

            Wissel w1 = new WisselIn();
            Wissel w2 = new WisselUit();
            Wissel w3 = new WisselIn();
            Wissel w4 = new WisselIn();
            Wissel w5 = new WisselUit();

            // start loods 1
            Baanvak b = l1;
            for (int i = 0; i < 3; i++)
            {
                b.Volgende = b = new Baanvak();
            }

            b.Volgende = w1;
            w1.Ongekoppeld = b;

            // start loods 2
            l2.Volgende = b = new Baanvak();
            for (int i = 0; i < 3; i++)
            {
                b.Volgende = b = new Baanvak();
            }

            b.Volgende = w1;
            w1.Gekoppeld = b;

            // route na w1

            w1.Volgende = b = new Baanvak();

            b.Volgende = w2;
            
            // wissel 2

            w2.Gekoppeld = new Baanvak();
            w2.Ongekoppeld = new Baanvak();
            w2.Volgende = w2.Gekoppeld;

            // gekoppelde route na w2


            b = w2.Volgende;
            for (int i = 0; i < 4; i++)
            {
                b.Volgende = b = new Baanvak();
            }

            // wissel 3

            b.Volgende = w3;
            w3.Gekoppeld = b;

            // route na w3

            b = w3;
            for (int i = 0; i < 6; i++)
            {
                b.Volgende = b = new Baanvak();
            }

            b.Volgende = b = k1;

            for (int i = 0; i < 9; i++)
            {
                b.Volgende = b = new Baanvak();
            }

            // route na w2 ongekoppeld

            b = w2.Ongekoppeld;
            b.Volgende = b = new Baanvak();

            // wissel 4

            b.Volgende = w4;
            w4.Ongekoppeld = b;
            
            // route vanaf loods 3
            b = l3;
            for (int i = 0; i < 6; i++)
            {
                b.Volgende = b = new Baanvak();
            }

            // koppelen met w4

            w4.Gekoppeld = b;

            // route na w4

            w4.Volgende = b = new Baanvak();

            // wissel 5

            w5.Gekoppeld = new Baanvak();
            w5.Ongekoppeld = new Baanvak();
            w5.Volgende = w5.Gekoppeld;

            // rooute na w5 (gekoppeld)

            b = w5.Gekoppeld;

            for (int i = 0; i < 6; i++)
            {
                b.Volgende = b = new Baanvak(); 
            }

            b.Volgende = b = new Kade();

            for (int i = 0; i < 9; i++)
            {
                b.Volgende = b = new Baanvak();
            }

            // route na w5 (ongekoppeld)

            b = w5.Ongekoppeld;

            for (int i = 0; i < 2; i++)
            {
                b.Volgende = b = new Baanvak();
            }

            b.Volgende = w3;
            w3.Ongekoppeld = b;

            Loodsen.Add(l1);
            Loodsen.Add(l2);
            Loodsen.Add(l3);

            Wissels.Add(w1);
            Wissels.Add(w2);
            Wissels.Add(w3);
            Wissels.Add(w4);
            Wissels.Add(w5);

            Kades.Add(k1);
            Kades.Add(k2);
        }
    }
}
