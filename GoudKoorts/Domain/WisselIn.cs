using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoudKoorts.Domain
{
    public class WisselIn : Wissel
    {
        public WisselIn()
            : base()
        {
        
        }

        public override bool Plaats(Kar kar) {
            return true;
        }
    }
}
