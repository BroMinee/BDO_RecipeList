namespace BDO_interface
{
    public partial class Form1 : Form
    {
        
        public TreeNode root;
        public Form1()
        {
            InitializeComponent();
            comboBox2.SelectedIndex = 0;
            
        }


        private void LoadComboList()
        {
            comboBox1.Items.Clear();
            foreach(var recipe in Recipe.dict.Keys)
            {
                comboBox1.Items.Add(recipe);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            
            Recipe.load_dictionary(comboBox2.SelectedItem.ToString());


            string item;
            try
            {
               item = comboBox1.SelectedItem.ToString();
            }
            catch
            {
                return;
            }





            Graph G = new Graph(item, (int)numericUpDown1.Value);

            Recipe.CreateGraph(G,item, (int)numericUpDown1.Value);

            List<string> l = new List<string>();
            Recipe.getAllRecipe(G, l);

            

            checkedListBox1.Items.Clear();
            foreach(string itemFinal in l)
            {
                checkedListBox1.Items.Add(itemFinal);
            }

            treeView1.BeginUpdate();
            treeView1.Nodes.Clear();
            
            
            root = Recipe.FillTree(G);


            treeView1.Nodes.Add(root);
            treeView1.ExpandAll();
            
            


            treeView1.EndUpdate();




            return;
          

            
        }

        private void ComboxBox2Change(object sender, EventArgs e)
        {
            Recipe.load_dictionary(comboBox2.SelectedItem.ToString());
            comboBox1.SelectedIndex = -1;

            LoadComboList();
        }



        private void ItemCheck(object sender, ItemCheckEventArgs e)
        {
            Recipe.changeValueInGraph(root, ((CheckedListBox) sender).Text.Split(" - ")[1], e.NewValue == CheckState.Checked) ;
        }
    }
}