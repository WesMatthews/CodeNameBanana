using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using PPSoft_SkedgeITViewModels;

namespace PPSoft_SkedgeIT
{
    /// <summary>
    /// Interaction logic for addEmployee.xaml
    /// </summary>
    public partial class addEmployee : Window
    {
        public addEmployee()
        {
            InitializeComponent();
            List<int> hours = new List<int>();
            for (int i = 0; i < 24; i++)
            {
                hours.Add(i);
            }
            List<int> minutes = new List<int>();
            for (int i = 0; i < 60; i++)
            {
                minutes.Add(i);
            }

            cbSundayStartHr.ItemsSource = hours;
            cbSundayStartHr.SelectedIndex = 0;
            cbSundayStartMin.ItemsSource = minutes;
            cbSundayStartMin.SelectedIndex = 0;
            cbSundayEndHr.ItemsSource = hours;
            cbSundayEndHr.SelectedIndex = 0;
            cbSundayEndMin.ItemsSource = minutes;
            cbSundayEndMin.SelectedIndex = 0;

            cbMondayStartHr.ItemsSource = hours;
            cbMondayStartHr.SelectedIndex = 0;
            cbMondayStartMin.ItemsSource = minutes;
            cbMondayStartMin.SelectedIndex = 0;
            cbMondayEndHr.ItemsSource = hours;
            cbMondayEndHr.SelectedIndex = 0;
            cbMondayEndMin.ItemsSource = minutes;
            cbMondayEndMin.SelectedIndex = 0;

            cbTuesStartHr.ItemsSource = hours;
            cbTuesStartHr.SelectedIndex = 0;
            cbTuesStartMin.ItemsSource = minutes;
            cbTuesStartMin.SelectedIndex = 0;
            cbTuesEndHr.ItemsSource = hours;
            cbTuesEndHr.SelectedIndex = 0;
            cbTuesEndMin.ItemsSource = minutes;
            cbTuesEndMin.SelectedIndex = 0;

            cbWedStartHr.ItemsSource = hours;
            cbWedStartHr.SelectedIndex = 0;
            cbWedStartMin.ItemsSource = minutes;
            cbWedStartMin.SelectedIndex = 0;
            cbWedEndHr.ItemsSource = hours;
            cbWedEndHr.SelectedIndex = 0;
            cbWedEndMin.ItemsSource = minutes;
            cbWedEndMin.SelectedIndex = 0;

            cbThursStartHr.ItemsSource = hours;
            cbThursStartHr.SelectedIndex = 0;
            cbThursStartMin.ItemsSource = minutes;
            cbThursStartMin.SelectedIndex = 0;
            cbThursEndHr.ItemsSource = hours;
            cbThursEndHr.SelectedIndex = 0;
            cbThursEndMin.ItemsSource = minutes;
            cbThursEndMin.SelectedIndex = 0;

            cbFriStartHr.ItemsSource = hours;
            cbFriStartHr.SelectedIndex = 0;
            cbFriStartMin.ItemsSource = minutes;
            cbFriStartMin.SelectedIndex = 0;
            cbFriEndHr.ItemsSource = hours;
            cbFriEndHr.SelectedIndex = 0;
            cbFriEndMin.ItemsSource = minutes;
            cbFriEndMin.SelectedIndex = 0;

            cbSatStartHr.ItemsSource = hours;
            cbSatStartHr.SelectedIndex = 0;
            cbSatStartMin.ItemsSource = minutes;
            cbSatStartMin.SelectedIndex = 0;
            cbSatEndHr.ItemsSource = hours;
            cbSatEndHr.SelectedIndex = 0;
            cbSatEndMin.ItemsSource = minutes;
            cbSatEndMin.SelectedIndex = 0;
        }

        private void AddEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeeViewModel emp = new EmployeeViewModel();
            emp.firstName = tbFirstName.Text;
            emp.lastName = tbLastName.Text;
            emp.password = tbPassword.Text;
            emp.accessLevel = tbAccessLevel.Text;
            emp.SunStart = new DateTime(0,0,0,Convert.ToInt32(cbSundayStartHr.SelectedValue),
                Convert.ToInt32(cbSundayStartMin.SelectedValue),0);
            emp.SunEnd = new DateTime(0, 0, 0, Convert.ToInt32(cbSundayEndHr.SelectedValue),
                Convert.ToInt32(cbSundayEndMin.SelectedValue), 0);
            emp.MonStart = DateTime.Now;
            emp.MonEnd = DateTime.Now;
            emp.TueStart = DateTime.Now;
            emp.TueEnd = DateTime.Now;
            emp.WedStart = DateTime.Now;
            emp.WedEnd = DateTime.Now;
            emp.ThuStart = DateTime.Now;
            emp.ThuEnd = DateTime.Now;
            emp.FriStart = DateTime.Now;
            emp.FriEnd = DateTime.Now;
            emp.SatStart = DateTime.Now;
            emp.SatEnd = DateTime.Now;
            emp.Register();
            MessageBox.Show(emp.Message);
        }
    }
}
