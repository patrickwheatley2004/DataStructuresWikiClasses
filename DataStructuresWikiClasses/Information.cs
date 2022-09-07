using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataStructuresWikiClasses
{
    // 6.1 Create a separate class file to hold the four data items of the Data Structure (use the Data Structure Matrix as a guide). Use private properties for the fields which must be of type “string”. The class file must have separate setters and getters, add an appropriate IComparable for the Name attribute. Save the class as “Information.cs”.
    internal class Information : IComparable<string>
    {
        private string name;
        private string category;
        private string structure;
        private string definition;

        public int CompareTo(string iname)
        {
            if (iname != null)
            {
                return this.name.CompareTo(iname);
            }
            else
            {
                MessageBox.Show("Input was null...", "IComparible CompareTo - Sorting after Add", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return -1;
            }
        }
        public  Information()
        {
            
        }

        public Information(string newName, string newCategory, string newStructure, string newDef)
        {
            name = newName;
            category = newCategory;
            structure = newStructure;
            definition = newDef;
        }

        public string getName()
        {
            return name;
        }
        public void setName(string newName)
        {
            name = newName;
        }

        public string getCategory()
        {
            return category;
        }
        public void setCategory(string newCat)
        {
            category = newCat;
        }

        public int getStructure()
        {
            int strucType = 1;
            if (structure == "Linear")
            {
                strucType = 0;
            }
            return strucType;
        }
        public void setStructure(string newStruc)
        {
            structure = newStruc;
        }

        public string getDef()
        {
            return definition;
        }
        public void setDef(string newDef)
        {
            definition = newDef;
        }

    }
}
