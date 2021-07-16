using System;
using ScheepvaartCL;
using ScheepvaartCL.configurations;
using System.Collections.Generic;
using System.Linq;

public class Overzicht
{
	private Rederij _rederij;
	private Writer Writer = new Writer();

    // kan eventueel uitgebreid worden met nullable rederij/vloot/schip
	public Overzicht(Rederij r)
	{
		_rederij = r;
	}

    public void HavensAlfabetisch()
    {
        SortedSet<string> havensAlfabetisch = new SortedSet<string>();

        foreach (Haven haven in _rederij.Havens)
        {
            havensAlfabetisch.Add(haven.Naam);
        }

        Writer.lijnSegment("Alfabetische lijst havens", true);
        foreach (string haven in havensAlfabetisch)
        {
            Writer.lijnSegment(haven);
        }
        Writer.eindeOverzicht();
    }

    public void AantalPassagiers(Vloot? optioneleVloot = null)
    {
        int totaalPassagiers = 0;
        List<Schip> tempSchepen;

        if (optioneleVloot != null)
        {
            Writer.lijnSegment($"Overzicht passagiers in vloot '{optioneleVloot.Naam}'");
            tempSchepen = new List<Schip>();
            foreach (Schip s in optioneleVloot.Schepen.Values)
            {
                tempSchepen.Add(s);
            }
        }
        else
        {
            Writer.lijnSegment($"Passagiers uit Rederij '{_rederij.Naam}' ", true);
            tempSchepen = _rederij.Schepen;
        }

        foreach (Schip s in tempSchepen)
        {
            if (s is Passagierschip)
            {
                Passagierschip ps = (Passagierschip)s;
                Writer.lijnSegment($"{s.Naam}: {ps.AantalPassagiers} passagiers");
                totaalPassagiers += ps.AantalPassagiers;
            }
        }

        Writer.lijnSegment($"Totaal aantal passagiers: {totaalPassagiers}");
        Writer.eindeOverzicht();
    }

    // eval: had gebruik kunnen maken van vloot.gettonnage voor verkorte code
    public void TonnagePerVloot()
    {
        Writer.lijnSegment("Tonnage per vloot", true);
        Decimal totaalTonnage = 0.0M;

        SortedDictionary<Decimal, List<Vloot>> vlotenMetTonnage = new SortedDictionary<Decimal, List<Vloot>>();
        foreach (Vloot v in _rederij.Vloten.Values)
        {
            Decimal totaalTng = 0;
            foreach (Schip s in v.Schepen.Values)
            {
                totaalTng += s.Tonnage;
            }

            if (vlotenMetTonnage.ContainsKey(totaalTng))
            {
                vlotenMetTonnage[totaalTng].Add(v);
            }
            else
            {
                vlotenMetTonnage.Add(totaalTng, new List<Vloot>() { v });
            }
        }

        foreach (KeyValuePair<Decimal, List<Vloot>> entry in vlotenMetTonnage.Reverse())
        {
            foreach (Vloot v in entry.Value)
            {
                Writer.lijnSegment($"{v.Naam}: {entry.Key} ton");
                totaalTonnage += entry.Key;
            }
        }

        Writer.lijnSegment($"Totaal tonnage: {totaalTonnage}");
        Writer.eindeOverzicht();
    }

    public void GlobaleCargowaarde()
    {
        Decimal totaleWaarde = 0M;

        foreach (Schip s in _rederij.Schepen)
        {
            if (s is Vrachtschip)
            {
                Vrachtschip vs = (Vrachtschip)s;
                totaleWaarde += vs.Cargowaarde;
            }
        }

        Writer.lijnSegment("Totale cargowaarde van alle schepen ", true);
        Writer.lijnSegment($"{totaleWaarde.ToString("#,##0.00")} EUR");
        Writer.eindeOverzicht();
    }

    public void GlobaalVolumeTankers()
    {
        Decimal totaalVolume = 0;

        Writer.lijnSegment("Volume in liters", true);
        foreach (Schip s in _rederij.Schepen)
        {
            if (s is Tanker)
            {
                Tanker ns = (Tanker)s;
                Writer.lijnSegment($"{ns.Naam}:  {ns.VolumeInLiter} liter");
                totaalVolume += ns.VolumeInLiter;
            }
        }
        Writer.lijnSegment($"Totaal volume:  {totaalVolume} liter");
        Writer.eindeOverzicht();
    }

    public void BeschikbareSleepboten()
    {
        Writer.lijnSegment("Overzicht beschikbare sleepboten", true);
        foreach (Schip s in _rederij.Schepen)
        {
            if (s is Sleepboot)
            {
                Writer.lijnSegment($"Sleepboot {s.Naam} is beschikbaar en weegt {s.Tonnage} ton.");
            }
        }

        Writer.eindeOverzicht();
    }
}
