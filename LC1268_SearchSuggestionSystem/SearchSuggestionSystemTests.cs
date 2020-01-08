using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1268_SearchSuggestionSystem
{
    [TestClass]
    public class SearchSuggestionSystemTests
    {
        [TestMethod]
        public void GivenSearchWordAndDictionary_GetSuggestions_ShouldReturnSetOfSuggestions()
        {
            var dictionary = new string[] { "mobile", "mouse", "moneypot", "monitor", "mousepad" };
            var searchWord = "mouse";
            var result = GetSuggestions(dictionary, searchWord);

            Assert.IsTrue(result.Count == 5);
            Assert.IsTrue(result[0].SequenceEqual(new List<string> { "mobile", "moneypot", "monitor" }));
            Assert.IsTrue(result[1].SequenceEqual(new List<string> { "mobile", "moneypot", "monitor" }));
            Assert.IsTrue(result[2].SequenceEqual(new List<string> { "mouse", "mousepad" }));
            Assert.IsTrue(result[3].SequenceEqual(new List<string> { "mouse", "mousepad" }));
            Assert.IsTrue(result[4].SequenceEqual(new List<string> { "mouse", "mousepad" }));
        }

        private List<List<string>> GetSuggestions(string[] dictionary, string searchWord)
        {
            var searchSuggestions = new TrieSearch(dictionary, 3).Build();

            var result = new List<List<string>>();

            var charList = new List<char>();

            foreach (var c in searchWord)
            {
                charList.Add(c);

                var suggestions = searchSuggestions.SearchSuggestion(new string(charList.ToArray()));
                result.Add(suggestions);
            }
                
            return result;
        }

        public class TrieNode
        {
            public bool isWord;
            public SortedDictionary<char, TrieNode> children;
        }

        public class TrieSearch
        {
            private TrieNode _root = new TrieNode();
            private string[] _dictionary;
            private int _suggestionLimit;

            public TrieSearch(string[] dictionary, int suggestionLimit)
            {
                _dictionary = dictionary;
                _suggestionLimit = suggestionLimit;
            }

            public TrieSearch Build()
            {
                foreach (var word in _dictionary)
                {
                    InsertIntoTree(word);
                }

                return this;
            }

            private void InsertIntoTree(string word)
            {
                var temp = _root;

                foreach (var c in word)
                {
                    if (temp.children == null)
                    {
                        temp.children = new SortedDictionary<char, TrieNode>();
                    }

                    if (!temp.children.ContainsKey(c))
                    {
                        temp.children.Add(c, new TrieNode());
                    }

                    temp = temp.children[c];
                }

                temp.isWord = true;
            }

            public List<string> SearchSuggestion(string word)
            {
                var result = new List<string>();

                var temp = _root;

                foreach (var c in word)
                {
                    if (!temp.children.ContainsKey(c))
                    {
                        return result;
                    }
                    temp = temp.children[c];
                }

                GetSuggestionsHelper(temp, new List<char>(word.ToArray()), result, _suggestionLimit);

                return result;
            }

            private void GetSuggestionsHelper(TrieNode root,  List<char> current, List<string> result, int limit)
            {
                if (root == null || result.Count == limit)
                {
                    return;
                }

                if (root.isWord)
                {
                    result.Add(new string(current.ToArray()));
                }

                if (root.children != null)
                {
                    foreach (var child in root.children)
                    {
                        current.Add(child.Key);

                        GetSuggestionsHelper(child.Value, current, result, limit);

                        current.RemoveAt(current.Count - 1);
                    }
                }
            }
        }
    }
}
