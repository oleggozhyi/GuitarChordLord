using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuitarChords.Core;

namespace GuitarChordLord.Design
{
    class DesignChordService : IChordService
    {
        public IEnumerable<NoteName> NoteNames
        {
            get { return NoteName.NoteNames; }
        }

        public IEnumerable<Chord> GetChords(NoteName name)
        {
            string s = @"IV
E|---|---|-x-|---|
B|---|---|---|---|
G|---|---|-x-|---|
D|-x-|---|---|---|
A|---|---|-x-|---|
E|---|---|---|---|";

            var fingering = Fingering.Parse(s);
            var chord1 = new Chord
                        {
                            RootNote = name,
                            Name = name.Name,
                            Fingerings = new Fingering[]
                                         {
                                            fingering,
                                            fingering,
                                            fingering,
                                         }
                        };

            var chord2 = new Chord
            {
                RootNote = name,
                Name = name.Name + "m",
                Fingerings = new Fingering[]
                                         {
                                            fingering,
                                            fingering,
                                            fingering,
                                         }
            };

            return new[] { chord1, chord2 };
        }
    }
}
