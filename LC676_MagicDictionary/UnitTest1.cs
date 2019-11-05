using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC676_MagicDictionary
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GivenMagicDictionaryAndValidWord_Search_ShouldReturnTrue()
        {
            var input = new string[] { "hello", "world" };
            var word = "hhllo";

            var magicDict = new MagicDictionary().Build(input);

            var result = magicDict.Search(word);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenMagicDictionaryAndOriginalWord_Search_ShouldReturnFalse()
        {
            var input = new string[] { "hello", "world" };
            var word = "hello";

            var magicDict = new MagicDictionary().Build(input);

            var result = magicDict.Search(word);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenMagicDictionaryAndWordOfDifferentLength_Search_ShouldReturnFalse()
        {
            var input = new string[] { "hello", "world" };
            var word = "hell";

            var magicDict = new MagicDictionary().Build(input);

            var result = magicDict.Search(word);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenTwoWordOfSimilarConstruction_Search_ShouldReturnTrue()
        {
            var input = new string[] { "hello", "helli" };
            var word = "helle";

            var magicDict = new MagicDictionary().Build(input);

            var result = magicDict.Search(word);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenTwoWordOfSimilarConstructionInMagicDictionary2_Search_ShouldReturnTrue()
        {
            var input = new string[] { "hello", "helli" };
            var word = "helle";

            var magicDict = new MagicDictionary().Build(input);

            var result = magicDict.Search(word);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenTwoWordOfSimilarConstructionAndInvalidWordInMagicDictionary2_Search_ShouldReturnFalse()
        {
            var input = new string[] { "hello", "helli" };
            var word = "hello";

            var magicDict = new MagicDictionary().Build(input);

            var result = magicDict.Search(word);

            Assert.IsFalse(result);
        }

    }

    public class MagicDictionary2
    {
        Dictionary<string, string> magicWords = new Dictionary<string, string>();

        public MagicDictionary2()
        {
        }

        // construct with wild chars
        public MagicDictionary2 Build(string[] input)
        {
            foreach (var item in input)
            {
                for (int i = 0; i < item.Length; i++)
                {
                    var charArray = item.ToCharArray();
                    charArray[i] = '*';
                    var word = new string(charArray);
                    if (!magicWords.ContainsKey(word))
                    {
                        magicWords.Add(word, item[i].ToString());
                    }
                    else
                    {
                        magicWords[word].Insert(0, item[i].ToString());
                    }
                }
            }

            return this;
        }

        public bool Search(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                var charArray = word.ToCharArray();
                charArray[i] = '*';
                var targetWord = new string(charArray);
                if (magicWords.ContainsKey(targetWord))
                {
                    return magicWords[targetWord].Contains(word[i].ToString());
                }
            }

            return false;
        }
    }

    public class MagicDictionary
    {
        HashSet<string> magicWords = new HashSet<string>();
        HashSet<string> originalWords = new HashSet<string>();

        public MagicDictionary()
        {
        }

        public MagicDictionary Build(string[] input)
        {
            // param validation

            foreach (var item in input)
            {
                originalWords.Add(item);

                for (int i = 0; i < item.Length; i++)
                {
                    for (char j = 'a'; j <= 'z'; j++)
                    {
                        var charArray = item.ToCharArray();
                        if (charArray[i] != j)
                        {
                            charArray[i] = j;
                            magicWords.Add(new string(charArray));
                        }
                    }
                }
            }

            return this;
        }

        public bool Search(string word)
        {
            return !originalWords.Contains(word) && magicWords.Contains(word);
        }
    }
}
