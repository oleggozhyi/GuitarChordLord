using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarChords.Core
{
    public class NoteName
    {
        private static readonly Dictionary<string, NoteName> _noteNames = new Dictionary<string, NoteName>(StringComparer.OrdinalIgnoreCase)
        {
            {"C", new NoteName("C")},
            {"C#", new NoteName("C#", "Db")},
            {"D", new NoteName("D")},
            {"D#", new NoteName("D#", "Eb")},
            {"E", new NoteName("E")},
            {"F", new NoteName("F")},
            {"F#", new NoteName("F#", "Gb")},
            {"G", new NoteName("G")},
            {"G#", new NoteName("G#", "Ab")},
            {"A", new NoteName("A")},
            {"A#", new NoteName("A#", "Bb")},
            {"B", new NoteName("B")},    
        };

        public static IEnumerable<NoteName> NoteNames
        {
            get { return _noteNames.Values; }
        }

        public static NoteName GetNote(string note)
        {
            return _noteNames[note];
        }

        private NoteName(string name, string altName = "")
        {
            Name = name;
            AlternativeName = altName;
        }

        public string Name { get; private set; }
        public string AlternativeName { get; private set; }

        public bool IsNatural
        {
            get { return Name.Length == 1; }
        }

        #region Equality members

        protected bool Equals(NoteName other)
        {
            return string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NoteName)obj);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }

        public static bool operator ==(NoteName left, NoteName right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(NoteName left, NoteName right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}
