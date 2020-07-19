using CsvHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MathCalc
{
    public delegate void PersonAssignment(List<Person> person);
    public delegate void EventHandlerDateTime(object sender, EventArgs e);
    public class Function 
    {

        
        private string _filePath;
        public string FilePath
        {
            get { return _filePath; }
            set { _filePath = this.FilePath; }
        }


       

        public List<Person> CSV_File_Reader(string filepath)
        {
            using (var reader = new StreamReader(filepath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                records = csv.GetRecords<Person>();
                rec = records.ToList();
            }

            if (rec.Count() > 1)
            {
                foreach (var item in rec)
                {
                    MessageBox.Show($"{item.Name}\n{item.LastName}\n{item.DateOfBirth}");
                }
            }


            return rec;
        }
        public void CSV_File_Writer(string filepath, List<Person> s)
        {
           
            
            IEnumerable<Person> @enum = s;
            using (var writer = new StreamWriter(filepath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                
                csv.WriteRecords(@enum);
            }
        }

        public List<Person> rec;
        public IEnumerable<Person> records;
    }

}
