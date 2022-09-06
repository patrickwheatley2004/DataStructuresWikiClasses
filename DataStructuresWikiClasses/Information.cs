using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresWikiClasses
{
    internal class Information
    {
        private string name;
        private string category;
        private string structure;
        private string definition;
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
