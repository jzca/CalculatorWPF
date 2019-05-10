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
using System.Windows.Shapes;

namespace wpfCalculator
{
    /// <summary>
    /// Interaction logic for ConversionWindow.xaml
    /// </summary>
    public partial class ConversionWindow : Window
    {
        public ConversionWindow()
        {
            InitializeComponent();
        }

        public void HideTextBoxes()
        {
            output_1b.Visibility = Visibility.Hidden;
            output_2b.Visibility = Visibility.Hidden;
            output_3b.Visibility = Visibility.Hidden;
            output_4b.Visibility = Visibility.Hidden;
            output_5b.Visibility = Visibility.Hidden;
            output_6b.Visibility = Visibility.Hidden;
        }

        public void FeedTxt1(string msg)
        {
            output_1b.Text = msg;
        }
        public void FeedTxt2(string msg)
        {
            output_2b.Text = msg;
        }
        public void FeedTxt3(string msg)
        {
            output_3b.Text = msg;
        }
        public void FeedTxt4(string msg)
        {
            output_4b.Text = msg;
        }
        public void FeedTxt5(string msg)
        {
            output_5b.Text = msg;
        }
        public void FeedTxt6(string msg)
        {
            output_6b.Text = msg;
        }


        public void HideTxt1()
        {
            output_1b.Visibility = Visibility.Hidden;
        }
        public void HideTxt2()
        {
            output_2b.Visibility = Visibility.Hidden;
        }
        public void HideTxt3()
        {
            output_3b.Visibility = Visibility.Hidden;
        }
        public void HideTxt4()
        {
            output_4b.Visibility = Visibility.Hidden;
        }
        public void HideTxt5()
        {
            output_5b.Visibility = Visibility.Hidden;
        }
        public void HideTxt6()
        {
            output_6b.Visibility = Visibility.Hidden;
        }

        public void ShowTxt1()
        {
            output_1b.Visibility = Visibility.Visible;
        }
        public void ShowTxt2()
        {
            output_2b.Visibility = Visibility.Visible;
        }
        public void ShowTxt3()
        {
            output_3b.Visibility = Visibility.Visible;
        }
        public void ShowTxt4()
        {
            output_4b.Visibility = Visibility.Visible;
        }
        public void ShowTxt5()
        {
            output_5b.Visibility = Visibility.Visible;
        }
        public void ShowTxt6()
        {
            output_6b.Visibility = Visibility.Visible;
        }

    }
}
