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
using System.Printing;
using System.IO;
using System.Windows.Markup;

namespace PPSoft_SkedgeIT
{
    /// <summary>
    /// Interaction logic for EmployeeLandingPage.xaml
    /// </summary>
    public partial class EmployeeLandingPage : Window
    {
        List<ShiftViewModel> shifts;
        public EmployeeLandingPage(EmployeeViewModel emp)
        {
            InitializeComponent();
            //bind data grid to list
            ShiftViewModel shiftObject = new ShiftViewModel();

            shifts = shiftObject.getShifts(emp.EmployeeID);
            shiftGrid.ItemsSource = shifts;

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

            StreamWriter file = new StreamWriter("temp.txt");
            file.WriteLine(shifts);
            file.Close();
            PrintDialog prtDiag = new PrintDialog();
            if (prtDiag.ShowDialog() != true) return;

            // create a document
            FixedDocument document = new FixedDocument();
            document.DocumentPaginator.PageSize = new Size(prtDiag.PrintableAreaWidth, prtDiag.PrintableAreaHeight);
            // create a page
            FixedPage page1 = new FixedPage();
            page1.Width = document.DocumentPaginator.PageSize.Width;
            page1.Height = document.DocumentPaginator.PageSize.Height;
            // add some text to the page
            TextBlock page1Text = new TextBlock();
            foreach (ShiftViewModel s in shifts)
            {
                page1Text.Text += s.ToString() + "\n";
            }
            //page1Text.Text = shiftGrid.Items.ToString();
            page1Text.FontSize = 15; // 30pt text
            page1Text.Margin = new Thickness(96); // 1 inch margin
            page1.Children.Add(page1Text);
            // add the page to the document
            PageContent page1Content = new PageContent();
            ((IAddChild)page1Content).AddChild(page1);
            document.Pages.Add(page1Content);
            // and print
            prtDiag.PrintDocument(document.DocumentPaginator, "My first document");
        }
    }
}
