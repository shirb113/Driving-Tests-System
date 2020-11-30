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
    /// Interaction logic for TesterIdPage.xaml
    /// </summary>
    public partial class TesterIdPage : Page
    {
        IBL bl;
        public TesterIdPage()
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
                if (textBoxTesterId.Text.Length < 9)
                {
                    textBoxTesterId.BorderBrush = Brushes.Red;
                    throw new Exception("id - Not enough digits");
                }
                if (textBoxTesterId.Text.Length > 9)
                {
                    textBoxTesterId.BorderBrush = Brushes.Red;
                    throw new Exception("Id - To much digits");
                }
                IEnumerable<Tester> findTester = bl.GetAllTesters(m => m.TesterId == textBoxTesterId.Text);
                if (findTester.Count() == 0)
                    throw new Exception("Tester Is Not Exsist");
                UpdateTestPage t = new UpdateTestPage(textBoxTesterId.Text);
                this.NavigationService.Navigate(t);
            }
            catch (Exception message)
            {
                MessageBox.Show(message.Message);
                textBoxTesterId.Text = "";
            }
        }
    }
}
