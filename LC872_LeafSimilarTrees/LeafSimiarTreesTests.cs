using System;
using System.Collections.Generic;
using System.Linq;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC872_LeafSimilarTrees
{
//   1
//  2 3
// 4 5 6 7

//    1
//   2 7
//  3 6
// 4 3
//    5

    [TestClass]
    public class LeafSimiarTreesTests
    {
        [TestMethod]
        public void GivenTwoSimilarTrees_AreLeavesSimiliar_ShouldReturnTrue()
        {
            var root1 = BinaryTree.CreateBinaryTreeBFS(new string[] { "1", "2", "3", "4", "5", "6", "7" });
            var root2 = BinaryTree.CreateBinaryTreeBFS(new string[] { "1", "2", "7", "3", "6", null, null, "4", "3", null, null, null, null, null, "5" });

            var result = AreLeavesSimiliar(root1, root2);

            Assert.IsTrue(result);
        }

        private bool AreLeavesSimiliar(BinaryTreeNode root1, BinaryTreeNode root2)
        {
            var leafList1 = new List<int>();
            var leafList2 = new List<int>();

            GetLeafList(root1, leafList1);
            GetLeafList(root2, leafList2);

            return leafList1.Count == leafList2.Count && leafList1.SequenceEqual(leafList2);
        }

        private void GetLeafList(BinaryTreeNode root, List<int> leafList)
        {
            if (root == null)
            {
                return;
            }

            GetLeafList(root.Left, leafList);
            GetLeafList(root.Right, leafList);

            if (root.Left == null && root.Right == null)
            {
                leafList.Add(root.Value);
            }
        }
    }
}
