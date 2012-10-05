using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarChords.Core
{
    public class ChordNotes
    {
        public Note[] Notes { get; set; }
            
        public ChordNotes(params Note[] notes)
        {
            Notes = notes.OrderBy(n => n).ToArray();
        }

        public override string ToString()
        {
            string chord = String.Join(" | ", Notes.Select(n => n.ToString()));
            return chord;
        }
    }
}
