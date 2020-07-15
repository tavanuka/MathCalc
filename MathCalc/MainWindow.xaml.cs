using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MathCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            bool valid = true;
            var person = new Person();
            person.Name = FirstNameBox.ToString();
            person.LastName = LastNameBox.ToString();
            FirstNameReadOnlyBox.Text = FirstNameBox.Text;
            LastNameReadOnlyBox.Text = LastNameBox.Text;

            if (Calendar.SelectedDate != null)
            {
                person.DateOfBirth = (DateTime)Calendar.SelectedDate;
                CalendarReadOnlyBox.Text = person.DateOfBirth.ToString();
            }
            else
            {
                valid = false;
                MessageBox.Show("Please Enter a Date or Birth.", "Error");
            }

            if ((bool)CheckBox_CSV_Write.IsChecked && valid)
                MessageBox.Show("Im gay");
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ClearAllBoxes();
        }

        public void ClearAllBoxes()
        {
            string str = null;
            FirstNameBox.Text = str;
            LastNameBox.Text = str;
            Calendar.SelectedDate = DateTime.Now;
            FirstNameReadOnlyBox.Text = str;
            LastNameReadOnlyBox.Text = str;
            CalendarReadOnlyBox.Text = str;
            CheckBox_CSV_Write.IsChecked = false;
        }

        private void CheckBox_CSV_Write_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void ReadCSVButton_Click(object sender, RoutedEventArgs e)
        {

            var func = new Function();
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "CSV files (*.csv)|*.csv";


            if ((bool)dialog.ShowDialog())
            {
                func.CSV_File_Reader(dialog.FileName);
            }
            if (func.rec.Count() == 1)
            {
                FirstNameReadOnlyBox.Text = func.rec[0].Name;
                LastNameReadOnlyBox.Text = func.rec[0].LastName;
                CalendarReadOnlyBox.Text = func.rec[0].DateOfBirth
                                                      .ToString();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
