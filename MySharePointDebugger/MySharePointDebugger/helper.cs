using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RikTheVeggie;

namespace MySharePointDebugger
{
    static class MyHelper
    {
        private static List<TreeNode> GetSubNodes(TreeNode parentNode)
        {
            List<TreeNode> result = new List<TreeNode>();
            foreach (TreeNode TN in parentNode.Nodes)
            {
                result.AddRange(GetSubNodes(TN));
            }
            return result;
        }
        public static List<TreeNode> GetAllNodes(this TriStateTreeView _self)
        {
            List<TreeNode> result = new List<TreeNode>();
            foreach (TreeNode child in _self.Nodes)
            {
                result.AddRange(GetSubNodes(child));
            }
            return result;
        }
        
    }
}
