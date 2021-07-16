using System;

namespace ScheepvaartCL
{
    public class Containerschip : Vrachtschip
    {
        public Containerschip(decimal lengte, decimal breedte, decimal tonnage, string naam, Vloot? vloot, Decimal cargowaarde, int aantalcontainers) : base(lengte, breedte, tonnage, naam, vloot, cargowaarde)
        {
            AantalContainers = aantalcontainers;
        }

        private int _aantalcontainers;

        public int AantalContainers
        {
            get { return _aantalcontainers; }
            set { _aantalcontainers = (value >= Validaties.minimumContainers) ? value : throw new ArgumentException($"Eigen aan containerschepen is dat zij {Validaties.minimumContainers} of meer containers moeten kunnen vervoeren."); }
        }

    }
}
