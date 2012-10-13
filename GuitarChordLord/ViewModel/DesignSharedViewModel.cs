using System;
using System.Collections.Generic;
using System.Linq;
using GuitarChords.Core;

namespace GuitarChordLord.ViewModel
{
    public class DesignSharedViewModel
    {

        public IEnumerable<ChordsItemViewModel> GetChords(NoteName name)
        {
            string s = @"IV
E|---|---|-x-|---|
B|---|---|---|---|
G|---|---|-x-|---|
D|-x-|---|---|---|
A|---|---|-x-|---|
E|---|---|---|---|";



            var fingering = Fingering.Parse(s);

            Func<string, ChordsItemViewModel> createChord = str => new ChordsItemViewModel(new Chord
                                                                                           {
                                                                                               RootNote = name,
                                                                                               Name = name.Name + str,
                                                                                               Fingerings = new[]
                                                                                                            {
                                                                                                                fingering
                                                                                                                ,
                                                                                                                fingering
                                                                                                                ,
                                                                                                                fingering
                                                                                                                ,
                                                                                                            }
                                                                                           });
            return new[]
                   {
                       createChord(""), createChord("m"), createChord("7"), createChord("m7"), createChord("9"),
                       createChord("6"), createChord("sus4")
                   };

        }

        public IEnumerable<ChordsGroupViewModel> ChordsGroups
        {
            get
            {

                return from n in NoteName.NoteNames
                       select new ChordsGroupViewModel
                              {
                                  Root = n,
                                  Chords = GetChords(n).ToArray()
                              };
            }
        }

        public IEnumerable<ChordsItemViewModel> Chords
        {
            get { return Enumerable.Range(1, 10).SelectMany(_ => GetChords(NoteName.GetNote("C"))); }
        }
    }
}
