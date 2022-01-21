using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LeetCode2021.TreeProblems
{
    internal class SerializeAndDeserializeBinaryTree
    {
        public static void Test()
        {
            var tree = new SerializeAndDeserializeBinaryTree();
            var root = new TreeNode(1);
            var two = new TreeNode(2);
            var three = new TreeNode(3);
            var four = new TreeNode(4);
            var five = new TreeNode(5);
            root.left = two;
            root.right = three;
            three.left = four;
            three.right = five;
            
            var s = tree.Serialize(root);
            
            var newTree = tree.Deserialize(s);
        }

        public string Serialize(TreeNode root)
        {
            var sb = new StringBuilder();
            PreOrderSerialize(root, sb);
            return sb.ToString();
        }

        private StringBuilder PreOrderSerialize(TreeNode root, StringBuilder sb)
        {
            if (root == null)
            {
                sb.Append("null,");
                return sb;
            }
            sb.Append(root.val).Append(",");
            PreOrderSerialize(root.left, sb);
            PreOrderSerialize(root.right, sb);

            return sb;
        }

        private TreeNode Decode(List<string> list)
        {
            if (list[0].Equals("null"))
            {
                list.RemoveAt(0);
                return null;
            }

            var root = new TreeNode(int.Parse(list[0]));
            list.RemoveAt(0);
            root.left = Decode(list);
            root.right = Decode(list);

            return root;
        }

        public TreeNode Deserialize(string data)
        {
            var arr = data.Split(",");
            return Decode(arr.ToList());
        }

    }
}
