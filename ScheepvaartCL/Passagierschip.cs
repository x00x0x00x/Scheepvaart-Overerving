using System;

namespace ScheepvaartCL
{
    public abstract class Passagierschip : Schip
    {

        public Passagierschip(decimal lengte, decimal breedte, decimal tonnage, string naam, Vloot? vloot, int aantalpassagiers) : base(lengte, breedte, tonnage, naam, vloot)
        {
            AantalPassagiers = aantalpassagiers;
        }

        private int _AantalPassagiers;

        public int AantalPassagiers 
        {
            get { return _AantalPassagiers; }
            set { _AantalPassagiers = (value >= Validaties.minimumAantalPassagiers) ? value : throw new ArgumentException($"Een passagierschip moet minstens {Validaties.minimumAantalPassagiers} of meer passagiers bevatten."); }
        }

    }
}
