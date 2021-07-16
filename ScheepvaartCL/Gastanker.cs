using System;
using ScheepvaartCL.resources;

namespace ScheepvaartCL
{
    public class Gastanker: Tanker
    {
        // zal een exceptie opwerpen indien de gaslading zich niet in de enum bevind
        public Gastanker(decimal lengte, decimal breedte, decimal tonnage, string naam, Vloot? vloot, Decimal cargowaarde, Decimal volumeinliter, Gas gaslading) : base(lengte, breedte, tonnage, naam, vloot, cargowaarde, volumeinliter)
        {
            GasLading = gaslading;
        }

        public Gas GasLading;
    }
}
