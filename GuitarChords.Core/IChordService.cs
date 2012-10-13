using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarChords.Core
{
    public interface IChordService
    {
        NoteName SelectedRoot { get; set; }
        Chord SelectedChord { get; set; }
        IEnumerable<NoteName> NoteNames { get; }
        IEnumerable<Chord> GetChords(NoteName name);
    }
}
