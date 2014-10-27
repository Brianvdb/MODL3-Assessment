using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoudKoorts.Domain.Exceptions
{
    public class KarBotsException : Exception
    {
        public KarBotsException()
        {

        }

       public KarBotsException(string message) : base(message) {

       }
    }
}
