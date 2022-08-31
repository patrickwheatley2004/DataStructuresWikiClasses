using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresWikiClasses
{
    internal class DataStructures
    {
        private string name;
        private string category;
        private bool structure;
        private string definition;
        public  DataStructures()
        {
            Console.WriteLine("In Constructor");
        }

        public DataStructures(string newName, string newCategory, bool newStructure, string newDef)
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

        public string getCategory()
        {
            return category;
        }

        public bool getStructure()
        {
            return structure;
        }

        public string getDef()
        {
            return definition;
        }

    }
}
