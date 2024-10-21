using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Part3_Win32ListView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            string itemName = txtItemName.Text.Trim();
            if (!string.IsNullOrEmpty(itemName))
            {
                listView1.Items.Add(itemName);
                txtItemName.Clear(); // Clear the input box after adding
            }
            else
            {
                MessageBox.Show("Please enter a valid item name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                listView1.Items.Remove(listView1.SelectedItems[0]); // Remove selected item
            }
            else
            {
                MessageBox.Show("Please select an item to remove.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
