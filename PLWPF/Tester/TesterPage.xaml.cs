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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for TesterPage.xaml
    /// </summary>
    public partial class TesterPage : Page
    {
        public TesterPage()
        {
            InitializeComponent();
        }

        private void deletTesterButton_Click(object sender, RoutedEventArgs e)
        {
            //Window deleteTester = new DeleteTester();
            //deleteTester.Show();
            DeleteTesterPage t = new DeleteTesterPage();
            this.NavigationService.Navigate(t);

        }

        private void addTesterButton_Click(object sender, RoutedEventArgs e)
        {
            //Window Addtester = new AddTester();
            //Addtester.Show();
            AddTesterPage t = new AddTesterPage();
            this.NavigationService.Navigate(t);
        }

        private void updateTesterButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateTesterPage t = new UpdateTesterPage();
            this.NavigationService.Navigate(t);
        }
    }
}

