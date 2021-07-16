using System;
using ScheepvaartCL.resources;

namespace ScheepvaartCL
{
    public class Olietanker : Tanker
    {
        // zal een exceptie opwerpen indien de olielading zich niet in de enum bevind
        public Olietanker(decimal lengte, decimal breedte, decimal tonnage, string naam, Vloot? vloot, Decimal cargowaarde, Decimal volumeinliter, Olie olielading) : base(lengte, breedte, tonnage, naam, vloot, cargowaarde, volumeinliter)
        {
            OlieLading = olielading;
        }

        public Olie OlieLading;
    }
}
