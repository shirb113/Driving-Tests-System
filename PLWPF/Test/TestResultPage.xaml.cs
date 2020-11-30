using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using BE;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for TestResultPage.xaml
    /// </summary>
    public partial class TestResultPage : Page
    {
        IBL bl;
        public TestResultPage()
        {
            bl = FactoryBL.GetBL();
            InitializeComponent();
        }
        private void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (textBoxTestNum.Text.Length < 8)
                {
                    textBoxTestNum.BorderBrush = Brushes.Red;
                    throw new Exception("Test Number Is Too Short");
                }
                if (textBoxTestNum.Text.Length > 8)
                {
                    textBoxTestNum.BorderBrush = Brushes.Red;
                    throw new Exception("Test Number - To much digits");
                }
                int x = int.Parse(textBoxTestNum.Text);
                Test mytest = bl.SearchTest(x);
                if (mytest == null)
                    throw new Exception("The Test Does Not Exist");
                if (mytest.DateTimeOfTest > DateTime.Now)
                    throw new Exception("You Have Not Yet Taken The Test");
                if (mytest.TestResult == PassOrFail.Nun)
                    throw new Exception("The Test Result Has Not Been Updated Yet, Please Try Again Later");
                ResultPage t = new ResultPage(mytest);
                this.NavigationService.Navigate(t);

            }
            catch (Exception message)
            {
                MessageBox.Show(message.Message);
                textBoxTestNum.Text = "";
            }
        }
    }
}
