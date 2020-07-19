using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MathCalc
{
    public class Person 
    {
        public Person()
        {
            Data = new List<Person>();

        }
        private List<Person> writeOutput;
        private DateTime _dateOfBirth;
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }
            set
            {
                _dateOfBirth = value;
            }
        }
        public int ID { get; set; }
        public List<Person> Data
        {
            get; set;
        }

    }
}
