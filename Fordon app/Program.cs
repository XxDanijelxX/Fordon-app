using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using System.Text.RegularExpressions;

namespace Projekt_xl
{
    class Program
    {
        static List<Fordon> fordonslista = new List<Fordon>();
        static List<string> bilmarken = new List<string>
        {
           "Acura", "Alfa Romeo", "Aston Martin", "Bentley", "Bugatti", "Buick", "Cadillac", "Chevrolet", "Chrysler", "Citroën", "Dodge", "Ferrari", "Fiat", "Ford", "Genesis"
        };
        static List<string> motorcykelTyper = new List<string>
        {
            "Street", "Naked", "Chopper", "Cruiser", "Touring", "Off-Road", "Scooter"
        };
        const int minLastbilVikt = 5;
        const int maxLastbilVikt = 100;
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. lägg till en bil");
                Console.WriteLine("2. lägg till en motorcykel");
                Console.WriteLine("3. lägg till lastbil");
                Console.WriteLine("4. visa listan med fordon");
                Console.WriteLine("5. stäng program");
                Console.Write("välja alternativ: ");
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Fel välj mellan alternativen visade.");
                    Console.WriteLine("tryck valfri knapp för att fortsätta...");
                    Console.ReadKey();
                    continue;
                }
                switch (choice)
                {
                    case 1:
                        läggTillBil();
                        break;
                    case 2:
                        LäggTillMC();
                        break;
                    case 3:
                        LäggTillLastBil();
                        break;
                    case 4:
                        VisaFordon();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("felaktigt val, testa igen.");
                        break;
                }
            }
        }
        private static void läggTillBil()
        {

            string reggnummer = GiltligRegistationsNummer();
            int årsnummer = GiltligÅrsModell();
            string bilmärke = GiltligBilMärke();

            Bil car = new Bil(reggnummer, årsnummer, bilmärke);
            fordonslista.Add(car);
        }

        private static void LäggTillMC()
        {
            string reggnummer = GiltligRegistationsNummer();
            int årsnummer = GiltligÅrsModell();

            string mcTyp = GiltligMCTyp();


            Mc mc = new Mc(reggnummer, årsnummer, mcTyp);
            fordonslista.Add(mc);
        }
        private static void LäggTillLastBil()
        {
            string reggnummer = GiltligRegistationsNummer();
            int årsnummer = GiltligÅrsModell();
            int lastbilsVikt = GiltligLastbilsVikt();


            Lastbil lastbil = new Lastbil(reggnummer, årsnummer, lastbilsVikt);
            fordonslista.Add(lastbil);
        }

        private static void VisaFordon()
        {
            foreach (Fordon item in fordonslista)
            {
                Console.WriteLine("Registreringsnummer: {0}", item.Registreringsnummer);
                Console.WriteLine("Årsmodell: {0}", item.Årsmodell);
                if (item is Bil)
                {
                    Console.WriteLine("Bilmärke: {0}", ((Bil)item).BilMärke);
                }
                else if (item is Mc)
                {
                    Console.WriteLine("Motorcykel typ: {0}", ((Mc)item).McTyp);
                }
                else if (item is Lastbil)
                {
                    Console.WriteLine("Lastbils vikt: {0}", ((Lastbil)item).LastbilsVikt);
                }
                Console.WriteLine("------------------");
            }
            Console.WriteLine("tryck valfri knapp för att fortsätta...");
            Console.ReadKey();

        }

        private static string GiltligRegistationsNummer()
        {
            string reggnummer;
            Regex regex = new Regex(@"^[A-Za-z]{3}\d{3}$");
            while (true)
            {
                Console.Write("regrummer (Tre bokstäver med tre efterföljande nummer) (UTAN MELLANRUM): ");
                reggnummer = Console.ReadLine();
                if (regex.IsMatch(reggnummer))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Ogiltigt regnummer, Försök gärna igen.");
                }
            }
            return reggnummer;
        }

        private static int GiltligÅrsModell()
        {
            int årsnummer;

            while (true)
            {
                Console.Write("Årsmodel (mellan 1900 och 2024): ");
                try
                {
                    årsnummer = int.Parse(Console.ReadLine());
                    if (årsnummer >= 1900 && årsnummer <= 2024)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("årsmodell mellan 1900 och 2024, Snälla försök igen.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("fel input. Skriv ett giltigt nummer.");
                }
            }
            return årsnummer;
        }
        private static string GiltligBilMärke()
        {
            string bilmärke;
            while (true)
            {
                Console.WriteLine("Välj bilmärke (Enligt val från listan):");
                foreach (string brand in bilmarken)
                {
                    Console.WriteLine(brand);
                }

                bilmärke = Console.ReadLine();
                if (bilmarken.Contains(bilmärke))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Ogiltigt bilmärke, Försök igen.");
                }
            }
            return bilmärke;
        }
        private static string GiltligMCTyp()
        {
            string mcTyp;
            while (true)
            {
                Console.WriteLine("Välj Motorcykel typ (Enligt val från listan):");
                foreach (string type in motorcykelTyper)
                {
                    Console.WriteLine(type);
                }

                mcTyp = Console.ReadLine();
                if (motorcykelTyper.Contains(mcTyp))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("ogiltig Motorcykel typ, försök igen.");
                }
            }
            return mcTyp;
        }
        private static int GiltligLastbilsVikt()
        {
            int lastbilsVikt;
            while (true)
            {
                Console.Write($"Skriv lastbilens vikt (Mellan {minLastbilVikt} och {maxLastbilVikt} ton): ");
                if (!int.TryParse(Console.ReadLine(), out lastbilsVikt))
                {
                    Console.WriteLine("Ogiltig vikt, försök igen.");
                    continue;
                }

                if (lastbilsVikt < minLastbilVikt || lastbilsVikt > maxLastbilVikt)
                {
                    Console.WriteLine($"Lägg gärna en vikt mellan {minLastbilVikt} och {maxLastbilVikt} ton.");
                }
                else
                {
                    break;
                }
            }
            return lastbilsVikt;
        }
    }

}