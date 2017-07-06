using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuPanel1
{
    public partial class Form1 : Form
    {
        Receipt frmReceipt = new Receipt();
        public Form1()
        {
            InitializeComponent();

            //ADD TREEVIEW DETAILS
            treeView1.Nodes.Add("ParentKey1", "Admin");
            treeView1.Nodes["ParentKey1"].Nodes.Add("Company");
            treeView1.Nodes["ParentKey1"].Nodes.Add("Tax");
            treeView1.Nodes["ParentKey1"].Nodes.Add("Application");
            treeView1.Nodes["ParentKey1"].Nodes.Add("Receipt");
            treeView1.Nodes["ParentKey1"].Nodes.Add("Point");

            treeView1.Nodes.Add("ParentKey2", "Item");
            treeView1.Nodes["ParentKey2"].Nodes.Add("Category");
            treeView1.Nodes["ParentKey2"].Nodes.Add("Unit of Measure");
            treeView1.Nodes["ParentKey2"].Nodes.Add("Items");
            treeView1.Nodes["ParentKey2"].Nodes.Add("Price Level");
            treeView1.Nodes["ParentKey2"].Nodes.Add("Expiration");
            treeView1.Nodes["ParentKey2"].Nodes.Add("Print Item List");

            treeView1.Nodes.Add("ParentKey3", "Customer");
            treeView1.Nodes["ParentKey3"].Nodes.Add("Customer Details");
            treeView1.Nodes["ParentKey3"].Nodes.Add("Points Review");

            treeView1.Nodes.Add("ParentKey4", "User");
            treeView1.Nodes["ParentKey4"].Nodes.Add("Manage Users");
            treeView1.Nodes["ParentKey4"].Nodes.Add("Responsibility");

            treeView1.Nodes.Add("ParentKey5", "Promo");
            treeView1.Nodes["ParentKey5"].Nodes.Add("Manage Promo");

            treeView1.Nodes.Add("ParentKey6", "Reports");
            treeView1.Nodes["ParentKey6"].Nodes.Add("Audit Trail");
            treeView1.Nodes["ParentKey6"].Nodes.Add("Removed Items");
            treeView1.Nodes["ParentKey6"].Nodes.Add("Daily Sales Report");
            treeView1.Nodes["ParentKey6"].Nodes.Add("Stock Inventory");
            treeView1.Nodes["ParentKey6"].Nodes.Add("BIR Report");
            treeView1.ExpandAll();
            treeView1.SelectedNode = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MdiClient ctlMDI;

            // Loop through all of the form's controls looking
            // for the control of type MdiClient.
            foreach (Control ctl in this.Controls)
            {
                try
                {
                    // Attempt to cast the control to type MdiClient.
                    ctlMDI = (MdiClient)ctl;

                    // Set the BackColor of the MdiClient control.
                    ctlMDI.BackColor = this.BackColor;
                }
                catch (InvalidCastException exc)
                {
                    // Catch and ignore the error if casting failed.
                }
            }

            treeView1.SelectedNode = null;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
            //MessageBox.Show(string.Format("You selected: {0}", node.Text));
            label2.Text = node.Text;

            if (label2.Text == "Company")
            {
                if (frmReceipt.Visible)
                {
                    frmReceipt.Close();
                }
            }
            else if (label2.Text == "Receipt")
            {
                // Display a child form to show this is still an MDI application.
                if (!frmReceipt.Visible)
                {
                    frmReceipt = new Receipt();
                    frmReceipt.MdiParent = this;
                    frmReceipt.Show();
                }
            }
            else if (label2.Text != "Receipt")
            {
                if (frmReceipt.Visible)
                {
                    frmReceipt.Close();
                }

            }
        }
    }
}
