using org.mariuszgromada.math.mxparser;
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
using Expression = org.mariuszgromada.math.mxparser.Expression;

namespace wpfCalculator
{
    public partial class MainWindow : Window
    {

        private StringBuilder InputString { get; set; }
        private string MathExp { get { return InputString.ToString(); } }

        public MainWindow()
        {
            InitializeComponent();
            InputString = new StringBuilder();
            HideComboBoxes();
            Hide6TextBoxes();
        }

        private void HideComboBoxes()
        {
            Units_info.Visibility = Visibility.Hidden;
            Units_length.Visibility = Visibility.Hidden;
            Units_mass.Visibility = Visibility.Hidden;
            Units_number.Visibility = Visibility.Hidden;
            Units_time.Visibility = Visibility.Hidden;
        }

        private void Hide6TextBoxes()
        {
            output_1.Visibility = Visibility.Hidden;
            output_2.Visibility = Visibility.Hidden;
            output_3.Visibility = Visibility.Hidden;
            output_4.Visibility = Visibility.Hidden;
            output_5.Visibility = Visibility.Hidden;
            output_6.Visibility = Visibility.Hidden;
        }

        private bool InsultUsers()
        {
            var yesHappened = false;

            if (MathExp.Length >= 1)
            {
                var occured = MathExp[0].ToString();
                if (occured == "#" || occured == "/"
                    || occured == "*" || occured == "^"
                    || occured =="!")
                {
                    yesHappened = true;
                }
            }

            return yesHappened;
        }


        private void BuildString(object sender, RoutedEventArgs e)
        {
            var inputKey = (sender as Button).Content.ToString();
            switch (inputKey)
            {
                case "Modulo":
                    inputKey = "#";
                    break;
            }

            InputString.Append(inputKey);
            DisplayResult(MathExp);
        }

        private void DisplayResult(string result)
        {
            output_screen.Text = result;
        }
        private void Result_click(object sender, RoutedEventArgs e)
        {
            if (InsultUsers() == false)
            {
                Expression regularMath
                     = new Expression(MathExp);
                var ans = regularMath.calculate().ToString();
                DisplayResult(ans);
                ClearAll();
                InputString.Append(ans);
            }
            else
            {
                var warningMsg = "Do you know how to use a calculator?";
                DisplayResult(warningMsg);
            }

        }

        private void Sqrt_Click(object sender, RoutedEventArgs e)
        {
            if (MathExp.Any())
            {
                Expression sqrtMath
                    = new Expression($"sqrt({MathExp})");
                var ans = sqrtMath.calculate().ToString();
                DisplayResult(ans);
                ClearAll();
            }
            else
            {
                DisplayResult("Need a number at first!");
            }


        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearAll();
            DisplayResult(MathExp);
        }

        private void Backspace_Click(object sender, RoutedEventArgs e)
        {
            if (InputString.Length == 1)
            {
                InputString.Remove(0, 1);
            }
            else if (InputString.Length > 0)
            {
                InputString.Remove(InputString.Length - 1, 1);
            }

            DisplayResult(MathExp);
        }

        private void ClearAll()
        {
            InputString.Clear();
        }

        private void CtoF_click(object sender, RoutedEventArgs e)
        {
            if (MathExp.Any())
            {

                Expression cToF
                    = new Expression($"({MathExp} * 9/5) + 32");
                var ans = cToF.calculate().ToString();
                DisplayResult(ans);
            }
        }

        private void FtoC_click(object sender, RoutedEventArgs e)
        {
            if (MathExp.Any())
            {
                Expression fTOc
                    = new Expression($"({MathExp} - 32) * 5/9");
                var ans = fTOc.calculate().ToString();
                DisplayResult(ans);
            }
        }

