using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoudKoorts.Domain.Exceptions
{
    class VeranderWisselException : Exception
    {

       public VeranderWisselException(ConsoleKey key) : base(key.ToString().Substring(1)) {
           //Console.WriteLine("Wissel nummer " + key.ToString() + " moet worden omgezet");
       }
    }
}
