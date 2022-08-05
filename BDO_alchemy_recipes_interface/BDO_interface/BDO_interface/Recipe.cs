using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDO_interface
{
    class Recipe
    {
        


        public static Dictionary<string, List<(int,string)>> dict;
        public static void load_dictionary(string name)
        {
            dict = new Dictionary<string, List<(int, string)>>();
            using (StreamReader sr = new StreamReader(@"C:\Users\jules\Documents\GitHub Project\BDO_alchemy_recipes\BDO_alchemy_recipes_interface\BDO_interface\BDO_interface\" + name + ".csv"))
            {
                
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    string[] ingredients = line.Split(';')[1..];
                    string recette = line.Split(';')[0];

                    dict[recette] = new List<(int, string)>();
                    foreach (string ingredient in ingredients)
                    {
                        int count = Int32.Parse(ingredient.Split(' ')[0]);
                        string ingredientName = String.Join(' ',ingredient.Split(' ')[1..]);
                        
                        dict[recette].Add((count, ingredientName));
                    }
                }


            }

        }

        public static void changeValueInGraph(TreeNode G,string itemName,bool isChecked)
        {
            
            if(G.Text.Contains(itemName))
            {
                if(isChecked)
                    G.BackColor = Color.Green;
                    
                    
                else
                    G.BackColor = Color.Transparent;

                checkIfChildrenAreGreen(G.Parent);

            }
            else
            {
                foreach(TreeNode t in G.Nodes)
                {
                    changeValueInGraph(t, itemName, isChecked);
                }
            }
        }

        public static void checkIfChildrenAreGreen(TreeNode G)
        {
            if (G == null)
                return;

            bool isAllCheck = true;
            foreach (TreeNode node in G.Nodes)
            {
                if (node.BackColor != Color.Green)
                {
                    isAllCheck = false;
                }
            }

            if (isAllCheck)
            {
                G.BackColor = Color.Green;
                G.Collapse();
                
            }
            else
            {
                G.BackColor = Color.Transparent;
                G.Expand();
                
            }
            checkIfChildrenAreGreen(G.Parent);
        }


        public static void CreateGraph(Graph G,string itemToCraft,int count)
        {
            

            

            foreach(var item in dict[itemToCraft]) // Add item needed
            {
                G.addChildren(item.Item2, item.Item1*count);
            }
            

            foreach(Graph children in G.getChildren()) // check if those children are subcraft
            {
                if(isInDict(children.getItemName()) == true)
                {
                    CreateGraph(children, children.getItemName(), children.getCount());
                }

            }
            
        }

        public static void getAllRecipe(Graph G,List<string> l)
        {
            if(G.getChildren().Count == 0)
            {
                for(int i = 0; i < l.Count;++i)
                {
                    if (l[i].Contains(G.getItemName()))
                    {
                        int count = Int32.Parse(l[i].Split(" - ")[0]);
                        count += G.getCount();
                        l[i] = count + " - " + G.getItemName();
                        return;
                    }
                }
                l.Add(G.getCount() + " - " + G.getItemName());

            }

            else
            {
                foreach(var child in G.getChildren())
                {
                    getAllRecipe(child, l);
                }
            }

        }

        public static TreeNode FillTree(Graph G)
        {
            TreeNode treeNode = new TreeNode(G.getCount() + " - " + G.getItemName());


            
            for (int i = 0; i < G.getChildren().Count(); ++i )
            {
                treeNode.Nodes.Add(FillTree(G.getChildren()[i]));
            }

            

            return treeNode;
        }


        private static bool isInDict(string ingredientName)
        {
            try
            {
                return (dict[ingredientName] != null);
            }
            catch
            {
                return false;
            }
        }


    }
}
