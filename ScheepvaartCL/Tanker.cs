using System;

namespace ScheepvaartCL
{
    public abstract class Tanker : Vrachtschip
    {
        public Tanker(decimal lengte, decimal breedte, decimal tonnage, string naam, Vloot? vloot, Decimal cargowaarde, Decimal volumeinliter) : base(lengte, breedte, tonnage, naam, vloot, cargowaarde)
        {
            VolumeInLiter = volumeinliter;
        }

        private Decimal _VolumeInLiter;

        public Decimal VolumeInLiter
        {
            get { return _VolumeInLiter; }
            set { _VolumeInLiter = (value >= Validaties.minimumVolumeInLiter) ? value : throw new ArgumentException($"Het minimum volume welke een tanker moet kunnen transporteren bedraagt {Validaties.minimumVolumeInLiter} liter of meer."); }
        }

    }
}
