using System;

namespace ScheepvaartCL.configurations
{
    public class Validations
    {
        public Decimal minimumCargowaarde = 0;
        public int minimumContainers = 10;
        public Decimal minimumVolumeInLiter = 100;
        public int mincharsHavenNaam = 4;
        public int minimumAantalPassagiers = 0;
        public int mincharsSchipNaam = 5;
        public int minCharsVlootNaam = 5;
        public int minCharsRederijNaam = 5;
        public Decimal minBreedteSchip = 0;
        public Decimal minLengteSchip = 0;
        public Decimal minTonnageSchip = 0;
        public int fixedAantalHavensVeerbootTraject = 2;
        public int minAantalTrucksRoRo = 0;
    }
}
