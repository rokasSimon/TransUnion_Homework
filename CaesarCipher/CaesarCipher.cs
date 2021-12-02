using System.Text;

namespace Encryption
{
    public static class CaesarCipher
    {
        // Only for documentation purposes and alphabet length
        private static readonly string _alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static string Encode(string text, int shift)
        {
            if (text is null)
            {
                return null;
            }

            if (shift == 0)
            {
                return text;
            }

            // Turn all left shifts into equivalent right shifts and reduce shift into alphabet range
            if (shift < 0)
            {
                shift = _alphabet.Length + (shift % _alphabet.Length);
            }
            else
            {
                shift %= _alphabet.Length;
            }

            StringBuilder shiftedText = new(text.Length);

            foreach (char c in text)
            {
                char startOffset;
                char endOffset;

                // Find character range
                if ('A' <= c && c <= 'Z')
                {
                    startOffset = 'A';
                    endOffset = 'Z';
                }
                else if ('a' <= c && c <= 'z')
                {
                    startOffset = 'a';
                    endOffset = 'z';
                }
                else
                {
                    shiftedText.Append(c);
                    continue;
                }

                // Only two cases: looping around or just shifting right
                if (c + shift > endOffset)
                {
                    char sc = (char)(startOffset + c + shift - endOffset - 1);

                    shiftedText.Append(sc);
                }
                else
                {
                    shiftedText.Append((char)(c + shift));
                }
            }

            return shiftedText.ToString();
        }

        public static string Decode(string text, int shift)
        {
            return Encode(text, -shift);
        }
    }
}
