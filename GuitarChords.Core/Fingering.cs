using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuitarChords.Core.Helpers;

namespace GuitarChords.Core
{
    public class Fingering
    {
        public Fingering(IList<GuitarString> strings, int startingFret)
        {
            if (strings.Count != 6)
                throw new ArgumentException("Only 6-string guitar are supported");

            Strings = strings;
            StartingFret = startingFret;
        }

        public IList<GuitarString> Strings { get; set; }

        public int StartingFret { get; set; }

        public Chord GetChord(GuitarSystem guitarSystem)
        {
            var notes = Strings.Where(s => !s.IsMuted).Select(guitarSystem.GetNote).ToArray();
            return new Chord(notes);
        }

        public Chord GetChord()
        {
            return GetChord(GuitarSystem.Standard);
        }

        public override string ToString()
        {
            return ToString(GuitarSystem.Standard);
        }

        public string ToString(GuitarSystem guitarSystem)
        {
            var sb = new StringBuilder();
            sb.Append(StartingFret.ToRomanNumber()).AppendLine();
            foreach (var guitarString in Strings)
            {
                string note = guitarString.IsMuted ? "X" :
                                                        guitarSystem.GetUnclambedNote(guitarString).ToString(true);
                sb.Append(note)
                  .Append(guitarString)
                  .AppendLine();
            }
            return sb.ToString().Trim();
        }

        public static Fingering Parse(string s)
        {
            try
            {
                string regexPattern = @"";
                string[] strings = s.Split('\n');
                int offset = strings[0].Trim().ToArabicNumber();
                var guitarStrings = new List<GuitarString>();
                for (int i = 1; i <= 6; i++)
                {
                    var guitarString = ParseString(strings[i], i, offset);
                    guitarStrings.Add(guitarString);
                }
                return new Fingering(guitarStrings, offset);
            }
            catch (Exception ex)
            {
                throw new FormatException("Wrong fingering format", ex);
            }

        }

        private static GuitarString ParseString(string s, int number, int startingFret)
        {
            try
            {
                var guitarString = new GuitarString(number);
                if (s.StartsWith("X", StringComparison.OrdinalIgnoreCase))
                    guitarString.IsMuted = true;
                else
                {
                    string[] frets = s.Split('|').Skip(1).ToArray();
                    for (int i = 0; i < frets.Length; i++)
                    {

                        if (frets[i].ToUpper() == "-X-")
                        {
                            guitarString.RelativeFret = i + 1;
                            guitarString.AnsoluteFret = startingFret + guitarString.RelativeFret;
                        }
                        else if (frets[i].ToUpper() == "(X)")
                            guitarString.OptionalRelativeFret = i + 1;
                    }
                }
                return guitarString;
            }
            catch (Exception ex)
            {
                throw new FormatException("Wrong string format", ex);
            }
        }
    }
}
