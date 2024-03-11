using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Proj_AlarmenMaks
{
    internal class Program
    {
        // Tom Adriaen s
        // 05/03/2024
        // Project: Alarmen Maks

        //Velden
        static String[] _omschrijving = new string[10];
        static DateTime[] _datumEnTijdstip = new DateTime[10];

        //GUI
        static void Main(string[] args)
        {
            // Variabelen 
            byte keuze = 0;

            do
            {
                // Scherm wissen 
                Console.Clear();

                // Keuze menu
                Console.WriteLine("Maak uw keuze uit onderstaand menu:");
                Console.WriteLine("\n\n   1) Aanmaken alarm\n   2) Alarm aanpassen\n   " +
                    "3) Alarm verwijderen\n   4) Toon alle alarmen\n   5) Afsluiten");

                try
                {
                    //Vraag keuze + opslaan 
                    Console.Write("\n\nUw keuze: ");
                    keuze = byte.Parse(Console.ReadLine());

                    // Scherm wissen 
                    Console.Clear();

                    // Aanmaken Alarm:
                    if (keuze == 1)
                    {
                        
                        // Kijk of er plaats is
                        int plaats =  ZoekLegePlaats();
                        
                        // Als er plaats is:
                        if(plaats != -1)
                        {
                            // Tijdstip, datum, omschrijving
                            Console.Write("Geef de datum van het alarm (dd/mm/jjjj) : ");
                            string datum = Console.ReadLine();

                            Console.Write("\nGeef het tijdstip in (uu:mm) : ");
                            string tijdstip = Console.ReadLine();

                            string omschrijving = "Alarm";
                            Console.Write("Wilt u graag een andere omschrijving geven? (J/N)");
                            string antwoord = Console.ReadLine().Substring(0,1).ToUpper() ;

                            if(antwoord == "J")
                            {
                                // Scherm wissen 
                                Console.Clear();

                                Console.Write("Uw omschrijving: ");
                                omschrijving = Console.ReadLine() ;

                            }

                            // Stuur alle paramaters door met de functie.
                            AlarmOpslaan(tijdstip, datum,omschrijving, plaats);

                            // Scherm wissen 
                            Console.Clear();

                            // Alarm is ingevoerd
                            Console.WriteLine("Het alarm werd ingevoerd.");
                            Console.WriteLine("Druk op een toets om verder te gaan.");

                            Console.ReadKey();
                        }

                        // Fout als geen plaats
                        else
                        {
                            // foutmelding 
                            Console.WriteLine("Jammer, maar er is geen plaats meer voor een nieuw alarm");
                            Console.WriteLine("Druk op een toets om verder te gaan.");

                            Console.ReadKey();
                        }
                    }


                    // Updaten:
                    else if (keuze == 2)
                    {
                        // Toon Alarmen
                        Console.WriteLine(ToonAlarmen());

                        // Keuze Alarm
                        Console.Write("Geef het nummer van het alarm dat uw wilt aanpassen: ");
                        int plaats = int.Parse(Console.ReadLine())-1;

                        // Tijdstip, datum, omschrijving
                        Console.Write("Geef de datum van het alarm (dd/mm/jjjj) : ");
                        string datum = Console.ReadLine();

                        Console.Write("\nGeef het tijdstip in (uu:mm) : ");
                        string tijdstip = Console.ReadLine();

                        string omschrijving = "Alarm";
                        Console.Write("Wilt u graag een andere omschrijving geven? (J/N)");
                        string antwoord = Console.ReadLine().Substring(0, 1).ToUpper();

                        if (antwoord == "J")
                        {
                            // Scherm wissen 
                            Console.Clear();

                            Console.Write("Uw omschrijving: ");
                            omschrijving = Console.ReadLine();

                        }

                        // Stuur alle paramaters door met de functie.
                        AlarmOpslaan(tijdstip, datum, omschrijving, plaats);

                        // Scherm wissen 
                        Console.Clear();

                        // Alarm is ingevoerd
                        Console.WriteLine("Het alarm werd aangepast.");
                        Console.WriteLine("Druk op een toets om verder te gaan.");

                        Console.ReadKey();

                    }
                    
                    // Verwijderen:
                    else if(keuze == 3)
                    {

                        // Toon Alarmen
                        Console.WriteLine(ToonAlarmen());

                        // Keuze Alarm
                        Console.Write("Geef het nummer van het alarm dat uw wilt aanpassen: ");
                        int plaats = int.Parse(Console.ReadLine()) - 1;

                        // Alarm verwijderen
                        AlarmOpslaan(null, null, null, plaats);

                        // Alarm is verwijderd
                        Console.WriteLine("Het alarm werd verwijderd.");
                        Console.WriteLine("Druk op een toets om verder te gaan.");

                        Console.ReadKey();
                    }


                    // Tonen:
                    else if(keuze == 4)
                    {
                        // Toon Alarmen
                        Console.WriteLine(ToonAlarmen());

                        Console.WriteLine("\n\nDruk op een toets om verder te gaan.");

                        Console.ReadKey();

                    }

                    // Afsluiten
                    else if (keuze == 5)
                    {
                        // byebye tekstje
                        Console.WriteLine("Ben je eindelijk uit je bed?\n Goed zo!\nDruk op een toets om af te sluiten.");

                        Console.ReadKey();
                    }

                    else
                    {
                        // foutmelding
                        Console.WriteLine("U gaf geen juiste keuze in. \nDruk op een toets om naar het hoofdmenu te gaan.");
                        Console.ReadKey();
                    }
                    
                }
                catch 
                {
                    // Scherm leegmaken 
                    Console.Clear();

                    // foutmelding
                    Console.WriteLine("Er ging iets fout. \nDruk op een toets om naar het hoofdmenu te gaan.");
                    Console.ReadKey();
                }

            }
            while (keuze != 5);



        }

        //Functies
        /// <summary>
        /// Zoekt een lege plaats in de array
        /// </summary>
        /// <returns></returns>
        static public int ZoekLegePlaats()
        {
            int antwoord = -1;

            // Array overlopen 
            for (int i = 0; i < _datumEnTijdstip.Count(); i++)
            {
                if (_datumEnTijdstip[i] == null)
                {
                    antwoord = i;
                    break;
                }
                
            }

            // stuur antwoord terug
            return antwoord;
        }

        /// <summary>
        /// Slaat een alarm op in het geheugen
        /// </summary>
        /// <param name="ontvTijdstip"></param>
        /// <param name="ontvDatum"></param>
        /// <param name="omschrijving"></param>
        /// <param name="nrIndex"></param>
        static public void AlarmOpslaan(String ontvTijdstip, String ontvDatum, String omschrijving, int nrIndex)
        {
            try
            {
                DateTime alarm = DateTime.Parse($"{ontvDatum} {ontvTijdstip}");
                _datumEnTijdstip[nrIndex]= alarm;
                _omschrijving[nrIndex] = omschrijving;
            }
            catch
            {

            }

        }

        /// <summary>
        /// Stuurt alle alarmen door
        /// </summary>
        /// <returns></returns>
        static public String ToonAlarmen()
        {
            String antwoord = null;
            DateTime vandaag = DateTime.Now;

            for (int i = 0; i < _datumEnTijdstip.Count(); i++)
            {
                if (_datumEnTijdstip[i] > vandaag)
                {
                    TimeSpan verschil = _datumEnTijdstip[i] - vandaag;
                    int aantalDagen =  Convert.ToInt32(Math.Floor(verschil.TotalDays));

                    int aantalUren = Convert.ToInt32(Math.Floor(verschil.TotalHours - (aantalDagen * 24)));

                    int aantalmin = Convert.ToInt32(Math.Floor(verschil.TotalMinutes - (aantalDagen * 24*60) - (aantalUren * 60)));

                    antwoord += $"{_omschrijving[i]} op {_datumEnTijdstip[i].ToShortDateString()} om {_datumEnTijdstip[i].ToShortTimeString()} gaat af binnen " +
                        $"" +
                        $"{aantalDagen.ToString()} dagen, {aantalUren.ToString()} uren en {aantalmin.ToString()} minuten";

                }


            }
            // <omschrijving> op <dd/mm/yyyy>  om <hh:mm> gaat af binnen <aantal> dagen, <aantal> uur en <aantal> seconden
            return antwoord;
        }

    }
}
