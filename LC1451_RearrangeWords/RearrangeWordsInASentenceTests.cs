using System;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1451_RearrangeWords
{
    [TestClass]
    public class RearrangeWordsInASentenceTests
    {
        [TestMethod]
        public void GivenSentence_RearrageWords_ShouldReturnCorrectAnswer()
        {
            var text = "Keep calm and code on";

            var result = RearrangeWords(text);

            Assert.IsTrue(result == "On and keep calm code");
        }

        private string RearrangeWords(string text)
        {
            var array = text.Split(' ');
            var sorted = array.OrderBy(x => x.Length).ToArray();

            var sb = new StringBuilder();

            sb.Append((sorted[0][0] >= 'a' && sorted[0][0] <= 'z') ? (char)(sorted[0][0] - 'a' + 'A') : sorted[0][0]);
            sb.Append(sorted[0].Substring(1));

            for (int i = 1; i < sorted.Length; i++)
            {
                sb.Append(' ');
                if (sorted[i][0] >= 'A' && sorted[i][0] <= 'Z')
                {
                    sb.Append((char)(sorted[i][0] - 'A' + 'a'));
                    sb.Append(sorted[i].Substring(1));
                }
                else
                {
                    sb.Append(sorted[i]);
                }
            }

            return sb.ToString();
        }
    }
}
