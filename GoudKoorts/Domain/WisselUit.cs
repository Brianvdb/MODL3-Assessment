﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoudKoorts.Domain
{
    public class WisselUit : Wissel
    {
        public WisselUit() : base()
        {

        }

        public override void Switch()
        {
            if (base.Switch())
            {
                Volgende = Gekoppeld;
            }
        }
    }
}
