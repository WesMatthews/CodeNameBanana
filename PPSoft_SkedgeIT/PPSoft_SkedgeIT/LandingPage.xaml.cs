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
    /// Interaction logic for LandingPage.xaml
    /// </summary>
    public partial class LandingPage : Window
    {
        public LandingPage()
        {
            InitializeComponent();
            radioByDate.IsChecked = true;
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
            //MAKES GUPTA HAPPEN
            shifts = shiftObject.getShifts((Convert.ToDateTime(selectedDate.Text).Date));
            shiftGrid.ItemsSource = shifts;
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

    }
}
