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
    /// Interaction logic for DeleteTest.xaml
    /// </summary>
    public partial class DeleteTest : Window
    {
        IBL bl;
        Test temp_test;
        public DeleteTest()
        {
            bl = FactoryBL.GetBL();
            InitializeComponent();
            temp_test = new Test();
        }

       
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { 
            if ((comboBox.SelectedItem as ComboBoxItem).Content.ToString() == "Delete By ID And Test Date")
            {
                grid3.Visibility = 0;
                grid1.Visibility = (Visibility)1;
                deleteButton.IsEnabled = true;
            }
            if ((comboBox.SelectedItem as ComboBoxItem).Content.ToString() == "Delete By Test Number")
            {
                grid1.Visibility = 0;
                grid3.Visibility = (Visibility)1;
                deleteButton.IsEnabled = true;
            }
        }

        private void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (grid3.Visibility == (Visibility)0)
            {
                try
                {
                    if (textBox1.Text.Length < 9)
                    {
                        textBox1.BorderBrush = Brushes.Red;
                        throw new Exception("id - Not enough digits");
                    }
                    if (textBox2.Text.Length < 9)
                    {
                        textBox2.BorderBrush = Brushes.Red;
                        throw new Exception("id - Not enough digits");
                    }
                    IEnumerable<Test> searchTest = bl.GetAllTest(t => (t.TesterId == textBox1.Text) && (t.TraineeId == textBox2.Text) && (t.DateTimeOfTest.Date == dateTest.SelectedDate));
                    if (searchTest.Count() == 0)
                        throw new Exception("The test wasn't found");
                    if (searchTest.Count() == 1)
                    {
                        temp_test = searchTest.First();
                        bl.DeletTest(temp_test);
                        throw new Exception("Test: \n" + temp_test.ToString() + "\nhave been deleted");
                    }
                    if (searchTest.Count() > 1)
                        throw new Exception("ERROR");

                    
                }
                catch (Exception message)
                {
                    MessageBox.Show(message.Message);
                    textBox1.BorderBrush = Brushes.Black;
                    textBox2.BorderBrush = Brushes.Black;
                }
            }
            if(grid1.Visibility == (Visibility)0)
            {
                try
                {
                    if (textBox.Text.Length < 8)
                    {
                        textBox.BorderBrush = Brushes.Red;
                        throw new Exception("Test number is too short");
                    }
                    temp_test = bl.SearchTest(Convert.ToInt32(textBox.Text));
                    if (temp_test == null)
                    {
                        throw new Exception("The test wasn't found");
                    }
                    label5.Content = temp_test.ToString();
                    bl.DeletTest(temp_test);
                    throw new Exception("Test has been deleted");
                }
                catch(Exception message)
                {
                    MessageBox.Show(message.Message);
                    textBox.BorderBrush = Brushes.Black;
                }
            }
        }
    }
}
