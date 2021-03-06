﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using PPSoft_SkedgeITViewModels;

namespace PPSoft_SkedgeIT
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

        EmployeeViewModel employeeObject = new EmployeeViewModel();

        private void Login()
        {
            EmployeeViewModel currEmp = employeeObject.getEmployeeProfile(Convert.ToInt32(textLogin.Text));
            if (currEmp == null)
                errorText.Text = "This employee does not exist.";
            else if (textPassword.Password != currEmp.password)
            {
                errorText.Text = "The password entered does not match.";
            }
            else if(currEmp.accessLevel == "employee")
            {
                EmployeeLandingPage win2 = new EmployeeLandingPage(currEmp);
                win2.Title += currEmp.firstName + " " + currEmp.lastName;
                win2.Show();
                this.Close();
            }
            else
            {
                LandingPage win2 = new LandingPage();
                win2.Title += currEmp.firstName + " " + currEmp.lastName;
                win2.Show();
                this.Close();
            }
        }

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            Login();
        }

        private void textLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Login();
            }
        }

        private void textPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Login();
            }
        }

    }
}
