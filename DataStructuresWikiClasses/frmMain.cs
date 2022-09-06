using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataStructuresWikiClasses
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        List<Information> Wiki = new List<Information>();
        string radioButtonType = "Linear";
        int radioButtonIndex = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadComboBox();
        }

        private void LoadComboBox()
        {
            cbCategory.Items.Clear();
            string[] categories = System.IO.File.ReadAllLines("Categories.txt");
            cbCategory.Items.AddRange(categories);
        }

        private void updateSS(string input)
        {
            statusStrip1.Items.Clear();
            statusStrip1.Items.Add(input);
        }

        private void Sort()
        {
            int wikiC = Wiki.Count();
            for (int i = 1; i < wikiC; i++)
            {
                for (int j = 0; j < wikiC - 1; j++)
                {
                    if (!(string.IsNullOrEmpty(Wiki[j + 1].getName())))
                    {
                        if (string.Compare(Wiki[j].getName(), Wiki[j + 1].getName()) == 1)
                        {
                            swap(j); // swaps the data.
                        }
                    }
                }
            }
        }

        private void swap(int index)
        {
            Information temp = Wiki[index];
            Wiki[index] = Wiki[index + 1];
            Wiki[index + 1] = temp;
        }

        private bool ValidName(string input)
        {
            bool isValid = true;
            List<string> dummyNames = new List<string>();
            for (int i = 0; i < Wiki.Count; i++)
            {
                dummyNames.Add(Wiki[i].getName());
            }
            isValid = dummyNames.Contains(input);
            return isValid;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool exists = true;

            if (!string.IsNullOrEmpty(tbxName.Text) && !string.IsNullOrEmpty(cbCategory.Text) && radioButtonIndex >= 0 && !string.IsNullOrEmpty(tbxDefinition.Text)) 
            {
                exists = ValidName(tbxName.Text);
                if (exists)
                {
                    MessageBox.Show("Error: " + tbxName.Text + " already exists in the wiki!", "Adding Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    updateSS("Error: " + tbxName.Text + " already exists in the wiki!");
                }
                else
                {
                    Wiki.Add(new Information(tbxName.Text, cbCategory.Text, radioButtonType, tbxDefinition.Text));
                    displayData();
                    updateSS(tbxName.Text + " has been added to the Wiki!");
                }

            }
            else
            {
                MessageBox.Show("Error: One of the following data inputs has no data inside: Name, Category, Structure or Definition. Please input data and try again.", "Error Inputting Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                updateSS("Error: One of the following data inputs has no data inside: Name, Category, Structure or Definition. Please input data and try again.");
            }

        }

        private void displayData()
        {
            lvDataStructures.Items.Clear();
            Sort();
            for (int i = 0; i < Wiki.Count; i++)
            {
                ListViewItem lv1 = new ListViewItem(Wiki[i].getName(), 0);
                lv1.SubItems.Add(Wiki[i].getCategory());
                lvDataStructures.Items.Add(lv1);
            }
        }

        private void displayIntoText(int index)
        {
            tbxName.Text = Wiki[index].getName();
            cbCategory.Text = Wiki[index].getCategory();
            radioButtonIndex = Wiki[index].getStructure();
            tbxDefinition.Text = Wiki[index].getDef();
            selectRB(radioButtonIndex);
        }

        private void selectRB(int index)
        {
            if (index == 0)
            {
                rbLinear.Checked = true;
            }
            else
            {
                rbNonLinear.Checked = true;
            }
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            displayData();
        }

        private void lvDataStructures_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                displayIntoText(lvDataStructures.SelectedIndices[0]);
            }
            catch (Exception)
            {

            }
        }

        private void rbLinear_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonType = "Linear";
            radioButtonIndex = 0;
        }

        private void rbNonLinear_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonType = "Non-Linear";
            radioButtonIndex = 1;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int index = lvDataStructures.SelectedIndices[0];
                string text = Wiki[index].getName();

                DialogResult dr = MessageBox.Show("Are you sure you want to delete " + text + "?", "Are you sure you want to delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    Wiki.RemoveAt(index);
                    updateSS(text + " was deleted from the Wiki!");
                }
                else if (dr == DialogResult.No)
                {
                    updateSS(text + " has not been deleted from the Wiki!");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error, nothing selected to delete.", "Deleting Definition", MessageBoxButtons.OK, MessageBoxIcon.Error);
                updateSS("Error, nothing selected to delete.");
            }

            displayData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int index = lvDataStructures.SelectedIndices[0];
                string text = Wiki[index].getName();

                bool exists = true;

                if (!string.IsNullOrEmpty(tbxName.Text) && !string.IsNullOrEmpty(cbCategory.Text) && radioButtonIndex >= 0 && !string.IsNullOrEmpty(tbxDefinition.Text))
                {
                    exists = ValidName(tbxName.Text);
                    if (exists)
                    {
                        if (text == tbxName.Text)
                        {
                            Wiki[index].setName(tbxName.Text);
                            Wiki[index].setStructure(radioButtonType);
                            Wiki[index].setCategory(cbCategory.Text);
                            Wiki[index].setDef(tbxDefinition.Text);
                            updateSS(text + " was edited as is now " + tbxName.Text + "!");
                        }
                        else
                        {
                            MessageBox.Show("Error: " + tbxName.Text + " already exists in the wiki!", "Editing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            updateSS("Error: " + tbxName.Text + " already exists in the wiki!");
                        }
                    }
                    else
                    {
                        Wiki[index].setName(tbxName.Text);
                        Wiki[index].setStructure(radioButtonType);
                        Wiki[index].setCategory(cbCategory.Text);
                        Wiki[index].setDef(tbxDefinition.Text);
                        updateSS(text + " was edited as is now " + tbxName.Text + "!");
                    }

                }
                else
                {
                    MessageBox.Show("Error: One of the following data inputs has no data inside: Name, Category, Structure or Definition. Please input data and try again.", "Error Inputting Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    updateSS("Error: One of the following data inputs has no data inside: Name, Category, Structure or Definition. Please input data and try again.");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error, nothing selected to edit.", "Editing Definition", MessageBoxButtons.OK, MessageBoxIcon.Error);
                updateSS("Error, nothing selected to edit.");
            }

            displayData();
        }

        private void clear()
        {
            tbxName.Clear();
            cbCategory.Text = null;
            rbLinear.Checked = false;
            rbNonLinear.Checked = false;
            tbxDefinition.Clear();
            radioButtonIndex = -1;
            radioButtonType = null;
            updateSS("Data in the textboxes has been successfully cleared");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void lvDataStructures_DoubleClick(object sender, EventArgs e)
        {
            clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string text = tbxSearchBar.Text;
            List<string> names = new List<string>();
            for (int i = 0; i < Wiki.Count; i++)
            {
                names.Add(Wiki[i].getName());
                lvDataStructures.Items[i].Focused = true;
                lvDataStructures.Items[i].Selected = true;
            }
            int indx = names.BinarySearch(text);
            if (indx < 0)
            {
                MessageBox.Show("Search for " + text + " was not found.", "Couldn't find search term.", MessageBoxButtons.OK, MessageBoxIcon.Question);
                updateSS("Search for " + text + " was not found.");
            }
            else
            {
                displayIntoText(indx);
                lvDataStructures.Items[indx].Focused = true;
                lvDataStructures.Items[indx].Selected = true;
            }
        }
    }
}
