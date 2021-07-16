
using ScheepvaartCL;
using ScheepvaartCL.resources;
using System.Collections.Generic;

namespace ScheepvaartCS
{
    class Program
    {
        static void Main(string[] args)
        {
            // maak rederij aan
            Rederij r = new Rederij("Gentse Rederij");

            // maak havens aan
            Haven h1 = new Haven("Antwerpen");
            Haven h2 = new Haven("Gent");
            Haven h3 = new Haven("Rotterdam");
            Haven h4 = new Haven("Amsterdam");

            // voeg havens toe aan rederij
            r.VoegHavenToe(h1);
            r.VoegHavenToe(h2);
            r.VoegHavenToe(h3);
            r.VoegHavenToe(h4);

            // maak trajecten
            List<Haven> havens = new List<Haven>();
            havens.Add(h1);
            havens.Add(h2);

            List<Haven> havens2 = new List<Haven>();
            havens2.Add(h1);
            havens2.Add(h2);
            havens2.Add(h3);
            havens2.Add(h4);

            Traject t1 = new Traject(havens);
            Traject t2 = new Traject(havens2);


            // alle soorten schepen aanmaken
            Schip cs1 = new Containerschip(10.0M, 3.0M, 300.0M, "De Yanno", null, 150000M, 1000);
            Schip crs1 = new Cruiseschip(10.0M, 10.0M, 10.0M, "De Amerikaan", null, 100, t1);
            Schip gt1 = new Gastanker(10.0M, 10.0M, 10.0M, "De Duiker", null, 10000.0M, 1250.0M, Gas.Amoniak);
            Schip ot1 = new Olietanker(10.0M, 10.0M, 10.0M, "De Zwever", null, 10000.0M, 1250.0M, Olie.Benzeen);
            Schip roro1 = new RoRoschip(10.0M, 10.0M, 10.0M, "De Trekker", null, 1000000.0M, 100);
            Schip sb1 = new Sleepboot(10.0M, 10.0M, 10.0M, "De Sleper");
            Schip vb1 = new Veerboot(5.0M, 12.5M, 5.0M, "De Veerder", null, 15, t1);

            Schip cs2 = new Containerschip(30.0M, 6.0M, 230.0M, "De Lijaan", null, 160000M, 1000);
            Schip crs2 = new Cruiseschip(25.0M, 14.0M, 10.0M, "De Europeaan", null, 125, t2);
            Schip sb2 = new Sleepboot(10.0M, 10.0M, 10.0M, "De Voorhanger");

            // vloten aanmaken
            Vloot v1 = new Vloot("De zinkers"); // cs1, crs1, gt1, ot1
            Vloot v2 = new Vloot("De zwevers"); // roro1, sb1, vb1, sb2

            // deze vloten toevoegen aan de rederij
            r.VoegVlootToe(v1);
            r.VoegVlootToe(v2);

            // schepen toekennen aan 2 verschillende vloten
            r.VoegSchipToeAanRederij(cs1, v1);
            r.VoegSchipToeAanRederij(crs1, v1);
            r.VoegSchipToeAanRederij(gt1, v1);
            r.VoegSchipToeAanRederij(ot1, v1);
            r.VoegSchipToeAanRederij(roro1, v2);
            r.VoegSchipToeAanRederij(sb1, v2);
            r.VoegSchipToeAanRederij(vb1, v2);
            r.VoegSchipToeAanRederij(sb2, v2);

            // een paar schepen toekennen aan louter de rederij
            r.VoegSchipToeAanRederij(cs2);
            r.VoegSchipToeAanRederij(crs2);

            // de overzichtsfuncties testen
            Overzicht RederijOverzicht = new Overzicht(r);

            RederijOverzicht.HavensAlfabetisch();
            RederijOverzicht.AantalPassagiers();
            RederijOverzicht.TonnagePerVloot();
            RederijOverzicht.GlobaalVolumeTankers();
            RederijOverzicht.BeschikbareSleepboten();
            RederijOverzicht.GlobaleCargowaarde();

            // de override functie testen
            sb1.ToString();
            
        }
    }
}
