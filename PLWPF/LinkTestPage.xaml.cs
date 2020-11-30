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
using BE;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for LinkTestPage.xaml
    /// </summary>
    public partial class LinkTestPage : Page
    {
        IBL bl;
        public LinkTestPage()
        {
            bl = FactoryBL.GetBL();
            InitializeComponent();
        }

        private void Allbutton_Click(object sender, RoutedEventArgs e)
        {
            myListTesterId.Visibility = Visibility.Hidden;
            myListTestResult.Visibility = Visibility.Hidden;
            myListMounth.Visibility = Visibility.Hidden;
            myListAll.Visibility = Visibility.Visible;

            DateTesTesterId.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            DateTesTestResult.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            DateTest.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            Allbutton.Background = new SolidColorBrush(Color.FromArgb(255, 25, 64, 166));
            if (myListAll.Items.IsEmpty)
            {
                IEnumerable<Test> myTesters = bl.GetAllTest();
                myListAll.ItemsSource = myTesters;
            }
        }

        private void DateTest_Click(object sender, RoutedEventArgs e)
        {
            myListTesterId.Visibility = Visibility.Hidden;
            myListTestResult.Visibility = Visibility.Hidden;
            myListMounth.Visibility = Visibility.Visible;
            myListAll.Visibility = Visibility.Hidden;
            DateTesTesterId.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            DateTesTestResult.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            DateTest.Background = new SolidColorBrush(Color.FromArgb(255, 25, 64, 166));
            Allbutton.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 166));
            if (myListMounth.Items.IsEmpty)
            {
                var mounth = bl.GetAllTestInMounth();

                foreach (IGrouping<int, Test> item in mounth)
                {
                    foreach (Test item2 in item)
                    {
                        myListMounth.Items.Add(item2);
                    }
                    myListMounth.Items.Add(new object());
                }
            }
            
        }

        private void DateTesTestResult_Click(object sender, RoutedEventArgs e)
        {
            myListTesterId.Visibility = Visibility.Hidden;
            myListTestResult.Visibility = Visibility.Visible;
            myListMounth.Visibility = Visibility.Hidden;
            myListAll.Visibility = Visibility.Hidden;
            DateTesTesterId.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            DateTesTestResult.Background = new SolidColorBrush(Color.FromArgb(255, 25, 64, 166));
            DateTest.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            Allbutton.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            if (myListTestResult.Items.IsEmpty)
            {
                var result = bl.GetAllTestResult();

                foreach (IGrouping<PassOrFail, Test> item in result)
                {
                    foreach (Test item2 in item)
                    {
                        myListTestResult.Items.Add(item2);
                    }
                    myListTestResult.Items.Add(new object());
                }
            }
        }

        private void DateTesTesterId_Click(object sender, RoutedEventArgs e)
        {
            myListTesterId.Visibility = Visibility.Visible;
            myListTestResult.Visibility = Visibility.Hidden;
            myListMounth.Visibility = Visibility.Hidden;
            myListAll.Visibility = Visibility.Hidden;
            DateTesTesterId.Background = new SolidColorBrush(Color.FromArgb(255, 25, 64, 166));
            DateTesTestResult.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            DateTest.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            Allbutton.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            if (myListTesterId.Items.IsEmpty)
            {
                var tester = bl.GetAllTestOfTester();

                foreach (IGrouping<string, Test> item in tester)
                {
                    foreach (Test item2 in item)
                    {
                        myListTesterId.Items.Add(item2);
                    }
                    myListTesterId.Items.Add(new object());
                }
            }
        }
    }
}
