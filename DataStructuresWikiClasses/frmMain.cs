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

        internal Information Information
        {
            get => default;
            set
            {
            }
        }

        // 6.2 Create a global List<T> of type Information called Wiki.
        List<Information> Wiki = new List<Information>();
        string radioButtonType = "Linear";
        int radioButtonIndex = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadComboBox();
        }

        // 6.4 Create a custom method to populate the ComboBox when the Form Load method is called. The six categories must be read from a simple text file.
        private void LoadComboBox()
        {
            // Checking if the file exists, if it eists then add the items to the combobox, if it doesn't exist then update the status strip.
            if (File.Exists("Categories.txt"))
            {
                cbCategory.Items.Clear();
                string[] categories = File.ReadAllLines("Categories.txt");
                cbCategory.Items.AddRange(categories);
            }
            else
            {
                UpdateSS("Categories could not be loaded.");
            }

        }

        // A function to update the status strip so I don't have to use the "clear" function all the time.
        private void UpdateSS(string input)
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
                    int indx = Wiki[j].CompareTo(Wiki[j + 1].GetName());
                    if (indx > 0) 
                    {
                        Swap(j);
                    }
                }
            }
        }

        private void Swap(int index)
        {
            Information temp = Wiki[index];
            Wiki[index] = Wiki[index + 1];
            Wiki[index + 1] = temp;
        }

        // 6.5 Create a custom ValidName method which will take a parameter string value from the Textbox Name and returns a Boolean after checking for duplicates. Use the built in List<T> method “Exists” to answer this requirement.
        private bool ValidName(string input)
        {
            string[] invalidLetters = new string[] { "!", "@", "#", "$", "%", "^", "&", "*", "+", "=", ";", ":", "<", ">", "/", "\\", "'", "(",")" };
            bool isValid = true;
            List<string> dummyNames = new List<string>();
            for (int i = 0; i < Wiki.Count; i++)
            {
                dummyNames.Add(Wiki[i].GetName());
            }
            isValid = dummyNames.Contains(input);

            if (isValid == false)
            {
                if (!string.IsNullOrEmpty(tbxName.Text) && !string.IsNullOrEmpty(cbCategory.Text) && radioButtonIndex >= 0 && !string.IsNullOrEmpty(tbxDefinition.Text))
                {
                    isValid = false;
                }
                else
                {
                    isValid = true;
                }
            }

            if (isValid == false)
            {
                for (int i = 0; i < invalidLetters.Length; i++)
                {
                    if (input.Contains(invalidLetters[i]))
                    {
                        isValid = true;
                    }
                }
            }

            return isValid;

        }
        // 6.3 Create a button method to ADD a new item to the list. Use a TextBox for the Name input, ComboBox for the Category, Radio group for the Structure and Multiline TextBox for the Definition.
        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool isntValid = true;

            isntValid = ValidName(tbxName.Text);
            if (isntValid)
            {
                MessageBox.Show("Error: " + tbxName.Text + " already exists in the wiki, one of the inputs has nothing inside or it contains an illegal character!", "Adding Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateSS("Error: " + tbxName.Text + " already exists in the wiki, one of the inputs has nothing inside or it contains an illegal character!");
            }
            else
            {
                Wiki.Add(new Information(tbxName.Text, cbCategory.Text, radioButtonType, tbxDefinition.Text));
                DisplayData();
                UpdateSS(tbxName.Text + " has been added to the Wiki!");
                tbxName.Clear();
                cbCategory.Text = null;
                tbxDefinition.Clear();
                rbLinear.Checked = true;
                tbxName.Focus();
            }

        }
        // 6.9 Create a single custom method that will sort and then display the Name and Category from the wiki information in the list.
        private void DisplayData()
        {
            lvDataStructures.Items.Clear();
            Sort();
            for (int i = 0; i < Wiki.Count; i++)
            {
                ListViewItem lv1 = new ListViewItem(Wiki[i].GetName(), 0);
                lv1.SubItems.Add(Wiki[i].GetCategory());
                lvDataStructures.Items.Add(lv1);
            }
        }

        // 6.11 Create a ListView event so a user can select a Data Structure Name from the list of Names and the associated information will be displayed in the related text boxes combo box and radio button.
        private void DisplayIntoText(int index)
        {
            tbxName.Text = Wiki[index].GetName();
            cbCategory.Text = Wiki[index].GetCategory();
            radioButtonIndex = Wiki[index].GetStructure();
            tbxDefinition.Text = Wiki[index].GetDef();
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
            DisplayData();
        }

        // 6.11 Create a ListView event so a user can select a Data Structure Name from the list of Names and the associated information will be displayed in the related text boxes combo box and radio button.
        private void lvDataStructures_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DisplayIntoText(lvDataStructures.SelectedIndices[0]);
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
                string text = Wiki[index].GetName();

                DialogResult dr = MessageBox.Show("Are you sure you want to delete " + text + "?", "Are you sure you want to delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    Wiki.RemoveAt(index);
                    UpdateSS(text + " was deleted from the Wiki!");
                }
                else if (dr == DialogResult.No)
                {
                    UpdateSS(text + " has not been deleted from the Wiki!");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error, nothing selected to delete.", "Deleting Definition", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateSS("Error, nothing selected to delete.");
            }

            DisplayData();
        }

        // 6.8 Create a button method that will save the edited record of the currently selected item in the ListView. All the changes in the input controls will be written back to the list. Display an updated version of the sorted list at the end of this process.
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int index = lvDataStructures.SelectedIndices[0];
                string text = Wiki[index].GetName();

                bool exists = true;
                exists = ValidName(tbxName.Text);
                if (exists)
                {
                    if (text == tbxName.Text)
                    {
                        Wiki[index].SetName(tbxName.Text);
                        Wiki[index].SetStructure(radioButtonType);
                        Wiki[index].SetCategory(cbCategory.Text);
                        Wiki[index].SetDef(tbxDefinition.Text);
                        UpdateSS(text + " was edited as is now " + tbxName.Text + "!");
                    }
                    else
                    {
                        MessageBox.Show("Error: " + tbxName.Text + " already exists in the wiki!", "Editing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        UpdateSS("Error: " + tbxName.Text + " already exists in the wiki!");
                    }
                }
                else
                {
                    Wiki[index].SetName(tbxName.Text);
                    Wiki[index].SetStructure(radioButtonType);
                    Wiki[index].SetCategory(cbCategory.Text);
                    Wiki[index].SetDef(tbxDefinition.Text);
                    UpdateSS(text + " was edited as is now " + tbxName.Text + "!");
                }


            }
            catch (Exception)
            {
                MessageBox.Show("Error, nothing selected to edit.", "Editing Definition", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateSS("Error, nothing selected to edit.");
            }

            DisplayData();
        }

        // 6.12 Create a custom method that will clear and reset the TextBoxes, ComboBox and Radio button
        private void ClearInputControls()
        {
            tbxName.Clear();
            cbCategory.Text = null;
            rbLinear.Checked = false;
            rbNonLinear.Checked = false;
            tbxDefinition.Clear();
            radioButtonIndex = -1;
            radioButtonType = null;
            UpdateSS("Data in the textboxes has been successfully cleared");
        }

        // 6.12 Create a custom method that will clear and reset the TextBoxes, ComboBox and Radio button
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputControls();
        }

        // 6.13 Create a double click event on the Name TextBox to clear the TextBboxes, ComboBox and Radio button.
        private void lvDataStructures_DoubleClick(object sender, EventArgs e)
        {
            ClearInputControls();
        }

        // 6.10 Create a button method that will use the builtin binary search to find a Data Structure name. If the record is found the associated details will populate the appropriate input controls and highlight the name in the ListView. At the end of the search process the search input TextBox must be cleared.
        private void btnSearch_Click(object sender, EventArgs e)
        {

            string text = tbxSearchBar.Text;
            List<string> names = new List<string>();
            for (int i = 0; i < Wiki.Count; i++)
            {
                names.Add(Wiki[i].GetName());
                lvDataStructures.Items[i].Checked = true;
            }
            int indx = names.BinarySearch(text);
            if (indx < 0)
            {
                MessageBox.Show("Search for " + text + " was not found.", "Couldn't find search term.", MessageBoxButtons.OK, MessageBoxIcon.Question);
                UpdateSS("Search for " + text + " was not found.");
            }
            else
            {
                DisplayIntoText(indx);
                lvDataStructures.Items[indx].Focused = true;
                lvDataStructures.Items[indx].Selected = true;
                UpdateSS(text + " was found!");
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
                            writer.Write(Wiki[i].GetName());
                            writer.Write(Wiki[i].GetCategory());
                            writer.Write(Wiki[i].GetStructure());
                            writer.Write(Wiki[i].GetDef());
                        }
                        UpdateSS("The file was successfully saved!");
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
                            string fileName = Path.GetFileName(openFileName);
                            UpdateSS(fileName + " was opened!");
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("ERROR: " + ex.ToString(), "Loading A .BIN File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DisplayData();
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
                                writer.Write(Wiki[i].GetName());
                                writer.Write(Wiki[i].GetCategory());
                                writer.Write(Wiki[i].GetStructure());
                                writer.Write(Wiki[i].GetDef());
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
        // 6.13 Create a double click event on the Name TextBox to clear the TextBboxes, ComboBox and Radio button.
        private void tbxName_DoubleClick(object sender, EventArgs e)
        {
            ClearInputControls();
        }
    }
}
