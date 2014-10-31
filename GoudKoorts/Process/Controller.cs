using GoudKoorts.Domain;
using GoudKoorts.Domain.Exceptions;
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
        private int lastStep = 3;
        private bool speelSpel = true;

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

            SpeelSpel();
        }

        public void SpeelSpel()
        {
            while (speelSpel)
            {
                try
                {
                    inputView.WisselInput();
                }
                catch(VeranderWisselException e)
                { 
                    //Console.WriteLine("Wissel: " + e.Message + " wordt gewisseld");
                    if (stapIndex != lastStep)
                    {
                        //veranderen van de wissel
                    }
                }
                catch (InputActieNietGevondenException)
                {
                    ToonBoodschap("Gebruik de toetsen 1-5 om een wissel om te zetten.\nMet Q wordt het spel afgesloten.");
                }
                catch (AnnuleerSpelException)
                {
                    ToonBoodschap("Het spel is geannuleerd");
                    speelSpel = false;
                }
                
                
            } 
        }


        private void DoeBeurt(Object source, ElapsedEventArgs e)
        {
            //teken alles
            Console.Clear();
            outputView.TekenWereld(spel);

            //ga naar de volgende stap
            if (stapIndex == lastStep)
            {
                stapIndex = 0;
            }
            else
            {
                stapIndex++;
            }

        }

        public void ReduceTime()
        {
            timer.Interval = timer.Interval * 0.80;
        }

        public void ToonBoodschap(string boodschap)
        {
            timer.Enabled = false;
            outputView.ToonBoodschap(boodschap);
            timer.Enabled = true;
        }
    }
}
