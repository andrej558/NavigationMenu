using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navigation_Menu
{
    class Node
    {
        public string Name { get; private set; }
        public string Id { get; private set; }
        public string parentId { get; private set; }
        public bool isHidden { get; private set; }
        public string LinkURL { get; private set; }

        private List<Node> Children { get; set; }

        public Node(string name, string id, string parentId, bool isHidden, string linkURL)
        {
            Name = name;
            Id = id;
            this.parentId = parentId;
            this.isHidden = isHidden;
            LinkURL = linkURL;
            Children = new List<Node>();
        }
        public void setChild(Node child) {
            Children.Add(child);
        }
        public List<Node> getChildren(){
            return Children;    
        }
    }
}
