﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoudKoorts.Domain
{
    public class WisselUit : Wissel
    {
        public WisselUit(int laan)
            : base(laan)
        {
            
        }

        public override bool Switch()
        {
            if (!base.Switch())
            {
                return false;
            }
            Volgende = Gekoppeld;
            return true;
        }
    }
}
