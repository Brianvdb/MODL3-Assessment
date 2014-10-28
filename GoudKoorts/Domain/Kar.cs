using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoudKoorts.Domain
{
    public class Kar
    {
        public bool Vol { get; set; }

        public Baanvak Positie { get; set; }


        public Kar(Baanvak positie)
        {
            Positie = positie;
            positie.Plaats(this);
            Vol = true;
        }

        public Baanvak DoeStap()
        {
            if (Positie.Volgende == null)
            {
                return null;
            }

            bool success = Positie.Volgende.Plaats(this);
            if (success)
            {
                Positie.VerwijderKar();
                Positie = Positie.Volgende;
            }

            return Positie;
        }
    }
}
