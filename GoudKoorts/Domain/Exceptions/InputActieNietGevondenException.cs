using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoudKoorts.Domain.Exceptions
{
    class InputActieNietGevondenException : Exception
    {
       public InputActieNietGevondenException(ConsoleKey key) : base(key.ToString()) {
       }
    }
}
