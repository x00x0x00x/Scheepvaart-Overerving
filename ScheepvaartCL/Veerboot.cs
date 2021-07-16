using System;

namespace ScheepvaartCL
{
    public class Veerboot : Passagierschip
    {
        public Veerboot(decimal lengte, decimal breedte, decimal tonnage, string naam, Vloot? vloot, int aantalpassagiers, Traject traject) : base(lengte, breedte, tonnage, naam, vloot, aantalpassagiers)
        {
            Traject = traject;
        }

        private Traject _traject;

        public Traject Traject
        {
            get { return _traject; }
            set { _traject = (value.Havens.Count == Validaties.fixedAantalHavensVeerbootTraject) ? value : throw new ArgumentException($"Het vereiste aantal havens voor het traject van een veerboot staat vast op {Validaties.fixedAantalHavensVeerbootTraject}."); }
        }

    }
}
