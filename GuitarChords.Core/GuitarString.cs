using System;
using System.Text;

namespace GuitarChords.Core
{
    public class GuitarString
    {
        public GuitarString(int number)
        {
            Number = number;
        }

        public int Number { get; set; }
        public bool IsMuted { get; set; }
        public int RelativeFret { get; set; }
        public int OptionalRelativeFret { get; set; }
        public int AnsoluteFret { get; set; }
        
        public override string ToString()
        {
            const string dashes = "-";
            var sb = new StringBuilder("|");
            for (int i = 1; i <= 4; i++)
            {
                if (OptionalRelativeFret == i)
                    sb.Append("(x)").Append("|");
                else
                    sb.Append(dashes).Append(RelativeFret == i ? "x" : "-").Append(dashes).Append("|");
            }
            return sb.ToString();
        }
    }
}