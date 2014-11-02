using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoudKoorts.Domain
{
    public class Spel
    {
        public List<Loods> Loodsen { get; private set; }
        public List<Wissel> Wissels { get; private set; }
        public List<Kade> Kades { get; private set; }
        public LinkedList<Kar> Karren { get; private set; }

        public int Score { get; set; }

        public int KarrenOpKadesSchepen
        {
            get
            {
                int i = 0;
                foreach (Kade k in Kades)
                {
                    if (k.Schip != null && k.Kar != null)
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
            Karren = new LinkedList<Kar>();
            MaakWereld();
        }

        private void MaakWereld()
        {
            Loods l1 = new Loods(0);
            Loods l2 = new Loods(2);
            Loods l3 = new Loods(4);

            Kade k1 = new Kade(1);
            Kade k2 = new Kade(4);

            Wissel w1 = new WisselIn(1);
            Wissel w2 = new WisselUit(1);
            Wissel w3 = new WisselIn(1);
            Wissel w4 = new WisselIn(3);
            Wissel w5 = new WisselUit(3);

            // start loods 1
            Baanvak b = l1;
            for (int i = 0; i < 3; i++)
            {
                b.Volgende = b = new Baanvak(0);
            }

            b.Volgende = w1;
            w1.Ongekoppeld = b;

            // start loods 2
            b = l2;
            for (int i = 0; i < 3; i++)
            {
                b.Volgende = b = new Baanvak(2);
            }

            b.Volgende = w1;
            w1.Gekoppeld = b;

            // route na w1

            w1.Volgende = b = new Baanvak(1);

            b.Volgende = w2;
            
            // wissel 2

            w2.Gekoppeld = new Baanvak(0);
            w2.Ongekoppeld = new Baanvak(2);
            w2.Volgende = w2.Gekoppeld;

            // gekoppelde route na w2


            b = w2.Volgende;
            for (int i = 0; i < 4; i++)
            {
                b.Volgende = b = new Baanvak(0);
            }

            // wissel 3

            b.Volgende = w3;
            w3.Gekoppeld = b;

            // route na w3

            b = w3;
            for (int i = 0; i < 6; i++)
            {
                b.Volgende = b = new Baanvak(1);
            }

            b.Volgende = b = k1;

            for (int i = 0; i < 9; i++)
            {
                b.Volgende = b = new Baanvak(1);
            }

            // route na w2 ongekoppeld

            b = w2.Ongekoppeld;
            b.Volgende = b = new Baanvak(2);

            // wissel 4

            b.Volgende = w4;
            w4.Ongekoppeld = b;
            
            // route vanaf loods 3
            b = l3;
            for (int i = 0; i < 6; i++)
            {
                b.Volgende = b = new Baanvak(4);
            }

            // koppelen met w4

            w4.Gekoppeld = b;

            // route na w4

            w4.Volgende = b = new Baanvak(3);
            b.Volgende = w5;

            // wissel 5

            w5.Gekoppeld = new Baanvak(4);
            w5.Ongekoppeld = new Baanvak(2);
            w5.Volgende = w5.Gekoppeld;

            // route na w5 (gekoppeld)

            b = w5.Gekoppeld;

            for (int i = 0; i < 5; i++)
            {
                b.Volgende = b = new Baanvak(4); 
            }

            b.Volgende = b = k2;

            for (int i = 0; i < 9; i++)
            {
                b.Volgende = b = new Baanvak(4);
            }

            // route na w5 (ongekoppeld)

            b = w5.Ongekoppeld;

            b.Volgende = b = new Baanvak(2);

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

        public void VerplaatsKarren()
        {
            foreach(Kar kar in Karren.ToList()) {
                if (kar.DoeStap() == null)
                {
                    Karren.Remove(kar);
                }
            }
        }
    }
}
