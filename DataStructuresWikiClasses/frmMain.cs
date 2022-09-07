using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        // 6.2 Create a global List<T> of type Information called Wiki.
        List<Information> Wiki = new List<Information>();
        string radioButtonType = "Linear";
        int radioButtonIndex = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadComboBox();
        }

        private void LoadComboBox()
        {
            // 6.4 Create a custom method to populate the ComboBox when the Form Load method is called. The six categories must be read from a simple text file.
            if (File.Exists("Categories.txt"))
            {
                cbCategory.Items.Clear();
                string[] categories = File.ReadAllLines("Categories.txt");
                cbCategory.Items.AddRange(categories);
            }
            else
            {
                updateSS("Categories could not be loaded.");
            }

        }

        private void updateSS(string input)
        {
            statusStrip1.Items.Clear();
            statusStrip1.Items.Add(input);
        }

        // 6.9 Create a single custom method that will sort and then display the Name and Category from the wiki information in the list.
        private void Sort()
        {
            int wikiC = Wiki.Count();
            for (int i = 0; i < wikiC; i++)
            {
                for (int j = 0; j < wikiC - 1; j++)
                {
                    int indx = Wiki[j].CompareTo(Wiki[j + 1].getName());
                    if (indx > 0) 
                    {
                        swap(j);
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

        // 6.5 Create a custom ValidName method which will take a parameter string value from the Textbox Name and returns a Boolean after checking for duplicates. Use the built in List<T> method “Exists” to answer this requirement.
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
        // 6.3 Create a button method to ADD a new item to the list. Use a TextBox for the Name input, ComboBox for the Category, Radio group for the Structure and Multiline TextBox for the Definition.
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
            tbxName.Clear();
            cbCategory.Text = null;
            tbxDefinition.Clear();
            rbLinear.Checked = true;
            tbxName.Focus();

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

        // 6.6 Create two methods to highlight and return the values from the Radio button GroupBox. The first method must return a string value from the selected radio button (Linear or Non-Linear). The second method must send an integer index which will highlight an appropriate radio button.
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

        // 6.11 Create a ListView event so a user can select a Data Structure Name from the list of Names and the associated information will be displayed in the related text boxes combo box and radio button.
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

        // 6.6 Create two methods to highlight and return the values from the Radio button GroupBox. The first method must return a string value from the selected radio button (Linear or Non-Linear). The second method must send an integer index which will highlight an appropriate radio button.
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

        // 6.7 Create a button method that will delete the currently selected record in the ListView. Ensure the user has the option to backout of this action by using a dialog box. Display an updated version of the sorted list at the end of this process.
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

        // 6.8 Create a button method that will save the edited record of the currently selected item in the ListView. All the changes in the input controls will be written back to the list. Display an updated version of the sorted list at the end of this process.
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

        // 6.12 Create a custom method that will clear and reset the TextBoxes, ComboBox and Radio button
        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        // 6.13 Create a double click event on the Name TextBox to clear the TextBboxes, ComboBox and Radio button.
        private void lvDataStructures_DoubleClick(object sender, EventArgs e)
        {
            clear();
        }

        // 6.10 Create a button method that will use the builtin binary search to find a Data Structure name. If the record is found the associated details will populate the appropriate input controls and highlight the name in the ListView. At the end of the search process the search input TextBox must be cleared.
        private void btnSearch_Click(object sender, EventArgs e)
        {

            string text = tbxSearchBar.Text;
            List<string> names = new List<string>();
            for (int i = 0; i < Wiki.Count; i++)
            {
                names.Add(Wiki[i].getName());
                lvDataStructures.Items[i].Checked = true;
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

        // 6.14 Create two buttons for the manual open and save option; this must use a dialog box to select a file or rename a saved file. All Wiki data is stored/retrieved using a binary reader/writer file format.
        private void btnSave_Click(object sender, EventArgs e)
        {
            string dfName = "definitions.bin";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "BIN FILE|*.bin";
            saveFileDialog.Title = "Save A BIN file";
            saveFileDialog.InitialDirectory = Application.StartupPath;
            saveFileDialog.DefaultExt = "bin";
            saveFileDialog.ShowDialog();
            string fileName = saveFileDialog.FileName;
            if (saveFileDialog.FileName != "")
            {
                SaveRecord(fileName);
            }
            else
            {
                SaveRecord(dfName);
            }
        }

        private void SaveRecord(string saveFileName)
        {
            try
            {
                using (Stream stream = File.Open(saveFileName, FileMode.Create))
                {
                    using (var writer = new BinaryWriter(stream, Encoding.UTF8, false))
                    {
                        for (int i = 0; i < Wiki.Count; i++)
                        {
                            writer.Write(Wiki[i].getName());
                            writer.Write(Wiki[i].getCategory());
                            writer.Write(Wiki[i].getStructure());
                            writer.Write(Wiki[i].getDef());
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("ERROR: " + ex.ToString(), "Saving Definition Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 6.14 Create two buttons for the manual open and save option; this must use a dialog box to select a file or rename a saved file. All Wiki data is stored/retrieved using a binary reader/writer file format.
        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Application.StartupPath;
            openFileDialog.Filter = "BIN FILES|*.bin";
            openFileDialog.Title = "Open a BIN file";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                OpenRecord(openFileDialog.FileName);
            }
        }

        private void OpenRecord(string openFileName)
        {
            try
            {
                using (Stream stream = File.Open(openFileName, FileMode.Open))
                {
                    using (var reader = new BinaryReader(stream, Encoding.UTF8, false))
                    {
                        {
                            Wiki.Clear();
                            while (stream.Position < stream.Length)
                            {
                                string name = "z";
                                string category = "zz";
                                string def = "zzz";
                                name = reader.ReadString();
                                category = reader.ReadString();
                                selectRB(reader.ReadInt32());
                                def = reader.ReadString();
                                Wiki.Add(new Information(name, category, radioButtonType, def));
                            }
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("ERROR: " + ex.ToString(), "Loading A .BIN File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            displayData();
        }
        // 6.15 The Wiki application will save data when the form closes. 
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (chbAutoSave.Checked == true)
            {
                try
                {
                    using (Stream stream = File.Open("AutoSave.bin", FileMode.Create))
                    {
                        using (var writer = new BinaryWriter(stream, Encoding.UTF8, false))
                        {
                            for (int i = 0; i < Wiki.Count; i++)
                            {
                                writer.Write(Wiki[i].getName());
                                writer.Write(Wiki[i].getCategory());
                                writer.Write(Wiki[i].getStructure());
                                writer.Write(Wiki[i].getDef());
                            }
                        }
                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show("ERROR: " + ex.ToString(), "Saving Definition Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        
        private void btnAdd_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnAdd, "Add the data from the 4 controls above into the Wiki.");
        }

        private void btnClear_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnClear, "Clears the 4 controls above.");
        }

        private void btnEdit_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnEdit, "Edit data in the Wiki.\nClick on a data structure in the list, make the necessary changes in the 4 controls above then click me to edit.");
        }

        private void btnDelete_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnDelete, "Click on a data structure in the listview then click me to delete.");
        }

        private void btnSave_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnSave, "Click on me to save the data in the listview to your desired location using the .BIN file format.");
        }

        private void btnLoad_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnLoad, "Click me to load data from a .BIN file of your choosing into the listview and Wiki");
        }

        private void chbAutoSave_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(chbAutoSave, "Checked = Auto saves data from the listview. \nNot Checked = Doesn't auto save.");
        }

        private void lvDataStructures_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(lvDataStructures, "Single click to display data in the 4 controls.\nDouble click to clear the data in the 4 controls.");
        }

        private void btnSearch_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnSearch, "Enter in the name of the data structure in the textbox on the left then click me to search.");
        }
    }
}
