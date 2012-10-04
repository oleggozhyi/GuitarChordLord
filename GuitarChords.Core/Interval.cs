using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarChords.Core
{
    public class Interval
    {
        public Note Note1 { get; private set; }
        public Note Note2 { get; private set; }

        public Interval(Note note1, Note note2)
        {
            Note1 = note1;
            Note2 = note2;
        }
    }
}
