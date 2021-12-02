using Encryption;
using NUnit.Framework;

namespace CaesarCipherTests
{
    [TestFixture]
    public class CaesarCipher_Decode
    {
        [TestCase("QEB NRFZH YOLTK CLU GRJMP LSBO QEB IXWV ALD", 23, "THE QUICK BROWN FOX JUMPS OVER THE LAZY DOG")]
        [TestCase("b-Bb-B", 1, "a-Aa-A")]
        [TestCase("qqq", 3000000, "aaa")]
        public void CaesarCipherDecode_ShiftIsPositive_ReturnRightShifted(string text, int shift, string expected)
        {
            string result = CaesarCipher.Decode(text, shift);

            Assert.AreEqual(expected, result);
        }

        [TestCase("THE QUICK BROWN FOX JUMPS OVER THE LAZY DOG", 0, "THE QUICK BROWN FOX JUMPS OVER THE LAZY DOG")]
        [TestCase("---a", 0, "---a")]
        public void CaesarCipherDecode_ShiftIsUnsigned_ReturnEqual(string text, int shift, string expected)
        {
            string result = CaesarCipher.Decode(text, shift);

            Assert.AreEqual(expected, result);
        }

        [TestCase("SGD PTHBJ AQNVM ENW ITLOR NUDQ SGD KZYX CNF", -1, "THE QUICK BROWN FOX JUMPS OVER THE LAZY DOG")]
        [TestCase("~`!1@2#3$4%5^6&7*8(9)0_-+=zab", -27, "~`!1@2#3$4%5^6&7*8(9)0_-+=abc")]
        public void CaesarCipherDecode_ShiftIsNegative_ReturnLeftShifted(string text, int shift, string expected)
        {
            string result = CaesarCipher.Decode(text, shift);

            Assert.AreEqual(expected, result);
        }

        [TestCase("", 1, "")]
        public void CaesarCipherDecode_TextIsEmpty_ReturnEmpty(string text, int shift, string expected)
        {
            string result = CaesarCipher.Decode(text, shift);

            Assert.AreEqual(expected, result);
        }

        [TestCase(null, 0, null)]
        public void CaesarCipherDecode_TextIsNull_ReturnNull(string text, int shift, string expected)
        {
            string result = CaesarCipher.Decode(text, shift);

            Assert.AreEqual(expected, result);
        }
    }
}
