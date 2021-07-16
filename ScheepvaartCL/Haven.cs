using System;
using ScheepvaartCL.configurations;

namespace ScheepvaartCL
{
    public class Haven
    {
        public Haven(string naam)
        {
            Naam = naam;
        }

        private string _Naam;
        private Validations Validaties = new Validations();

        public string Naam
        {
            get { return _Naam; }
            set { _Naam = (value.Length >= Validaties.mincharsHavenNaam) ? value : throw new ArgumentException($"De minimum lengte van een havennaam is {Validaties.mincharsHavenNaam} karakters"); }
        }

    }
}
