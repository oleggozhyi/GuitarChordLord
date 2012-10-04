using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarChords.Core
{
    public struct Note : IComparable<Note>
    {
        #region Fields

        private readonly int _note;
        private const double C0Frequency = 16.352;

        #endregion

        #region ctor

        public Note(int note)
        {
            _note = note;
        }

        #endregion

        #region Properties

        public int OffsetFromC0
        {
            get { return _note; }
        }

        public double Frequency
        {
            get { return C0Frequency*Math.Pow(2, _note/12d); }
        }

        #endregion

        #region Operators

        public static explicit operator Note(int note)
        {
            return new Note(note);
        }

        public  static Interval operator-(Note note1, Note note2)
        {
            return new Interval(note1, note2);
        }

        public static Note operator -(Note note1, int pitch)
        {
            return new Note(note1.OffsetFromC0 - pitch);
        }

        public static Note operator +(Note note1, int pitch)
        {
            return new Note(note1.OffsetFromC0 + pitch);
        }

        public static Chord operator +(Note note1, Note note2)
        {
            return new Chord();
        }

        public static bool operator== (Note note1, Note note2)
        {
            return note1.Equals(note2);
        }

        public static bool operator !=(Note note1, Note note2)
        {
            return !(note1 == note2);
        }

        #endregion

        public int CompareTo(Note other)
        {
            return OffsetFromC0.CompareTo(other.OffsetFromC0);
        }

        public bool Equals(Note other)
        {
            return _note == other._note;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Note && Equals((Note) obj);
        }

        public override int GetHashCode()
        {
            return _note;
        }

        public override string ToString()
        {
            return Octave.GetNoteString(this);
        }

        public string ToString(bool withoutOctave)
        {
            return ToString().Split('(')[0];
        }
    }
}
