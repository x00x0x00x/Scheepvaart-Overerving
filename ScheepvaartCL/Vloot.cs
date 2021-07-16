using System;
using System.Collections.Generic;
using ScheepvaartCL.configurations;

namespace ScheepvaartCL
{
    public class Vloot
    {
        private Validations Validaties = new Validations();

        private Dictionary<string, Schip> _schepen = new Dictionary<string, Schip>();
        public Dictionary<string, Schip> Schepen => _schepen;

        private string _naam;

        public Vloot(string naam)
        {
            Naam = naam;
        }

        public string Naam
        {
            get { return _naam; }
            set { _naam = (value.Length > Validaties.minCharsVlootNaam) ? value : throw new ArgumentException($"Het minimum aantal karakters voor een vlootnaam is {Validaties.minCharsVlootNaam}."); }
        }


        public void VoegSchipToeAanVloot(Schip schip)
        {
            // Deze null check controleert of een schip al toebehoort aan een andere vloot, indien dat het geval is zal van Rederij.TransfereerSchipVloot of Vloot.VerwijderSchip
            // gebruik gemaakt moeten worden
            // Een alternatief zou kunnen zijn om Schip.Vloot.VerwijderSchip aan te roepen, echter zou deze operatie verborgen zijn voor de eindgebruiker en tot verrassingen kunnen leiden.
            if (schip.Vloot == null)
            {
                _schepen.Add(schip.Naam, schip);
                schip.Vloot = this;
            } else
            {
                throw new OperationCanceledException("Schip bestaat reeds in een andere vloot, verwijder deze hieruit of transferreer hem naar deze vloot.");
            }
        }

        public void VerwijderSchipUitVloot(Schip schip)
        {
            if (_schepen.ContainsKey(schip.Naam))
            {
                _schepen.Remove(schip.Naam);
                schip.Vloot = null;
            } else
            {
                throw new OperationCanceledException("Schip kon niet gevonden worden in deze vloot.");
            }
        }

        public Schip? ZoekSchip(string schipnaam)
        {
            if (_schepen.ContainsKey(schipnaam))
            {
                return _schepen[schipnaam]; 
            }

            return null;
        }

        // void
        public Dictionary<string, Schip> OverzichtSchepen()
        {
            return _schepen;
        }
    }
}
