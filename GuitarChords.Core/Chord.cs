using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarChords.Core
{
    public class Chord
    {
        public NoteName RootNote { get; set; }
        public string Name { get; set; }
        public Fingering[] Fingerings { get; set; }
    }
}
