using System;

namespace GuitarChords.Core
{
    public class FingeringBuiler
    {
        private readonly int _startingFret;
        private int _previousString;
        private readonly GuitarString[] _strings = new GuitarString[6];

        public FingeringBuiler(int startingFret)
        {
            _startingFret = startingFret;
        }

        public FingeringBuiler AddString(int number)
        {
            _previousString = number;
            _strings[number - 1] = new GuitarString(number);
            return this;
        }
        
        public  FingeringBuiler Muted()
        {
            if (_previousString < 1)
                throw new ArgumentException();

            _strings[_previousString - 1].IsMuted = true;
            _previousString = -1;
            return this;
        }

        public FingeringBuiler Open()
        {
            return ClumbedOnFret(0);
        }

        public FingeringBuiler ClumbedOnFret(int fret)
        {
            if (fret < 1 && fret > 24)
                throw new ArgumentException();
            if (_previousString < 1)
                throw new InvalidOperationException();

            _strings[_previousString - 1].RelativeFret = fret;
            _strings[_previousString - 1].AnsoluteFret = fret + _startingFret -1;
            return this;
        }

        public FingeringBuiler OptionallyClumbedOnFret(int fret)
        {
            if (fret < 1 && fret > 24)
                throw new ArgumentException();
            if (_previousString < 1)
                throw new InvalidOperationException();

            _strings[_previousString - 1].OptionalRelativeFret = fret;
            return this;
        }


        public Fingering Build()
        {
            return  new Fingering(_strings, _startingFret);
        }
    }
}