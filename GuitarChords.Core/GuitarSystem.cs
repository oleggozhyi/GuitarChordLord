using System;

namespace GuitarChords.Core
{
    public class GuitarSystem
    {
        public int Offset { get; set; }
        public static readonly GuitarSystem Standard = new GuitarSystem(0);

        public Note[] Notes { get; private set; }

        public GuitarSystem(int offset)
        {
            Offset = offset;
            Notes = new Note[]
                    {
                        Octave.Octaves[4]["E"] + offset,
                        Octave.Octaves[3]["B"] + offset,
                        Octave.Octaves[3]["G"] + offset,
                        Octave.Octaves[3]["D"] + offset,
                        Octave.Octaves[2]["A"] + offset,
                        Octave.Octaves[2]["E"] + offset,
                    };
        }

        public Note GetNote(GuitarString @string)
        {
            if (@string.IsMuted)
                throw new ArgumentException("String is muted");

            int fret = @string.AnsoluteFret + Offset;
            Note note = Notes[@string.Number -1] + fret;

            return note;
        }

        public Note GetUnclambedNote(GuitarString @string)
        {
            Note note = Notes[@string.Number - 1];
            return note;
        }
    }
}