using System;
using System.Text;

namespace ScheepvaartCL.configurations
{
    public class Writer
    {

        private static string PreSuffix { get; set; }
        private static int startSegmentLen { get; set; }
        private static int sideWidth { get; set; }

        public Writer()
        {
            PreSuffix = "█";
            startSegmentLen = 99;
            sideWidth = 4;
        }

        public void lijnSegment(string t, Boolean isTitel=false)
        {
            // hoofding open
            if (isTitel)
            {
                this.lijnSegment("");
                this.lijnSegment(" ");
            }

            // content
            StringBuilder L = new StringBuilder(startSegmentLen);

            int PreSuffLen = (int)Math.Ceiling(((double)startSegmentLen - (double)t.Length) / (double)2);
            int vooraan = PreSuffLen;
            int achteraan = ((PreSuffLen % 2) == 0) ? PreSuffLen -1 : PreSuffLen;
            string filler = " ";

            if (t.Length == 0) { filler = "█";  }

            for (int i=0; i<vooraan; i++)
            {
                if(i < sideWidth) { L.Append(PreSuffix); } 
                else
                {
                    L.Append(filler);
                }
            }

            L.Append(t);

            for(int i=0; i<achteraan; i++)
            {
                if((achteraan - i) <= sideWidth) { L.Append(PreSuffix); } 
                else
                {
                    L.Append(filler);
                }
            }

            Console.WriteLine(L.ToString());

            // hoofding sluiting
            if (isTitel)
            {
                this.lijnSegment(" ");
                this.lijnSegment("");
                this.lijnSegment(" ");
            }
        }

        public void eindeOverzicht()
        {
            this.lijnSegment(" ");
            this.lijnSegment("");
            Console.WriteLine(" ");
        }

    }

}
