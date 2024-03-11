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
                            Console.WriteLine("Druk op een toets op verder te gaan.");

                            Console.ReadKey();
                        }

                        // Fout als geen plaats
                        else
                        {
                            // foutmelding 
                            Console.WriteLine("Jammer, maar er is geen plaats meer voor een nieuw alarm");
                            Console.WriteLine("Druk op een toets op verder te gaan.");

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
                        Console.WriteLine("Druk op een toets op verder te gaan.");

                        Console.ReadKey();

                    }
                    
                    // Verwijderen:
                    else if(keuze == 3)
                    {
                        // Toon Alarmen 
                        // Keuze Alarm
                        // Alarm verwijderen
                        // Alarm is verwijderd
                    }
                   

                    // Tonen:
                    else if(keuze == 4)
                    {
                        // Toon de alarmen in de juiste vorm

                    }

                    // Afsluiten
                    else if (keuze == 5)
                    {
                        // byebye tekstje

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

            return antwoord;
        }

        /// <summary>
        /// Slaat een alarm op in het gegeugen
        /// </summary>
        /// <param name="ontvTijdstip"></param>
        /// <param name="ontvDatum"></param>
        /// <param name="omschrijving"></param>
        /// <param name="nrIndex"></param>
        static public void AlarmOpslaan(String ontvTijdstip, String ontvDatum, String omschrijving, int nrIndex)
        {

        }

        /// <summary>
        /// Stuurt alle alarmen door
        /// </summary>
        /// <returns></returns>
        static public String ToonAlarmen()
        {
            String antwoord = null;

            return antwoord;
        }

    }
}
