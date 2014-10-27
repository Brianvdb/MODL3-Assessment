using GoudKoorts.Domain;
using GoudKoorts.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoudKoorts.Process
{
    public class Controller
    {
        public Spel Spel { get; set; }
        public OutputView OutputView { get; set; }
        public Controller()
        {
            Spel = new Spel();
            OutputView = new OutputView();
            OutputView.TekenWereld(Spel);
            Console.ReadKey();
        }
    }
}
