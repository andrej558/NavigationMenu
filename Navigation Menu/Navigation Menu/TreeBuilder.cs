using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navigation_Menu
{
    class TreeBuilder
    {
        private List<Node> Roots { get; set; }
        private List<Node> WaitForParent { get; set; }

        public TreeBuilder() {
            Roots = new List<Node>();
            WaitForParent = new List<Node>();
        }
        public void setRoot(Node n) {
            Roots.Add(n);
        }
        public Node getRootNodeWithId(string id) {
            return Roots.FirstOrDefault(z => z.Id == id);
        }
        public Node getNodeWithId(string id) {

            Node toReturn = null;
            foreach(var root in Roots)
            {
                toReturn = getNodeWithId(root, id);
            }
            return toReturn;
        }
        private Node getNodeWithId(Node node, string id)
        {
            if (node.Id == id)
            {
                return node;
            }
            else
            {
                foreach(Node child in node.getChildren()) {
                    var toGet = getNodeWithId(child, id);
                    if (toGet != null)
                    {
                        return toGet;
                    }
                }
            }
            return null;
        }
        public void addToQueue(Node n) {
            WaitForParent.Add(n);
        }
        public void PrintTree() { 
            foreach(var node in Roots)
            {
                PrintTree(node, 1);
            }
        }
        private void PrintTree(Node node, int level) {
            for (int i = 0; i < level; i++)
            {
                Console.Write('-');
            }
            Console.WriteLine(node.Name);
            foreach(Node child in node.getChildren())
            {
                if (child.isHidden == true)
                {
                    continue;
                }
                PrintTree(child, level+1);
            }
        }
        public void setAllUnsortedNodes() { 
            foreach(var node in WaitForParent)
            {
                //var parent = Roots.FirstOrDefault(z => z.Id == node.parentId);
                var parent = getNodeWithId(node.parentId);
                parent.setChild(node);
            }
        }
    }
}