        private void Conversion_click(object sender, RoutedEventArgs e)
        {
            if (Conversion_ask.SelectedValue.ToString() == "uo_length")
            {
                var inputUnit = Units_length.SelectedValue;
                Expression mm = new Expression($"({MathExp}*[{inputUnit}])/[mm]");
                output_1.Text = $"Millimetre: {mm.calculate()}";
                output_1.Visibility = Visibility.Visible;
                Expression cm = new Expression($"({MathExp}*[{inputUnit}])/[cm]");
                output_2.Text = $"Centimeter: {cm.calculate()}";
                output_2.Visibility = Visibility.Visible;
                Expression m = new Expression($"({MathExp}*[{inputUnit}])/[m]");
                output_3.Text = $"Meter: {m.calculate()}";
                output_3.Visibility = Visibility.Visible;
                Expression km = new Expression($"({MathExp}*[{inputUnit}])/[km]");
                output_4.Text = $"Kilometer: {km.calculate()}";
                output_4.Visibility = Visibility.Visible;
                Expression inch = new Expression($"({MathExp}*[{inputUnit}])/[inch]");
                output_5.Text = $"Inch: {inch.calculate()}";
                output_5.Visibility = Visibility.Visible;
                Expression ft = new Expression($"({MathExp}*[{inputUnit}])/[ft]");
                output_6.Text = $"Foot: {ft.calculate()}";
                output_6.Visibility = Visibility.Visible;
            }
            else if (Conversion_ask.SelectedValue.ToString() == "uo_mass")
            {
                var inputUnit = Units_mass.SelectedValue;
                Expression mg = new Expression($"({MathExp}*[{inputUnit}])/[mg]");
                output_1.Text = $"Milligram: {mg.calculate()}";
                output_1.Visibility = Visibility.Visible;
                Expression gr = new Expression($"({MathExp}*[{inputUnit}])/[gr]");
                output_2.Text = $"Gram: {gr.calculate()}";
                output_2.Visibility = Visibility.Visible;
                Expression kg = new Expression($"({MathExp}*[{inputUnit}])/[kg]");
                output_3.Text = $"Kilogram: {kg.calculate()}";
                output_3.Visibility = Visibility.Visible;
                Expression oz = new Expression($"({MathExp}*[{inputUnit}])/[oz]");
                output_4.Text = $"Ounce: {oz.calculate()}";
                output_4.Visibility = Visibility.Visible;
                Expression lb = new Expression($"({MathExp}*[{inputUnit}])/[lb]");
                output_5.Text = $"Pound: {lb.calculate()}";
                output_5.Visibility = Visibility.Visible;
            }
            else if (Conversion_ask.SelectedValue.ToString() == "uo_info")
            {
                var inputUnit = Units_info.SelectedValue;
                Expression b = new Expression($"({MathExp}*[{inputUnit}])/[B]");
                output_1.Text = $"Byte: {b.calculate()}";
                output_1.Visibility = Visibility.Visible;
                Expression kb = new Expression($"({MathExp}*[{inputUnit}])/[kB]");
                output_2.Text = $"Kilobyte: {kb.calculate()}";
                output_2.Visibility = Visibility.Visible;
                Expression mb = new Expression($"({MathExp}*[{inputUnit}])/[MB]");
                output_3.Text = $"Megabyte: {mb.calculate()}";
                output_3.Visibility = Visibility.Visible;
                Expression gb = new Expression($"({MathExp}*[{inputUnit}])/[GB]");
                output_4.Text = $"Gigabyte: {gb.calculate()}";
                output_4.Visibility = Visibility.Visible;
                Expression tb = new Expression($"({MathExp}*[{inputUnit}])/[TB]");
                output_5.Text = $"Terabyte: {tb.calculate()}";
                output_5.Visibility = Visibility.Visible;
            }
            else if (Conversion_ask.SelectedValue.ToString() == "uo_time")
            {
                var inputUnit = Units_time.SelectedValue;
                Expression sec = new Expression($"({MathExp}*[{inputUnit}])/[s]");
                output_1.Text = $"Second: {sec.calculate()}";
                output_1.Visibility = Visibility.Visible;
                Expression min = new Expression($"({MathExp}*[{inputUnit}])/[min]");
                output_2.Text = $"Minute: {min.calculate()}";
                output_2.Visibility = Visibility.Visible;
                Expression mb = new Expression($"({MathExp}*[{inputUnit}])/[h]");
                output_3.Text = $"Hour: {mb.calculate()}";
                output_3.Visibility = Visibility.Visible;
            }
            else if (Conversion_ask.SelectedValue.ToString() == "uo_number")
            {
                bool success = int.TryParse(MathExp, out int my_regular);
                if (success)
                {
                    output_1.Text = $"Integer: {my_regular}";
                    output_1.Visibility = Visibility.Visible;

                    var my_bin = ToBinary(my_regular);
                    output_2.Text = $"Binary: {my_bin}";
                    output_2.Visibility = Visibility.Visible;
                    var my_oct = Convert.ToString(my_regular, 8);
                    output_3.Text = $"Octal: {my_oct}";
                    output_3.Visibility = Visibility.Visible;
                    var my_hex = Convert.ToString(my_regular, 16);
                    output_4.Text = $"Hexadecimal: {my_hex}";
                    output_4.Visibility = Visibility.Visible;
                    ClearAll();
                }
                else
                {
                    output_1.Text = $"Not a integer or other errors";
                    output_1.Visibility = Visibility.Visible;
                }

            }





        }

