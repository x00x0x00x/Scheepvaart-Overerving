using System.Collections.Generic;

namespace ScheepvaartCL
{
    public class Traject
    {
        public Traject(List<Haven> havens)
        {
            Havens = havens;
        }

        public List<Haven> Havens { get; set; }
    }
}
