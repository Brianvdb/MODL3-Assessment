using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoudKoorts.Domain
{
    public class Schip
    {
        public int AantalLadingen { get; private set; }

        public bool IsVol
        {
            get
            {
                return AantalLadingen == 8;
            }
        }

        public void LadingErbij()
        {
            if (AantalLadingen == 8)
            {
                return;
            }
            AantalLadingen++;
        }
    }
}
