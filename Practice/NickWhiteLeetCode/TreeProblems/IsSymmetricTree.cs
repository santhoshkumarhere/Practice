
namespace Practice.Tree.TreeProblems
{
    public class IsSymmetricTree
    {

        public static void Test()
        {
            //var tree = new TreeNode(4,
            //    new TreeNode(2, new TreeNode(1), new TreeNode(3)), 
            //    new TreeNode(7, new TreeNode(6), new TreeNode(9)));
           //Written by me, dont think too much about recursion in trees just think about one root and 1 left & 1 right child.
           // Merge tree is a base for this
        }
        
        private static bool IsMirror(TreeNode t1, TreeNode t2)
        {
            if (t1 == null && t2 == null) return true;
            if (t1 == null || t2 == null) return false;

            return t1.val == t2.val && IsMirror(t1.left, t2.right) && IsMirror(t1.right, t2.left);
        }
    }
}
