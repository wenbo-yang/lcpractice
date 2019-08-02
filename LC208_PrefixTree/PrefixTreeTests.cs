using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC208_PrefixTree
{
    [TestClass]
    public class PrefixTreeTests
    {
        [TestMethod]
        public void GivenString_Put_ShoulGeneratePrefixTree()
        {
            var tree = new PrefixTree(new TrieTreeNode());
            bool result = tree.Insert("apple");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenString_Get_ShouldReturnTrue()
        {
            var tree = new PrefixTree(new TrieTreeNode());
            tree.Insert("apple");
            var result = tree.Search("apple");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenValidInputStringButInvalidSearch_Search_ShouldReturnFalse()
        {
            var tree = new PrefixTree(new TrieTreeNode());
            tree.Insert("apple");
            var result = tree.Search("app");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenValidInputString_StartWith_ShouldReturnTrue()
        {
            var tree = new PrefixTree(new TrieTreeNode());
            tree.Insert("apple");
            var result = tree.StartWith("app");

            Assert.IsTrue(result);
        }

        public class PrefixTree
        {
            private readonly TrieTreeNode _root;
            public PrefixTree(TrieTreeNode root)
            {
                _root = root;
            }

            public bool Insert(string input)
            {
                var temp = _root;

                foreach (var c in input)
                {
                    if (!temp.Children.ContainsKey(c))
                    {
                        temp.Children.Add(c, new TrieTreeNode());
                    }

                    temp = temp.Children[c];
                }

                temp.IsWord = true;

                return true;
            }

            public bool Search(string input)
            {
                var temp = _root;

                foreach (var c in input)
                {
                    if (!temp.Children.ContainsKey(c))
                    {
                        return false;
                    }

                    temp = temp.Children[c];
                }

                return temp.IsWord;
            }

            public bool StartWith(string input)
            {
                var temp = _root;

                foreach (var c in input)
                {
                    if (!temp.Children.ContainsKey(c))
                    {
                        return false;
                    }

                    temp = temp.Children[c];
                }

                return true;
            }
        }

        public class TrieTreeNode
        {
            public TrieTreeNode()
            {
                Children = new Dictionary<char, TrieTreeNode>();
            }

            public bool IsWord { get; set; }
            public Dictionary<char, TrieTreeNode> Children { get; set; }
        }
    }
}
