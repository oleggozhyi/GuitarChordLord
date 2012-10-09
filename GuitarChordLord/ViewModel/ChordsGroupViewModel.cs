using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using GalaSoft.MvvmLight;
using GuitarChords.Core;

namespace GuitarChordLord.ViewModel
{
    [DebuggerDisplay("{GroupName}")]
    public class ChordsGroupViewModel : ViewModelBase
    {
        public NoteName Root { get; set; }
        public string GroupName
        {
            get { return GetChordGroupTitle(Root); }
        }

        public ChordsItemViewModel[] Chords { get; set; }
        public ChordsItemViewModel[] LimitedChordsList
        {
            get { return Chords; }
        }

        private static string GetChordGroupTitle(NoteName noteName)
        {
            string note = noteName.IsNatural ? noteName.Name : string.Format("{0}({1})", noteName.Name, noteName.AlternativeName);
            return note + " Chords";
        }

    }
}