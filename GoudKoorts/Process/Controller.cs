using GoudKoorts.Domain;
using GoudKoorts.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace GoudKoorts.Process
{
    public class Controller
    {
        private Spel spel;
        private OutputView outputView;
        private InputView inputView;
        private Timer timer;
        private int stapIndex;

        //aantal seconden per stapje in beurt
        private static int timeInSecondsMax = 1000;
        private int timeInSecondsNow = timeInSecondsMax;

        public Controller()
        {
            timer = new Timer(timeInSecondsMax);
            timer.Elapsed += DoeBeurt;
            timer.Enabled = true;
            
            spel = new Spel();
            inputView = new InputView();
            outputView = new OutputView();
            outputView.TekenWereld(spel);

            SpeelSpel();
        }

        public void SpeelSpel()
        {
            bool print = false;
            while (true)
            {
                if (inputView.WisselInput())
                {
                    print = !print;
                }
                if (print)
                {

                Console.WriteLine("blabla");
                }
                
            } 
        }


        private void DoeBeurt(Object source, ElapsedEventArgs e)
        {

            if (stapIndex == 4)
            {
                stapIndex = 0;
            }
            else
            {
                stapIndex++;
            }

        }

        public void reduceTime()
        {
            timer.Interval = timer.Interval * 0.80;
        }
    }
}
