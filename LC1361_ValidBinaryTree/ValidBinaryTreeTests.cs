using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1361_ValidBinaryTree
{
    [TestClass]
    public class ValidBinaryTreeTests
    {
        [TestMethod]
        public void GivenBinaryTreeNodeInArrayForm_IsValidBinaryTree_ShouldReturnCorrectResult()
        {
            var leftChild = new int[] { 1, -1, 3, -1 }; var rightChild = new int[] { 2, -1, -1, -1 };
            var n = 4;
            var result = IsValidBinaryTree(n, leftChild, rightChild);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenAnotherSetOfBinaryTreeNodeInArrayForm_IsValidBinaryTree_ShouldReturnCorrectResult()
        {

            var leftChild = new int[] { 1, -1, 3, -1 }; var rightChild = new int[] { 2, 3, -1, -1 };
            var n = 4;
            var result = IsValidBinaryTree(n, leftChild, rightChild);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenThirdSetOfBinaryTreeNodeInArrayForm_IsValidBinaryTree_ShouldReturnCorrectResult()
        {
            var leftChild = new int[] { 1, 2, 0, -1 }; var rightChild = new int[] { -1, -1, -1, -1 };
            var n = 4;
            var result = IsValidBinaryTree(n, leftChild, rightChild);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenCircularReferenceBinaryTreeNodeInArrayForm_IsValidBinaryTree_ShouldReturnCorrectResult()
        {
            var leftChild = new int[] { 1, 0 }; var rightChild = new int[] { -1, -1 };
            var n = 2;
            var result = IsValidBinaryTree(n, leftChild, rightChild);

            Assert.IsFalse(result);
        }

        private bool IsValidBinaryTree(int n, int[] leftChild, int[] rightChild)
        {
            var childCount = new int[n];
            var parentTable = new int[n];
            for (int i = 0; i < n; i++)
            {
                parentTable[i] = i;
            }

            for (int i = 0; i < n; i++)
            {
                if (leftChild[i] == i || rightChild[i] == i)
                {
                    return false;
                }

                if (leftChild[i] != -1)
                {
                    if (parentTable[leftChild[i]] == leftChild[i] && parentTable[leftChild[i]] != parentTable[i])
                    {
                        parentTable[leftChild[i]] = i;
                        childCount[i]++;

                        Find(parentTable, leftChild[i]);
                    }
                    else
                    {
                        return false;
                    }
                }

                if (rightChild[i] != -1)
                {
                    if (parentTable[rightChild[i]] == rightChild[i] && parentTable[rightChild[i]] != parentTable[i])
                    {
                        parentTable[rightChild[i]] = i;
                        childCount[i]++;

                        Find(parentTable, rightChild[i]);
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            var rootCount = 0;

            for (int i = 0; i < n; i++)
            {
                if (parentTable[i] == i)
                {
                    rootCount++;
                }

                if (childCount[i] > 2 || rootCount > 1)
                {
                    return false;
                }
            }

            return true;
        }

        private int Find(int[] parentTable, int child)
        {
            if (parentTable[child] != child)
            {
                parentTable[child] = Find(parentTable, parentTable[child]);
            }

            return parentTable[child];
        }
    }
}
