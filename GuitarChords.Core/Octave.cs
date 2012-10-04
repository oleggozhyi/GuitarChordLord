using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarChords.Core
{
    public class Octave
    {
        #region Fields


        private static IDictionary<string, int> NoteToOffsetMapping =
            new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"C", 0},
                {"C#", 1},
                {"Db", 1},
                {"D", 2},
                {"D#", 3},
                {"Eb", 3},
                {"E", 4},
                {"F", 5},
                {"F#", 6},
                {"Gb", 6},
                {"G", 7},
                {"G#", 8},
                {"Ab", 8},
                {"A", 9},
                {"A#", 10},
                {"Bb", 10},
                {"B", 11},
            };


        #endregion

        #region ctors

        private Octave(int offset)
        {
            Number = offset;
        }

        static Octave()
        {
            InitializeOctaves();
        }

        #endregion

        #region  Properties

        public int Number { get; private set; }

        public static Octave GetOctave(Note note)
        {
            return Octaves[note.OffsetFromC0 / 12];
        }


        public  static  string GetNoteString(Note note)
        {
            Octave octave = GetOctave(note);
            int n = note.OffsetFromC0 % 12;
            string noteString = NoteToOffsetMapping.First(p => p.Value == n).Key + "(" + octave.Number + ")";
            return noteString;
        }


        public static Octave[] Octaves { get; private set; }

        //public static Octave SubContraOctave { get; private set; }
        //public static Octave ContraOctave { get; private set; }
        //public static Octave GreatOctave { get; private set; }
        //public static Octave SmallOctave { get; private set; }
        //public static Octave OneLineOctave { get; private set; }
        //public static Octave TwoLineOctave { get; private set; }
        //public static Octave ThreeLineOctave { get; private set; }
        //public static Octave FourLineOctave { get; private set; }
        //public static Octave FiveLineOctave { get; private set; }

        #endregion

        public Note this[string note]
        {
            get { return (Note)(NoteToOffsetMapping[note] + 12 * Number); }
        }

        #region Methods

        private static void InitializeOctaves()
        {
            Octaves = new Octave[8];
            for (int i = 0; i < Octaves.Length; i++)
            {
                Octaves[i] = new Octave(i);
            }
        }

        #endregion

    }
}
