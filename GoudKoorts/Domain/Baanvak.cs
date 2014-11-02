using GoudKoorts.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoudKoorts.Domain
{
    public class Baanvak
    {
        public Baanvak Volgende { get; set; }
        public Kar Kar { get; private set; }
        public int Laan { get; private set; }

        public Baanvak(int laan)
        {
            Laan = laan;
        }

        public virtual bool Plaats(Kar kar)
        {
            if (Kar != null)
            {
                throw new KarBotsException("Hier staat al een kar.");
            }
            Kar = kar;
            return true;
        }

        public void VerwijderKar()
        {
            Kar = null;
        }
    }
}
