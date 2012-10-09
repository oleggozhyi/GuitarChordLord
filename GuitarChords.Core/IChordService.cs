using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarChords.Core
{
    public interface IChordService
    {
        NoteName SelectedRoot { get; }
        Chord SelectedChord { get; }
        IEnumerable<NoteName> NoteNames { get; }
        Task<IEnumerable<Chord>> GetChordsAsync(NoteName name);
    }
}
