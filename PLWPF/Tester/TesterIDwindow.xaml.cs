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
using System.Windows.Shapes;
using BE;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for TesterIDwindow.xaml
    /// </summary>
    public partial class TesterIDwindow : Window
    {
        IBL bl;

        public object NavigationService { get; private set; }

        public TesterIDwindow()
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
                    throw new Exception("id - Not enough digits");
                IEnumerable<Tester> findTester = bl.GetAllTesters(m => m.TesterId == textBoxTesterId.Text);
                if (findTester.Count() == 0)
                    throw new Exception("Tester Is Not Exsist");
                this.Close();
            }
            catch (Exception message)
            {
                MessageBox.Show(message.Message);
                textBoxTesterId.Text = " ";
            }
        }
    }
}
