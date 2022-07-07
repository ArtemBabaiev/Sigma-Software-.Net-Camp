using HW_13.entities;
using HW_13.file_work;
using HW_13.parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_13.generators
{
    internal class PersonGenerator
    {
        public List<Person> LoadFromFile()
        {
            FileManipulation file = new FileManipulation();
            List<Person> persons = new List<Person>();
            List<string> personsStr = file.ReadLines();
            file.ClearFile();

            foreach (var item in personsStr)
            {
                persons.Add(PersonParser.Parse(item));
            }

            return persons;
        }
    }
}
