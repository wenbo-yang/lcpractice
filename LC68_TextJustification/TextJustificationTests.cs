using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC68_TextJustification
{
    [TestClass]
    public class TextJustificationTests
    {
        [TestMethod]
        public void GivenTextArray_FillWordsWithLineLength_ShouldReturnCorrectAnswer()
        {
            var words = new string[] { "This", "is", "an", "example", "of", "text", "justification." };
            var maxLength = 16;

            var result = FillWordsWithLineLength(words, maxLength);

            Assert.IsTrue(result[0] == "This    is    an" && result[1] == "example  of text" && result[2] == "justification.  ");
        }

        private List<string> FillWordsWithLineLength(string[] words, int maxWidth)
        {
            var result = new List<string>();
            var start = 0;
            var count = 0;
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > maxWidth)
                {
                    throw new Exception("Cannot happen");
                }

                count += words[i].Length;

                if (count > maxWidth)
                {
                    var str = FillLine(words, start, i - 1, count - words[i].Length - 1, maxWidth);
                    result.Add(str);

                    start = i;
                    count = 0;
                    i--;
                }
                else if (i == words.Length - 1)
                {
                    var str = FillLineLeft(words, start, i, maxWidth);
                    result.Add(str);
                }
                else
                {
                    count++;
                }
            }

            return result;
        }

        private string FillLineLeft(string[] words, int start, int end, int maxWidth)
        {
            var sb = new StringBuilder();

            var count = 0;

            while (start < end)
            {
                sb.Append(words[start]);
                count += words[start++].Length;

                sb.Append(' ');
                count++;
            }

            sb.Append(words[end]);
            count += words[end].Length;

            var diff = maxWidth - count;

            while (diff-- > 0)
            {
                sb.Append(' ');
            }

            return sb.ToString();
        }

        private string FillLine(string[] words, int start, int end, int count, int maxWidth)
        {
            var sb = new StringBuilder();
            var numberOfWords = end - start + 1;
            count -= (numberOfWords - 1);
            var padding = numberOfWords == 1 ? (maxWidth - words[start].Length) : (maxWidth - count) / (numberOfWords - 1);
            var remainder = numberOfWords == 1 ? 0 : (maxWidth - count) % (numberOfWords - 1);
            while (start < end)
            {
                sb.Append(words[start]);
                var spaceCount = 0;
                while (spaceCount++ < padding)
                {
                    sb.Append(' ');
                }

                if (remainder-- > 0)
                {
                    sb.Append(' ');
                }

                start++;
            }

            sb.Append(words[end]);

            if (numberOfWords == 1)
            {
                var spaceCount = 0;
                while (spaceCount++ < padding)
                {
                    sb.Append(' ');
                }
            }

            return sb.ToString();
        }
    }
}
