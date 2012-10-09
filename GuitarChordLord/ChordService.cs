using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using GuitarChords.Core;
using Windows.Foundation;
using Windows.Storage;

namespace GuitarChordLord
{
    public class ChordService : IChordService
    {
        private Dictionary<NoteName, List<Chord>> _chordsDic;

        public NoteName SelectedRoot { get; private set; }

        public Chord SelectedChord { get; private set; }

        public IEnumerable<NoteName> NoteNames
        {
            get { return NoteName.NoteNames; }
        }
        public async Task<IEnumerable<Chord>> GetChordsAsync(NoteName name)
        {
            if (_chordsDic == null)
            {
                await Task.Run(() => ParseChords());
            }
            return await Task.FromResult(_chordsDic[name]);
        }

        private void ParseChords()
        {
            _chordsDic = new Dictionary<NoteName, List<Chord>>();
            Assembly assembly = typeof(ChordService).GetTypeInfo().Assembly;
            Stream xmlStream = assembly.GetManifestResourceStream("GuitarChordLord.Resources.chords2_with_Notes.xml");
            var xDoc = XDocument.Load(xmlStream);
            foreach (var chordElement in xDoc.Root.Elements())
            {
                var chord = ParseChord(chordElement);
                if (!_chordsDic.ContainsKey(chord.RootNote))
                    _chordsDic[chord.RootNote] = new List<Chord>();

                _chordsDic[chord.RootNote].Add(chord);
            }
        }

        private Chord ParseChord(XElement chordElement)
        {
            var chordName = chordElement.Attribute("name").Value;
            return new Chord
                   {
                       Name = chordName,
                       RootNote = GetRootNoteFromChordName(chordName),
                       Fingerings = chordElement.Elements("fingering")
                                                .Select(e => Fingering.Parse(e.Value))
                                                .ToArray()
                   };
        }

        private NoteName GetRootNoteFromChordName(string chordName)
        {
            if (chordName.Length == 1 || chordName[1] != '#')
                return NoteName.GetNote(chordName[0].ToString());

            return NoteName.GetNote(chordName.Substring(0, 2));
        }
    }
}