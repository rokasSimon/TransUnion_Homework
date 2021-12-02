using NUnit.Framework;
using Encryption;

namespace CaesarCipherTests
{
    [TestFixture]
    public class CaesarCipher_Encode
    {
        [TestCase("THE QUICK BROWN FOX JUMPS OVER THE LAZY DOG", 23, "QEB NRFZH YOLTK CLU GRJMP LSBO QEB IXWV ALD")]
        [TestCase("a-Aa-A", 1, "b-Bb-B")]
        [TestCase("aaa", 3000000, "qqq")]
        [TestCase("かきくけこ", 1, "がぎぐげご")]
        public void CaesarCipherEncode_ShiftIsPositive_ReturnRightShifted(string text, int shift, string expected)
        {
            string result = CaesarCipher.Encode(text, shift);

            Assert.AreEqual(expected, result);
        }

        [TestCase("THE QUICK BROWN FOX JUMPS OVER THE LAZY DOG", 0, "THE QUICK BROWN FOX JUMPS OVER THE LAZY DOG")]
        [TestCase("---a", 0, "---a")]
        public void CaesarCipherEncode_ShiftIsUnsigned_ReturnEqual(string text, int shift, string expected)
        {
            string result = CaesarCipher.Encode(text, shift);

            Assert.AreEqual(expected, result);
        }

        [TestCase("THE QUICK BROWN FOX JUMPS OVER THE LAZY DOG", -1, "SGD PTHBJ AQNVM ENW ITLOR NUDQ SGD KZYX CNF")]
        [TestCase("~`!1@2#3$4%5^6&7*8(9)0_-+=abc", -27, "~`!1@2#3$4%5^6&7*8(9)0_-+=zab")]
        public void CaesarCipherEncode_ShiftIsNegative_ReturnLeftShifted(string text, int shift, string expected)
        {
            string result = CaesarCipher.Encode(text, shift);

            Assert.AreEqual(expected, result);
        }

        [TestCase("", 1, "")]
        public void CaesarCipherEncode_TextIsEmpty_ReturnEmpty(string text, int shift, string expected)
        {
            string result = CaesarCipher.Encode(text, shift);

            Assert.AreEqual(expected, result);
        }

        [TestCase(null, 0, null)]
        public void CaesarCipherEncode_TextIsNull_ReturnNull(string text, int shift, string expected)
        {
            string result = CaesarCipher.Encode(text, shift);

            Assert.AreEqual(expected, result);
        }
    }
}