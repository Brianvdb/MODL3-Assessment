using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoudKoorts.Domain
{
    public class WisselIn : Wissel
    {
        public WisselIn(int laan)
            : base(laan)
        {
        }

        public override bool Plaats(Kar kar) {
            // kijken of current positie van kar gekoppeld is
            if (kar.Positie == base.Ongekoppeld)
            {
                return false;
            }
            base.Plaats(kar);
            return true;
        }
    }
}
