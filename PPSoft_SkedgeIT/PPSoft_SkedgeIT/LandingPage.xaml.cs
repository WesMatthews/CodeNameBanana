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
        }

        public static bool hasNumber = false;
        public static bool hasUpper = false;

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

    }
}
