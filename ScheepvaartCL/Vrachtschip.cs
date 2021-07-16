using System;

namespace ScheepvaartCL
{
    public abstract class Vrachtschip : Schip
    {

        public Vrachtschip(decimal lengte, decimal breedte, decimal tonnage, string naam, Vloot? vloot, Decimal cargowaarde) : base(lengte, breedte, tonnage, naam, vloot)
        {
            Cargowaarde = cargowaarde;
        }

        private Decimal _Cargowaarde;

        public Decimal Cargowaarde
        {
            get { return _Cargowaarde; }
            set { _Cargowaarde = (value >= Validaties.minimumCargowaarde) ? value : throw new ArgumentException($"De cargowaarde van een vrachtschip moet {Validaties.minimumCargowaarde} of meer EUR bedragen."); }
        }

    }
}