        private static string ToBinary(int myValue)
        {
            string binVal = Convert.ToString(myValue, 2);
            int bits = 0;
            int bitblock = 4;

            for (int i = 0; i < binVal.Length; i = i + bitblock)
            { bits += bitblock; }

            return binVal.PadLeft(bits, '0');
        }


        private void Conversion_ask_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ConversionWindow winCnversion = new ConversionWindow();

            if (Conversion_ask.SelectedValue != null)
            {
                switch (Conversion_ask.SelectedValue.ToString())
                {
                    case "uo_info":
                        Units_info.Visibility = Visibility.Visible;
                        Units_length.Visibility = Visibility.Hidden;
                        Units_mass.Visibility = Visibility.Hidden;
                        Units_number.Visibility = Visibility.Hidden;
                        Units_time.Visibility = Visibility.Hidden;
                        winCnversion.Show();
                        break;
                    case "uo_length":
                        Units_length.Visibility = Visibility.Visible;
                        Units_info.Visibility = Visibility.Hidden;
                        Units_mass.Visibility = Visibility.Hidden;
                        Units_number.Visibility = Visibility.Hidden;
                        Units_time.Visibility = Visibility.Hidden;
                        winCnversion.Show();
                        break;
                    case "uo_mass":
                        Units_mass.Visibility = Visibility.Visible;
                        Units_info.Visibility = Visibility.Hidden;
                        Units_length.Visibility = Visibility.Hidden;
                        Units_number.Visibility = Visibility.Hidden;
                        Units_time.Visibility = Visibility.Hidden;
                        winCnversion.Show();
                        break;
                    case "uo_number":
                        Units_info.Visibility = Visibility.Hidden;
                        Units_length.Visibility = Visibility.Hidden;
                        Units_mass.Visibility = Visibility.Hidden;
                        Units_time.Visibility = Visibility.Hidden;
                        winCnversion.Show();
                        break;
                    case "uo_time":
                        Units_time.Visibility = Visibility.Visible;
                        Units_info.Visibility = Visibility.Hidden;
                        Units_length.Visibility = Visibility.Hidden;
                        Units_mass.Visibility = Visibility.Hidden;
                        Units_number.Visibility = Visibility.Hidden;
                        winCnversion.Show();
                        break;
                    case "which":
                        HideComboBoxes();
                        Hide6TextBoxes();
                        break;
                }
            }








        }
    }
}

//if (true)
//{
//    switch ()
//    {
//        case "int":

//            break;
//        case "uo_length":

//            break;
//        case "uo_mass":

//            break;
//        case "uo_number":

//            break;
//        case "uo_time":

//            break;

//    }
