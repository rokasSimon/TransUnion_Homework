using System;
using System.Collections.Generic;
using System.Text;

namespace Encryption
{
    public static class CaesarCipher
    {
        // Stores range start, end and length
        // Assumtion that all characters are continuous and in alphabetical order in these ranges
        // Static variable for simplicity
        private static readonly List<(char, char, int)> _alphabetRanges = new()
        {
            ('A', 'Z', 'Z' - 'A' + 1),
            ('a', 'z', 'z' - 'a' + 1),
            ('ぁ', 'ゞ', 'ゞ' - 'ぁ' + 1)
        };

        // Encodes a string using Caesar shift and the predefined _alphabetRanges variable
        public static string Encode(string text, int shift)
        {
            if (text is null)
                return null;

            if (shift == 0)
                return text;

            StringBuilder shiftedText = new(text.Length);

            foreach (char c in text)
            {
                shiftedText.Append(CaesarShift(c, shift));
            }

            return shiftedText.ToString();
        }

        // Does Caesar shift on a single character based on predefined ranges, should work with any Unicode character
        private static char CaesarShift(char c, int shift)
        {
            Tuple<char, char, int> range = FindCharacterRange(c);

            if (range == null)
            {
                return c;
            }

            var (startOffset, endOffset, len) = range;

            int normShift = NormalizeShift(shift, len);

            // Only two cases: looping around or just shifting right
            if (c + normShift > endOffset)
            {
                char sc = (char)(startOffset + c + normShift - endOffset - 1);

                return sc;
            }
            else
            {
                return (char)(c + normShift);
            }
        }

        // Finds which predefined range given character belongs to, works as long as the ranges are continuous
        private static Tuple<char, char, int> FindCharacterRange(char c)
        {
            foreach (var (start, end, len) in _alphabetRanges)
            {
                if (start <= c && c <= end)
                {
                    return new Tuple<char, char, int>(start, end, len);
                }
            }

            return null;
        }

        // Turn all left shifts into equivalent right shifts and reduce shift into alphabet range
        private static int NormalizeShift(int shift, int rangeLength)
        {
            if (shift < 0)
            {
                return rangeLength + (shift % rangeLength);
            }
            else
            {
                return shift % rangeLength;
            }
        }

        // Reverses Caesar shift
        public static string Decode(string text, int shift)
        {
            return Encode(text, -shift);
        }
    }
}
