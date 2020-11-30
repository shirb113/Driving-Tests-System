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
    /// Interaction logic for TestPage.xaml
    /// </summary>
    public partial class TestPage : Page
    {
        public TestPage()
        {
            InitializeComponent();
           // Application.Current.MainWindow.WindowState = WindowState.Maximized;
        }
        private void addTestButton_Click(object sender, RoutedEventArgs e)
        {
            //Window t = new AddTest();
            //t.Show();
            AddTestPage t = new AddTestPage();
            this.NavigationService.Navigate(t);
        }

        private void deleteTestButton_Click(object sender, RoutedEventArgs e)
        {
            //Window deleteTest = new DeleteTest();
            //deleteTest.Show();

            DeleteTestPage t = new DeleteTestPage();
            this.NavigationService.Navigate(t);
        }

        private void updateTestButton_Click(object sender, RoutedEventArgs e)
        {
            TesterIdPage t = new TesterIdPage();
            this.NavigationService.Navigate(t);
        }

        private void showButton_Click(object sender, RoutedEventArgs e)
        {
            TestResultPage result = new TestResultPage();
            this.NavigationService.Navigate(result);

        }
    }
}
