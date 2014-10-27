using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoudKoorts.Domain
{
    public class Kade : Baanvak
    {
        public Schip Schip { get; set; }
        public Kade()
            : base()
        {

        }

        public override bool Plaats(Kar kar)
        {
            if (!base.Plaats(kar))
            {
                return false;
            }
            if(Schip != null) {
                Schip.LadingErbij();
            }
            return true;
        }
    }
}
