using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using FluentAssertions;

namespace GuitarChords.Core.Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void A4_Should_Be_400_Hz()
        {
            Note note = Octave.Octaves[4]["A"];

            note.Frequency.Should().BeApproximately(440d, 0.1);
        }

        [TestMethod]
        public void Test_Fingering_Builder_AndFingering_To_String()
        {
            var fingering = new FingeringBuiler(1)
                                      .AddString(6).Muted()
                                      .AddString(5).ClumbedOnFret(2)
                                      .AddString(4).ClumbedOnFret(2)
                                      .AddString(3).ClumbedOnFret(1)
                                      .AddString(2).Open().OptionallyClumbedOnFret(3)
                                      .AddString(1).Open()
                                  .Build();
            fingering.ToString().Should().Be(@"I
E|---|---|---|---|
B|---|---|(x)|---|
G|-x-|---|---|---|
D|---|-x-|---|---|
A|---|-x-|---|---|
X|---|---|---|---|");

            Chord chord = fingering.GetChord();

            chord.ToString().Should().Be("B(2) | E(3) | G#(3) | B(3) | E(4)");
        }

        [TestMethod]
        public void Parse_Fingering1()
        {
            string s = @"I
E|---|---|---|---|
B|---|---|(x)|---|
G|-x-|---|---|---|
D|---|-x-|---|---|
A|---|-x-|---|---|
X|---|---|---|---|";

            var fingering = Fingering.Parse(s);

            fingering.ToString().Should().Be(s);
        }

        [TestMethod]
        public void Parse_Fingering2()
        {
            string s = @"IV
E|---|---|-x-|---|
B|---|---|---|---|
G|---|---|-x-|---|
D|-x-|---|---|---|
A|---|---|-x-|---|
E|---|---|---|---|";

            var fingering = Fingering.Parse(s);

            fingering.ToString().Should().Be(s);
        }

        [TestMethod]
        public void Parse_Fingering3()
        {
            string s0 = @"VIII
E|-x-|---|---|---|
B|-x-|---|---|---|
G|-x-|-x-|---|---|
D|-x-|---|-x-|---|
A|-x-|---|-x-|---|
E|-x-|---|---|---|";
            string s1 = @"VIII
E|-x-|---|---|---|
B|-x-|---|---|---|
G|---|-x-|---|---|
D|---|---|-x-|---|
A|---|---|-x-|---|
E|-x-|---|---|---|";

            var fingering = Fingering.Parse(s0);

            fingering.ToString().Should().Be(s1);
        }
    }
}
