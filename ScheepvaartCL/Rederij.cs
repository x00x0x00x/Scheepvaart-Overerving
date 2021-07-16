using System;
using System.Collections.Generic;
using ScheepvaartCL.configurations;

namespace ScheepvaartCL
{
    public class Rederij
    {
        private string _naam;
        private Validations Validaties = new Validations();
        private Writer Writer = new Writer();

        private Dictionary<string, Vloot> _vloten = new Dictionary<string, Vloot>(); // <
        private List<Haven> _havens = new List<Haven>(); // <

        // de rederij alsmede de vloot klasse bevat een lijst met schepen, aangezien het Schip een veld Vloot heeft kan een schip dus ook bestaan zonder aan een vloot toegekend te zijn
        // een schip kan bestaan zonder aan een vloot toegewezen te zijn
        private List<Schip> _schepen = new List<Schip>();

        #region ctor / properties
        public Rederij(string naam)
        {
            Naam = naam;
        }

        public string Naam
        {
            get { return _naam; }
            set { _naam = (value.Length >= Validaties.minCharsRederijNaam) ? value : throw new ArgumentException($"De minimum lengte voor de naam van een rederij is {Validaties.minCharsRederijNaam} karakters."); }
        }

        // stelt enkele privates beschikbaar voor gebruik door Overzicht
        public List<Schip> Schepen { get { return _schepen; } }
        public Dictionary<string, Vloot> Vloten { get { return _vloten; } }
        public List<Haven> Havens { get { return _havens; } }

        #endregion

        #region methodes vloot / schip

        public void VoegVlootToe(Vloot vloot)
        {
            if (!_vloten.ContainsKey(vloot.Naam)) {
                _vloten.Add(vloot.Naam, vloot);
            }
        }

        // Dit heeft verdere gevolgen voor de schepen welke zich in de vloot bevinden (null ref, toegestaan dmv ?)
        public void VerwijderVloot(string vlootnaam)
        {

            if (_vloten.ContainsKey(vlootnaam))
            {
                Vloot geselecteerdeVloot = _vloten[vlootnaam];
                foreach (Schip s in geselecteerdeVloot.Schepen.Values) {
                    s.Vloot = null;
                }

                _vloten.Remove(vlootnaam);
            }
        }

        public Vloot? ZoekVloot(string vlootnaam)
        {
            foreach (string v in _vloten.Keys)
            {
                if (v == vlootnaam)
                {
                    return _vloten[v];
                }
            }

            return null;
        }

        public void TransferreerSchipVloot(Schip schip, Vloot targetVloot)
        {
            if (schip.Vloot != null)
            {
                schip.Vloot.VerwijderSchipUitVloot(schip);
                
            }

            targetVloot.VoegSchipToeAanVloot(schip);
        }
        #endregion

        #region methodes schip / rederij
        // Deze 2 methodes zijn wellicht ietwat overbodig maar laten toe om een overzicht van schepen te behouden zonder gedwongen te zijn deze te hoeven toewijzen aan een bepaalde vloot.
        // Bij voorkeur wordt deze methode gebruikt om Vloot.VoegSchipToeAanVloot uit te voeren
        public void VoegSchipToeAanRederij(Schip schip, Vloot? optioneleVloot=null)
        {
            bool found = false;
            // eventuele refactoring mogelijk van _schepen naar dictionary met controle op naam of het schip al bestaat in de rederij
            foreach (Schip s in _schepen)
            {
                if (s.Naam == schip.Naam) { found = true; }
            }

            if (!found)
            {
                _schepen.Add(schip);
                if (optioneleVloot != null) { optioneleVloot.VoegSchipToeAanVloot(schip); }
            } else
            {
                throw new OperationCanceledException("Het schip bestaat reeds in de rederij.");
            }
        }

        // Bijbehorend aan bovenstaande methode, indien een rederij een schip niet meer kent wordt deze ook verwijdert uit de vloot.
        public void VerwijderSchipUitRederijEnVloot(Schip schip)
        {
            if (schip.Vloot != null)
            {
                schip.Vloot.VerwijderSchipUitVloot(schip);
            }

            _schepen.Remove(schip);
        }
        #endregion

        #region methodes haven 
        public void VoegHavenToe(Haven h)
        {
            bool found = false;

            if (_havens != null) // <
            {
                foreach (Haven haven in _havens)
                {
                    if (haven.Naam == h.Naam)
                    {
                        found = true;
                    }
                }
            }

            if (!found)
            {
                _havens.Add(h);
            }
        }

        public void VerwijderHaven(string naam)
        {
            foreach (Haven h in _havens)
            {
                if (h.Naam == naam)
                {
                    _havens.Remove(h);
                }
            }
        }
        #endregion

    }
}
