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
    /// Interaction logic for LinkPage.xaml
    /// </summary>
    public partial class LinkPage : Page
    {
        public LinkPage()
        {
            InitializeComponent();
        }

        private void TraineeButton_Click(object sender, RoutedEventArgs e)
        {
            LinkTraineePage t = new LinkTraineePage();
            this.NavigationService.Navigate(t);
        }

        private void TesterButton_Click(object sender, RoutedEventArgs e)
        {
            LinkTesterPage t = new LinkTesterPage();
            this.NavigationService.Navigate(t);
        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            LinkTestPage t = new LinkTestPage();
            this.NavigationService.Navigate(t);
        }
    }
}
