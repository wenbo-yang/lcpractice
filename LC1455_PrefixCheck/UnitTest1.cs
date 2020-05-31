using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1455_PrefixCheck
{
    [TestClass]
    public class PrefixCheckTests
    {
        [TestMethod]
        public void GivenPrefixAndWord_PrefixCheck_ShouldReturnWordIndex()
        {
            var prefix = "burg";
            var sentence = "i love eating burger";

            var result = PrefixCheck(sentence, prefix);

            Assert.IsTrue(result == 4);
        }

        [TestMethod]
        public void GivenPrefixAsFirstWord_PrefixCheck_ShouldReturnWordIndex()
        {
            var prefix = "leetco";
            var sentence = "leetcode corona";

            var result = PrefixCheck(sentence, prefix);

            Assert.IsTrue(result == 1);
        }

        private int PrefixCheck(string sentence, string prefix)
        {
            var index = 0;

            while (index < prefix.Length && prefix[index] == sentence[index])
            {
                index++;
            }

            if (index == prefix.Length)
            {
                return 1;
            }
            else
            {
                while (index < sentence.Length && sentence[index] != ' ')
                {
                    index++;
                }
            }
            var result = 1;
            while(index < sentence.Length)
            {
                if (sentence[index] == ' ')
                {
                    result++;
                    index++;
                    continue;
                }

                var prefixIndex = 0;
                if (sentence[index - 1] == ' ')
                {
                    while (prefixIndex < prefix.Length && index < sentence.Length && sentence[index] == prefix[prefixIndex])
                    {
                        prefixIndex++;
                        index++;
                    }

                    if (prefixIndex == prefix.Length)
                    {
                        return result;
                    }
                }
                
                index++;
            }

            return -1;
        }
    }
}
