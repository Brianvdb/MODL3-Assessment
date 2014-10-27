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

        private Baanvak positie;


        public Kar(Baanvak positie)
        {
            this.positie = positie;
        }

        public Baanvak DoeStap()
        {
            if (this.positie.Volgende == null)
            {
                return null;
            }

            bool success = this.positie.Volgende.Plaats(this);
            if (success)
            {
                this.positie.VerwijderKar();
                this.positie = this.positie.Volgende;
            }

            return this.positie;
        }
    }
}
