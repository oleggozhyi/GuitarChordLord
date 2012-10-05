﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarChords.Core
{
    public interface IChordService
    {
        IEnumerable<NoteName> NoteNames { get; }
        IEnumerable<Chord> GetChords(NoteName name);
    }
}