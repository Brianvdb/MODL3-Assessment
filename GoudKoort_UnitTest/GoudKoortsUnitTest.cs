using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoudKoorts.Domain;
using GoudKoorts.Domain.Exceptions;

namespace GoudKoort_UnitTest
{
    [TestClass]
    public class GoudKoortsUnitTest
    {
        [TestMethod]
        public void TestWereld()
        {
            Spel spel = new Spel();

            Loods l2 = spel.Loodsen[1];

            Kar kar = new Kar(l2);
            spel.Karren.AddLast(kar);

            for (int i = 0; i < 4; i++)
            {
                spel.VerplaatsKarren();
            }

            // kijken of het karretje op de wissel terecht is gekomen
            Assert.AreEqual(true, (kar.Positie is WisselIn));
        }

        [TestMethod]
        public void TestWisselStop()
        {
            Spel spel = new Spel();

            Loods l1 = spel.Loodsen[0];

            Kar kar = new Kar(l1);
            spel.Karren.AddLast(kar);

            Baanvak posVoorWissel = null;

            for (int i = 0; i < 20; i++)
            {
                spel.VerplaatsKarren();
                if (i == 3)
                {
                    posVoorWissel = kar.Positie;
                }
            }

            // kijken of het karretje niet verder is gekomen dan de wissel
            Assert.AreEqual(true, (kar.Positie == posVoorWissel));
        }

        [TestMethod]
        public void TestWisselSwitch()
        {
            Spel spel = new Spel();

            Loods l1 = spel.Loodsen[0];

            Kar kar = new Kar(l1);
            spel.Karren.AddLast(kar);

            for (int i = 0; i < 3; i++)
            {
                spel.VerplaatsKarren();
            }

            spel.Wissels[0].Switch();

            for (int i = 0; i < 16; i++)
            {
                spel.VerplaatsKarren();
            }

            // kijken of het karretje nu juist verder is gekomen dan de wissel na een switch
            Assert.AreEqual(true, (kar.Positie is Kade));
        }

        [TestMethod]
        public void TestWisselsSwitch()
        {
            Spel spel = new Spel();

            Loods l2 = spel.Loodsen[1];

            Kar kar = new Kar(l2);
            spel.Karren.AddLast(kar);

            spel.Wissels[1].Switch();
            spel.Wissels[3].Switch();

            for (int i = 0; i < 18; i++)
            {
                spel.VerplaatsKarren();
            }


            // kijken of het karretje op de goede positie is gekomen na meerdere switches
            Assert.AreEqual(true, (kar.Positie is Kade));
        }

        [TestMethod]
        public void TestWisselsSwitchEnSchipLading()
        {
            Spel spel = new Spel();

            Loods l2 = spel.Loodsen[1];

            Kar kar = new Kar(l2);
            spel.Karren.AddLast(kar);

            spel.Wissels[1].Switch();
            spel.Wissels[3].Switch();

            spel.Kades[1].Schip = new Schip();

            for (int i = 0; i < 18; i++)
            {
                spel.VerplaatsKarren();
            }


            // kijken of het karretje op de goede positie is gekomen na meerdere switches, en of de lading is bijgewerkt
            Assert.AreEqual(true, (kar.Positie is Kade));
            Assert.AreEqual(true, spel.Kades[1].Schip.AantalLadingen == 1);
            Assert.AreEqual(true, !kar.Vol);
        }

        [TestMethod]
        public void TestKarOpWissel()
        {
            Spel spel = new Spel();

            Loods l2 = spel.Loodsen[1];

            Kar kar = new Kar(l2);
            spel.Karren.AddLast(kar);

            for (int i = 0; i < 4; i++)
            {
                spel.VerplaatsKarren();
            }

            Assert.AreEqual(false, spel.Wissels[0].Switch());
        }

        [TestMethod]
        [ExpectedException(typeof(KarBotsException))]
        public void TestKarBots()
        {
            Spel spel = new Spel();

            Loods l1 = spel.Loodsen[0];

            Kar kar = new Kar(l1);
            spel.Karren.AddLast(kar);

            for (int i = 0; i < 3; i++)
            {
                spel.VerplaatsKarren();
            }

            kar = new Kar(l1);
            spel.Karren.AddLast(kar);

            for (int i = 0; i < 3; i++)
            {
                spel.VerplaatsKarren();
            }
        }


        [TestMethod]
        public void TestKarVerwijderd()
        {
            Spel spel = new Spel();

            Loods l2 = spel.Loodsen[1];

            Kar kar = new Kar(l2);
            spel.Karren.AddLast(kar);

            for (int i = 0; i < 28; i++)
            {
                spel.VerplaatsKarren();
            }

            // kijken of het karretje nu op het einde staat
            Assert.AreEqual(true, spel.Karren.Contains(kar));

            spel.VerplaatsKarren();

            // kijken of het karretje nu niet meer in de lijst met karretjes staat
            Assert.AreEqual(false, spel.Karren.Contains(kar));
        }

    }
}
