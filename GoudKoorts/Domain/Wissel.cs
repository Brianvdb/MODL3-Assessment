using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoudKoorts.Domain
{
    public class Wissel : Baanvak
    {
        public Baanvak Gekoppeld { get; set; }
        public Baanvak Ongekoppeld { get; set; }
        public Wissel(int laan)
            : base(laan)
        {
            
        }

        public virtual bool Switch()
        {
            if (base.Kar != null)
            {
                return false;
            }
            Baanvak _tmp = Gekoppeld;
            Gekoppeld = Ongekoppeld;
            Ongekoppeld = _tmp;
            return true;
        }
    }
}
