namespace ScheepvaartCL
{
    public class Cruiseschip : Passagierschip
    {
        public Cruiseschip(decimal lengte, decimal breedte, decimal tonnage, string naam, Vloot? vloot, int aantalpassagiers, Traject traject) : base(lengte, breedte, tonnage, naam, vloot, aantalpassagiers)
        {
            Traject = traject;
        }

        // er wordt veronderstelt dat het traject zoals deze afgelegd wordt in de juiste volgorde wordt ingegeven
        public Traject Traject { get; set; }


    }
}
