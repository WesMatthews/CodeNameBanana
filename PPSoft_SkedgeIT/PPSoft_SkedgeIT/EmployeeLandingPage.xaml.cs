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
    /// Interaction logic for EmployeeLandingPage.xaml
    /// </summary>
    public partial class EmployeeLandingPage : Window
    {
        int empId;

        public EmployeeLandingPage(EmployeeViewModel emp)
        {
            InitializeComponent();
            //bind data grid to list
            ShiftViewModel shiftObject = new ShiftViewModel();
            List<ShiftViewModel> shifts;
            shifts = shiftObject.getShifts(emp.EmployeeID);
            shiftGrid.ItemsSource = shifts;

            empId = emp.EmployeeID;
        }


        private void TabItem_Loaded(object sender, RoutedEventArgs e)
        {
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

            cbEmpAvailSundayStartHr.ItemsSource = hours;
            cbEmpAvailSundayStartMin.ItemsSource = minutes;
            cbEmpAvailSundayEndHr.ItemsSource = hours;
            cbEmpAvailSundayEndMin.ItemsSource = minutes;

            cbEmpAvailMondayStartHr.ItemsSource = hours;
            cbEmpAvailMondayStartMin.ItemsSource = minutes;
            cbEmpAvailMondayEndHr.ItemsSource = hours;
            cbEmpAvailMondayEndMin.ItemsSource = minutes;

            cbEmpAvailTuesStartHr.ItemsSource = hours;
            cbEmpAvailTuesStartMin.ItemsSource = minutes;
            cbEmpAvailTuesEndHr.ItemsSource = hours;
            cbEmpAvailTuesEndMin.ItemsSource = minutes;

            cbEmpAvailWedStartHr.ItemsSource = hours;
            cbEmpAvailWedStartMin.ItemsSource = minutes;
            cbEmpAvailWedEndHr.ItemsSource = hours;
            cbEmpAvailWedEndMin.ItemsSource = minutes;

            cbEmpAvailThursStartHr.ItemsSource = hours;
            cbEmpAvailThursStartMin.ItemsSource = minutes;
            cbEmpAvailThursEndHr.ItemsSource = hours;
            cbEmpAvailThursEndMin.ItemsSource = minutes;

            cbEmpAvailFriStartHr.ItemsSource = hours;
            cbEmpAvailFriStartMin.ItemsSource = minutes;
            cbEmpAvailFriEndHr.ItemsSource = hours;
            cbEmpAvailFriEndMin.ItemsSource = minutes;

            cbEmpAvailSatStartHr.ItemsSource = hours;
            cbEmpAvailSatStartMin.ItemsSource = minutes;
            cbEmpAvailSatEndHr.ItemsSource = hours;
            cbEmpAvailSatEndMin.ItemsSource = minutes;

            EmployeeViewModel getEmp = new EmployeeViewModel();
            try
            {

                EmployeeViewModel emp = getEmp.getEmployeeProfile(empId);
                cbEmpAvailSundayStartHr.SelectedValue = emp.SunStart.Hour;
                cbEmpAvailSundayStartMin.SelectedValue = emp.SunStart.Minute;
                cbEmpAvailSundayEndHr.SelectedValue = emp.SunEnd.Hour;
                cbEmpAvailSundayEndMin.SelectedValue = emp.SunEnd.Minute;
                cbEmpAvailMondayStartHr.SelectedValue = emp.MonStart.Hour;
                cbEmpAvailMondayStartMin.SelectedValue = emp.MonStart.Minute;
                cbEmpAvailMondayEndHr.SelectedValue = emp.MonEnd.Hour;
                cbEmpAvailMondayEndMin.SelectedValue = emp.MonEnd.Minute;
                cbEmpAvailTuesStartHr.SelectedValue = emp.TueStart.Hour;
                cbEmpAvailTuesStartMin.SelectedValue = emp.TueStart.Minute;
                cbEmpAvailTuesEndHr.SelectedValue = emp.TueEnd.Hour;
                cbEmpAvailTuesEndMin.SelectedValue = emp.TueEnd.Minute;
                cbEmpAvailWedStartHr.SelectedValue = emp.WedStart.Hour;
                cbEmpAvailWedStartMin.SelectedValue = emp.WedStart.Minute;
                cbEmpAvailWedEndHr.SelectedValue = emp.WedEnd.Hour;
                cbEmpAvailWedEndMin.SelectedValue = emp.WedEnd.Minute;
                cbEmpAvailThursStartHr.SelectedValue = emp.ThuStart.Hour;
                cbEmpAvailThursStartMin.SelectedValue = emp.ThuStart.Minute;
                cbEmpAvailThursEndHr.SelectedValue = emp.ThuEnd.Hour;
                cbEmpAvailThursEndMin.SelectedValue = emp.ThuEnd.Minute;
                cbEmpAvailFriStartHr.SelectedValue = emp.FriStart.Hour;
                cbEmpAvailFriStartMin.SelectedValue = emp.FriStart.Minute;
                cbEmpAvailFriEndHr.SelectedValue = emp.FriEnd.Hour;
                cbEmpAvailFriEndMin.SelectedValue = emp.FriEnd.Minute;
                cbEmpAvailSatStartHr.SelectedValue = emp.SatStart.Hour;
                cbEmpAvailSatStartMin.SelectedValue = emp.SatStart.Minute;
                cbEmpAvailSatEndHr.SelectedValue = emp.SatEnd.Hour;
                cbEmpAvailSatEndMin.SelectedValue = emp.SatEnd.Minute;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

        private void EmpAvailChange_Click(object sender, RoutedEventArgs e)
        {
            EmployeeViewModel getEmp = new EmployeeViewModel();
            try
            {
                if (MessageBox.Show("Are you sure you would like to submit this availability?", "Availability",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    EmployeeViewModel emp = getEmp.getEmployeeProfile(empId);
                    emp.SunStart = new DateTime(1, 1, 1, Convert.ToInt32(cbEmpAvailSundayStartHr.SelectedValue),
                    Convert.ToInt32(cbEmpAvailSundayStartMin.SelectedValue), 0);
                    emp.SunEnd = new DateTime(1, 1, 1, Convert.ToInt32(cbEmpAvailSundayEndHr.SelectedValue),
                        Convert.ToInt32(cbEmpAvailSundayEndMin.SelectedValue), 0);
                    emp.MonStart = new DateTime(1, 1, 1, Convert.ToInt32(cbEmpAvailMondayStartHr.SelectedValue),
                        Convert.ToInt32(cbEmpAvailMondayStartMin.SelectedValue), 0);
                    emp.MonEnd = new DateTime(1, 1, 1, Convert.ToInt32(cbEmpAvailMondayEndHr.SelectedValue),
                        Convert.ToInt32(cbEmpAvailMondayEndMin.SelectedValue), 0);
                    emp.TueStart = new DateTime(1, 1, 1, Convert.ToInt32(cbEmpAvailTuesStartHr.SelectedValue),
                        Convert.ToInt32(cbEmpAvailTuesStartMin.SelectedValue), 0);
                    emp.TueEnd = new DateTime(1, 1, 1, Convert.ToInt32(cbEmpAvailTuesEndHr.SelectedValue),
                        Convert.ToInt32(cbEmpAvailTuesEndMin.SelectedValue), 0);
                    emp.WedStart = new DateTime(1, 1, 1, Convert.ToInt32(cbEmpAvailWedStartHr.SelectedValue),
                        Convert.ToInt32(cbEmpAvailWedStartMin.SelectedValue), 0);
                    emp.WedEnd = new DateTime(1, 1, 1, Convert.ToInt32(cbEmpAvailWedEndHr.SelectedValue),
                        Convert.ToInt32(cbEmpAvailWedEndMin.SelectedValue), 0);
                    emp.ThuStart = new DateTime(1, 1, 1, Convert.ToInt32(cbEmpAvailThursStartHr.SelectedValue),
                        Convert.ToInt32(cbEmpAvailThursStartMin.SelectedValue), 0);
                    emp.ThuEnd = new DateTime(1, 1, 1, Convert.ToInt32(cbEmpAvailThursEndHr.SelectedValue),
                        Convert.ToInt32(cbEmpAvailThursEndMin.SelectedValue), 0);
                    emp.FriStart = new DateTime(1, 1, 1, Convert.ToInt32(cbEmpAvailFriStartHr.SelectedValue),
                        Convert.ToInt32(cbEmpAvailFriStartMin.SelectedValue), 0);
                    emp.FriEnd = new DateTime(1, 1, 1, Convert.ToInt32(cbEmpAvailFriEndHr.SelectedValue),
                        Convert.ToInt32(cbEmpAvailFriEndMin.SelectedValue), 0);
                    emp.SatStart = new DateTime(1, 1, 1, Convert.ToInt32(cbEmpAvailSatStartHr.SelectedValue),
                        Convert.ToInt32(cbEmpAvailSatStartMin.SelectedValue), 0);
                    emp.SatEnd = new DateTime(1, 1, 1, Convert.ToInt32(cbEmpAvailSatEndHr.SelectedValue),
                        Convert.ToInt32(cbEmpAvailSatEndMin.SelectedValue), 0);
                    emp.UpdateEmployee(empId);
                    MessageBox.Show(emp.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}
