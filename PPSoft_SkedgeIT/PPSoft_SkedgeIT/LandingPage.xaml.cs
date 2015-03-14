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
using System.Windows.Documents;
using System.Printing;
using PPSoft_SkedgeITViewModels;

namespace PPSoft_SkedgeIT
{
    /// <summary>
    /// Interaction logic for LandingPage.xaml
    /// </summary>
    public partial class LandingPage : Window
    {
        public LandingPage()
        {
            InitializeComponent();
            radioByDate.IsChecked = true;
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

        public static bool hasNumber = false;
        public static bool hasUpper = false;
        List<ShiftViewModel> shifts;
        ShiftViewModel shiftObject = new ShiftViewModel();

        /// <summary>
        /// Checks string for password strength.
        /// </summary>
        /// <param name="password"></param>
        /// <returns>Returns bool saying if the password is strong enough</returns>
        public static bool pwCheck(string password)
        {
            int idx = 0;
            if (password.Length >= 8)
            {
                while ((!hasNumber || !hasUpper) && idx < password.Length)
                {
                    if (Char.IsUpper(password[idx]))
                        hasUpper = true;
                    else if (Char.IsDigit(password[idx]))
                        hasNumber = true;
                    idx++;
                }
            }
            return (hasNumber && hasUpper);
        }

        private void radioByDate_Checked(object sender, RoutedEventArgs e)
        {
            tbEmployeeID.Visibility = System.Windows.Visibility.Hidden;
            buttonSchedulesByEmpID.Visibility = System.Windows.Visibility.Hidden;
            selectedDate.Visibility = System.Windows.Visibility.Visible;
            buttonSchedulesByDate.Visibility = System.Windows.Visibility.Visible;
            scheduleLabel.Content = "Schedule Date";
        }

        private void radioByEmpId_Checked(object sender, RoutedEventArgs e)
        {
            tbEmployeeID.Visibility = System.Windows.Visibility.Visible;
            buttonSchedulesByEmpID.Visibility = System.Windows.Visibility.Visible;
            selectedDate.Visibility = System.Windows.Visibility.Hidden;
            buttonSchedulesByDate.Visibility = System.Windows.Visibility.Hidden;
            scheduleLabel.Content = "Employee ID";
        }

        private void buttonSchedulesByDate_Click(object sender, RoutedEventArgs e)
        {
            if (!(selectedDate.Text).Equals(""))
            {
                shifts = shiftObject.getShifts((Convert.ToDateTime(selectedDate.Text).Date));
                shiftGrid.ItemsSource = shifts;
            }

            else
            {
                MessageBox.Show("Select a Date", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void buttonSchedulesByEmpID_Click(object sender, RoutedEventArgs e)
        {
            //bind data grid to list
            shifts = shiftObject.getShifts(Convert.ToInt32(tbEmployeeID.Text));
            shiftGrid.ItemsSource = shifts;
        }
            
        private void removeShift_Click(object sender, RoutedEventArgs e)
        {
            if (shiftGrid.SelectedItem != null)
            {
                ShiftViewModel temp = (ShiftViewModel)shiftGrid.SelectedItem;
                shiftObject.Delete(temp.employeeID);
                shiftGrid.Items.Refresh();
            }
        }


        private void AddEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeeViewModel emp = new EmployeeViewModel();
            emp.firstName = tbFirstName.Text;
            emp.lastName = tbLastName.Text;
            emp.password = tbPassword.Password;
            emp.accessLevel = tbAccessLevel.Text;
            emp.SunStart = new DateTime(1, 1, 1, Convert.ToInt32(cbSundayStartHr.SelectedValue),
                Convert.ToInt32(cbSundayStartMin.SelectedValue), 1);
            emp.SunEnd = new DateTime(1,1,1, Convert.ToInt32(cbSundayEndHr.SelectedValue),
                Convert.ToInt32(cbSundayEndMin.SelectedValue), 1);
            emp.MonStart = new DateTime(1,1,1, Convert.ToInt32(cbMondayStartHr.SelectedValue),
                Convert.ToInt32(cbMondayStartMin.SelectedValue), 1);
            emp.MonEnd = new DateTime(1, 1, 1, Convert.ToInt32(cbMondayEndHr.SelectedValue),
                Convert.ToInt32(cbMondayEndMin.SelectedValue), 1);
            emp.TueStart = new DateTime(1, 1, 1, Convert.ToInt32(cbTuesStartHr.SelectedValue),
                Convert.ToInt32(cbTuesStartMin.SelectedValue), 1);
            emp.TueEnd = new DateTime(1, 1, 1, Convert.ToInt32(cbTuesEndHr.SelectedValue),
                Convert.ToInt32(cbTuesEndMin.SelectedValue), 1);
            emp.WedStart = new DateTime(1, 1, 1, Convert.ToInt32(cbWedStartHr.SelectedValue),
                Convert.ToInt32(cbWedStartMin.SelectedValue), 1);
            emp.WedEnd = new DateTime(1, 1, 1, Convert.ToInt32(cbWedEndHr.SelectedValue),
                Convert.ToInt32(cbWedEndMin.SelectedValue), 1);
            emp.ThuStart = new DateTime(1, 1, 1, Convert.ToInt32(cbThursStartHr.SelectedValue),
                Convert.ToInt32(cbThursStartMin.SelectedValue), 1);
            emp.ThuEnd = new DateTime(1, 1, 1, Convert.ToInt32(cbThursEndHr.SelectedValue),
                Convert.ToInt32(cbThursEndMin.SelectedValue), 1);
            emp.FriStart = new DateTime(1, 1, 1, Convert.ToInt32(cbFriStartHr.SelectedValue),
                Convert.ToInt32(cbFriStartMin.SelectedValue), 1);
            emp.FriEnd = new DateTime(1, 1, 1, Convert.ToInt32(cbFriEndHr.SelectedValue),
                Convert.ToInt32(cbFriEndMin.SelectedValue), 1);
            emp.SatStart = new DateTime(1, 1, 1, Convert.ToInt32(cbSatStartHr.SelectedValue),
                Convert.ToInt32(cbSatStartMin.SelectedValue), 1);
            emp.SatEnd = new DateTime(1, 1, 1, Convert.ToInt32(cbSatEndHr.SelectedValue),
                Convert.ToInt32(cbSatEndMin.SelectedValue), 1);
            emp.Register();
            MessageBox.Show(emp.Message);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog prtDiag = new PrintDialog();
            prtDiag.ShowDialog();

        }

    }
}
