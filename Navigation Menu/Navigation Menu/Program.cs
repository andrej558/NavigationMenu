using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navigation_Menu
{
    class Program
    {
        static void Main(string[] args)
        {
            FileReader fileReader = new FileReader("../../Navigation.csv");
            string[] data = fileReader.getData();
            TreeBuilder treeBuilder = new TreeBuilder();
            foreach(string line in data) {
                string[] slice = line.Split(';');
                string id = slice[0];
                string menuName = slice[1];
                string parentId = slice[2];
                bool hidden = bool.Parse(slice[3]);
                string linkUrl = slice[4];
                Node n = new Node(menuName, id, parentId, hidden, linkUrl);

                if (n.parentId == "NULL"){
                    treeBuilder.setRoot(n);
                }
                else
                {
                    var node = treeBuilder.getNodeWithId(n.parentId);
                    if (node == null)
                    {
                        treeBuilder.addToQueue(n);
                    }
                    else
                    {
                        node.setChild(n);
                    }
                }
            }
            treeBuilder.setAllUnsortedNodes();
            treeBuilder.PrintTree();
        }
    }
}
