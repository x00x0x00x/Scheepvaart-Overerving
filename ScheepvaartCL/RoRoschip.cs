using System;

namespace ScheepvaartCL
{
    public class RoRoschip : Vrachtschip
    {
        public RoRoschip(decimal lengte, decimal breedte, decimal tonnage, string naam, Vloot? vloot, Decimal cargowaarde, int aantaltrucks) : base(lengte, breedte, tonnage, naam, vloot, cargowaarde)
        {
            AantalTrucks = aantaltrucks;
        }

        private int _aantaltrucks;

        public int AantalTrucks
        {
            get { return _aantaltrucks; }
            set { _aantaltrucks = (value >= Validaties.minAantalTrucksRoRo) ? value : throw new ArgumentException($"Het minimum aantal trucks op een RoRoschip is {Validaties.minAantalTrucksRoRo}."); }
        }

    }
}
