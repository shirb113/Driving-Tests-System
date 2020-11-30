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
    /// Interaction logic for ResultPage.xaml
    /// </summary>
    public partial class ResultPage : Page
    {
        IBL bl;
        public ResultPage(Test temp)
        {
            bl = FactoryBL.GetBL();

            InitializeComponent();
            Trainee t = bl.SearchTrainee(temp.TraineeId, temp.TestTypeOfCar);
            label3.Content = t.TraineeId;
            label4.Content =t.TraineeFirstName +" "+ t.TraineeLastName;
            textBox.Text = temp.TesterNote;
            if(temp.TestResult == PassOrFail.Fail)
            {
                Resultlabel5.Foreground = Brushes.Red;
                Resultlabel5.Content = "FAILED";
            }
            if (temp.TestResult == PassOrFail.Pass)
            {
                Resultlabel5.Foreground = Brushes.Green;
                Resultlabel5.Content = "PASSED";
            }

        }
    }
}
