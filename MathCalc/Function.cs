using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MathCalc
{
    // public delegate void 
    public class Function : MainWindow
    {
        private string _filePath;
        public string FilePath
        {
            get { return _filePath; }
            set { _filePath = this.FilePath; }
        }

        public List<Person> CSV_File_Reader(string s)
        {
            using (var reader = new StreamReader(_filePath = s))
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
            else
                return rec;
            
            return rec;
        }
        public void CSV_File_Writer(string s)
        {
            var person = new Person();
            using (var writer = new StreamWriter(_filePath = s))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {

            }
        }
        public List<Person> rec;
        public IEnumerable<Person> records;
    }

}
