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
        private Random random = new Random();

        //aantal seconden per stapje in beurt
        private static int timeInSecondsMax = 400;
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
                    //zolang het spel niet in de "actie" stap zit
                    if (stapIndex != 0)
                    {
                        spel.Wissels[Int32.Parse(e.Message)-1].Switch();
                        BerekenBeurt(false);
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
                
                //loop pauzeren anders een processorcore tot maximum laten werken
                System.Threading.Thread.Sleep(50);
            } 
        }


        private void DoeBeurt(Object source, ElapsedEventArgs e)
        {
            BerekenBeurt(true);            
        }

        private void BerekenBeurt(bool doeStap)
        {
            Console.Clear();
            outputView.TekenTijd(lastStep - stapIndex);

            //ga naar de volgende stap
            if (doeStap && stapIndex == lastStep)
            {
                stapIndex = 0;

                SchipEnKar();
                try
                {
                    spel.VerplaatsKarren();
                }
                catch (KarBotsException)
                {
                    ToonBoodschap("Je hebt een wissel niet optijd omgezet. Er heeft een botsing plaats gevonden.\n> Probeer opnieuw");
                    spel = new Spel();
                }

            }
            else
            {
                if (doeStap)
                {
                    stapIndex++;
                }
            }

            //teken alles
            outputView.TekenWereld(spel);
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

        public void SchipEnKar()
        {
            //kar toevoegen
            foreach(Loods loods in spel.Loodsen){
                if (random.Next(7) == 0 && loods.Volgende.Kar == null)
                {
                    Kar kar = new Kar(loods);
                    spel.Karren.AddLast(kar);
                    break;
                }
            }

            //schip toevoegen
            foreach (Kade kade in spel.Kades)
            {
                if (kade.Schip == null)
                {
                    if (random.Next(20) == 0)
                    {
                        kade.Schip = new Schip();
                    }
                }
            }


        }
    }
}
