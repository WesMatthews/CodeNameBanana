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
    /// Interaction logic for AddShift.xaml
    /// </summary>
    public partial class AddShift : Window
    {
          
        public AddShift()
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
            cbStartHr.ItemsSource = hours;
            cbStartHr.SelectedIndex = 0;
            cbStartMin.ItemsSource = minutes;
            cbStartMin.SelectedIndex = 0; 
            cbEndHr.ItemsSource = hours;
            cbEndHr.SelectedIndex = 0;
            cbEndMin.ItemsSource = minutes;
            cbEndMin.SelectedIndex = 0;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();   
        }

        private void btnAddShift_Click(object sender, RoutedEventArgs e)
        {
            //logic to add shift here
            ShiftViewModel shiftView = new ShiftViewModel();
            DateTime startTime = (Convert.ToDateTime(dpStartDate.Text));
            startTime = startTime.AddHours(Convert.ToInt32(cbStartHr.SelectedItem));
            startTime = startTime.AddMinutes(Convert.ToInt32(cbStartMin.SelectedItem));
            shiftView.start = startTime;
            DateTime endTime = (Convert.ToDateTime(dpEndDate.Text));
            endTime = endTime.AddHours(Convert.ToInt32(cbEndHr.SelectedItem));
            endTime = endTime.AddMinutes(Convert.ToInt32(cbEndMin.SelectedItem));
            shiftView.end = endTime;
            shiftView.employeeID = Convert.ToInt32(tbEmpID.Text);

            shiftView.AddShift();
            this.Close();
        }
    }
}
