using System;
using ScheepvaartCL.configurations;
using System.ComponentModel;
using System.Text;

namespace ScheepvaartCL
{
    public abstract class Schip
    {
        public Schip(Decimal lengte, Decimal breedte, Decimal tonnage, string naam, Vloot? vloot=null)
        {
            Lengte = lengte;
            Breedte = breedte;
            Tonnage = tonnage;
            Naam = naam;
            Vloot = vloot;
        }

        // Wordt gebruikt door schip en alle overervende klassen (rederij / haven / traject aparte instantiering)
        public Validations Validaties = new Validations();
        public Writer Writer = new Writer();

        private Decimal _lengte;
        private Decimal _breedte;
        private Decimal _tonnage;
        private string _naam;
        public Vloot Vloot { get; set; }

        public Decimal Lengte
        {
            get { return _lengte; }
            set { _lengte = (value > Validaties.minLengteSchip) ? value : throw new ArgumentException($"De lengte van een schip kan niet minder dan {Validaties.minLengteSchip} zijn");
            }
        }

        public Decimal Breedte
        {
            get { return _breedte; }
            set
            {
                _breedte = (value > Validaties.minBreedteSchip) ? value : throw new ArgumentException($"De breedte van een schip kan niet minder dan {Validaties.minBreedteSchip} zijn");
            }
        }

        public Decimal Tonnage
        {
            get { return _tonnage; }
            set
            {
                _tonnage = (value > Validaties.minTonnageSchip) ? value : throw new ArgumentException($"De tonnage van een schip kan niet minder dan {Validaties.minTonnageSchip} zijn");
            }
        }

        public string Naam
        {
            get { return _naam; }
            set
            {
                _naam = (value.Length >= Validaties.mincharsSchipNaam) ? value : throw new ArgumentException($"De naam van een schip moet tenminste {Validaties.mincharsSchipNaam} karakters lang zijn.");
            }
        }

        // void override
        public override string ToString()
        {
            Writer.lijnSegment(this.GetType().Name, true);

            StringBuilder res = new StringBuilder();

            if (this.Vloot != null) { res.Append($"Vloot {this.Vloot.Naam}, "); };

            foreach (PropertyDescriptor sleutel in TypeDescriptor.GetProperties(this))
            {
                if(sleutel.DisplayName != "Vloot") {
                    res.Append($"{sleutel.DisplayName}: {sleutel.GetValue(this)}, ");
                }
            }

            res.Length = res.Length - 2; // trailing space+komma

            Writer.lijnSegment(res.ToString());
            Writer.eindeOverzicht();
            return res.ToString();
        }

    }
}
