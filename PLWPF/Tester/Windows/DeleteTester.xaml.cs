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
    /// Interaction logic for DeleteTester.xaml
    /// </summary>
    public partial class DeleteTester : Window
    {
        IBL bl;
        Tester temp_tester;
        public DeleteTester()
        {
            bl = FactoryBL.GetBL();
            InitializeComponent();
            temp_tester = new Tester();
           
        }
       
        private void searchIcon_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (idtextBox.Text.Length < 9)
                {
                    idtextBox.BorderBrush = Brushes.Red;
                    label1.Content = "";
                    button.IsEnabled = false;

                    throw new Exception("Id - Not enough digits");
                }
                temp_tester = bl.SearchTester(idtextBox.Text);
                if (temp_tester == null)
                {
                    label1.Content = "";
                    button.IsEnabled = false;
                    throw new Exception("The tester does not exist in the database");
                }
                button.IsEnabled = true;
                label1.Content = temp_tester.ToString();
            }
            catch (Exception message)
            {
                MessageBox.Show(message.Message);
                idtextBox.Text = "";
                idtextBox.BorderBrush = Brushes.Black;
            }
        }

        private void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.DeleteTester(temp_tester);
                MessageBox.Show("Tester" +" "+temp_tester.TesterId+" "+"deleted");
              
                
            }
            catch(Exception message)
            {
                MessageBox.Show(message.Message);
                label1.Content = "";
                idtextBox.Text = "";
                idtextBox.BorderBrush = Brushes.Black;
            }
        }
    }
}
