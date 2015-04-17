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
        public EmployeeLandingPage(EmployeeViewModel emp)
        {
            InitializeComponent();
            //bind data grid to list
            ShiftViewModel shiftObject = new ShiftViewModel();
            List<ShiftViewModel> shifts;
            shifts = shiftObject.getShifts(emp.EmployeeID);
            shiftGrid.ItemsSource = shifts;

        }
    }
}
