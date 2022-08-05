using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDO_interface
{
    class Graph
    {
        string itemName;
        int count;
        List<Graph> ItemRecipe = new List<Graph>();

        public Graph(string name, int c)
        {
            itemName = name;
            count = c;
        }

        public void addChildren(string name,int c)
        {
            ItemRecipe.Add(new Graph(name,c));

        }

        public List<Graph> getChildren()
        {
            return ItemRecipe;
        }

        public string getItemName()
        {
            return itemName;
        }

        public int getCount()
        {
            return count;
        }
    }
}
