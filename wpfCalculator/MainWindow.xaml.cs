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
        private ConversionWindow WinCnversion { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            InputString = new StringBuilder();
            WinCnversion = new ConversionWindow();
            HideComboBoxes();
        }

        private void ShowWin2()
        {
            WinCnversion.ClearTextBoxes();
            WinCnversion.HideTextBoxes();
            WinCnversion.Show();
        }

        private void HideComboBoxes()
        {
            Units_info.Visibility = Visibility.Hidden;
            Units_length.Visibility = Visibility.Hidden;
            Units_mass.Visibility = Visibility.Hidden;
            Units_time.Visibility = Visibility.Hidden;
        }

        private bool InsultUsers()
        {
            var yesHappened = false;

            if (MathExp.Length >= 1)
            {
                var occured = MathExp[0].ToString();
                if (occured == "#" || occured == "/"
                    || occured == "*" || occured == "^"
                    || occured == "!")
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
                    = new Expression($"sqrt(({MathExp}))");
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
                    = new Expression($"(({MathExp}) * 9/5) + 32");
                var ans = cToF.calculate().ToString();
                DisplayResult(ans);
                ClearAll();
            }
        }

        private void FtoC_click(object sender, RoutedEventArgs e)
        {
            if (MathExp.Any())
            {
                Expression fTOc
                    = new Expression($"(({MathExp}) - 32) * 5/9");
                var ans = fTOc.calculate().ToString();
                DisplayResult(ans);
                ClearAll();
            }
        }

        private void Conversion_click(object sender, RoutedEventArgs e)
        {
            if (MathExp.Any())
            {

                var detailSelectedStr = "question";

                if (Conversion_ask.SelectedValue.ToString() == "uo_length")
                {
                    var inputUnit = Units_length.SelectedValue;
                    if (inputUnit.ToString() != detailSelectedStr)
                    {
                        Expression mm = new Expression($"(({MathExp})*[{inputUnit}])/[mm]");
                        WinCnversion.FeedTxt1($"Millimetre: {mm.calculate()}");
                        WinCnversion.ShowTxt1();
                        Expression cm = new Expression($"(({MathExp})*[{inputUnit}])/[cm]");
                        WinCnversion.FeedTxt2($"Centimeter: {cm.calculate()}");
                        WinCnversion.ShowTxt2();
                        Expression m = new Expression($"(({MathExp})*[{inputUnit}])/[m]");
                        WinCnversion.FeedTxt3($"Meter: {m.calculate()}");
                        WinCnversion.ShowTxt3();
                        Expression km = new Expression($"(({MathExp})*[{inputUnit}]) / [km]");
                        WinCnversion.FeedTxt4($"Kilometer: {km.calculate()}");
                        WinCnversion.ShowTxt4();
                        Expression inch = new Expression($"(({MathExp})*[{inputUnit}])/[inch]");
                        WinCnversion.FeedTxt5($"Inch: {inch.calculate()}");
                        WinCnversion.ShowTxt5();
                        Expression ft = new Expression($"(({MathExp})*[{inputUnit}])/[ft]");
                        WinCnversion.FeedTxt6($"Foot: {ft.calculate()}");
                        WinCnversion.ShowTxt6();
                    }
                    else
                    {
                        DisplayResult("Select a unit");
                    }
                }
                else if (Conversion_ask.SelectedValue.ToString() == "uo_mass")
                {
                    var inputUnit = Units_mass.SelectedValue;

                    if (inputUnit.ToString() != detailSelectedStr)
                    {
                        Expression mg = new Expression($"(({MathExp})*[{inputUnit}])/[mg]");
                        WinCnversion.output_1b.Text = $"Milligram: {mg.calculate()}";
                        WinCnversion.output_1b.Visibility = Visibility.Visible;
                        Expression gr = new Expression($"(({MathExp})*[{inputUnit}])/[gr]");
                        WinCnversion.output_2b.Text = $"Gram: {gr.calculate()}";
                        WinCnversion.output_2b.Visibility = Visibility.Visible;
                        Expression kg = new Expression($"(({MathExp})*[{inputUnit}])/[kg]");
                        WinCnversion.output_3b.Text = $"Kilogram: {kg.calculate()}";
                        WinCnversion.output_3b.Visibility = Visibility.Visible;
                        Expression oz = new Expression($"(({MathExp})*[{inputUnit}])/[oz]");
                        WinCnversion.output_4b.Text = $"Ounce: {oz.calculate()}";
                        WinCnversion.output_4b.Visibility = Visibility.Visible;
                        Expression lb = new Expression($"(({MathExp})*[{inputUnit}])/[lb]");
                        WinCnversion.output_5b.Text = $"Pound: {lb.calculate()}";
                        WinCnversion.output_5b.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        DisplayResult("Select a unit");
                    }

                }
                else if (Conversion_ask.SelectedValue.ToString() == "uo_info")
                {
                    var inputUnit = Units_info.SelectedValue;

                    if (inputUnit.ToString() != detailSelectedStr)
                    {
                        Expression b = new Expression($"(({MathExp})*[{inputUnit}])/[B]");
                        WinCnversion.output_1b.Text = $"Byte: {b.calculate()}";
                        WinCnversion.output_1b.Visibility = Visibility.Visible;
                        Expression kb = new Expression($"(({MathExp})*[{inputUnit}])/[kB]");
                        WinCnversion.output_2b.Text = $"Kilobyte: {kb.calculate()}";
                        WinCnversion.output_2b.Visibility = Visibility.Visible;
                        Expression mb = new Expression($"(({MathExp})*[{inputUnit}])/[MB]");
                        WinCnversion.output_3b.Text = $"Megabyte: {mb.calculate()}";
                        WinCnversion.output_3b.Visibility = Visibility.Visible;
                        Expression gb = new Expression($"(({MathExp})*[{inputUnit}])/[GB]");
                        WinCnversion.output_4b.Text = $"Gigabyte: {gb.calculate()}";
                        WinCnversion.output_4b.Visibility = Visibility.Visible;
                        Expression tb = new Expression($"(({MathExp})*[{inputUnit}])/[TB]");
                        WinCnversion.output_5b.Text = $"Terabyte: {tb.calculate()}";
                        WinCnversion.output_5b.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        DisplayResult("Select a unit");
                    }

                }
                else if (Conversion_ask.SelectedValue.ToString() == "uo_time")
                {
                    var inputUnit = Units_time.SelectedValue;
                    if (inputUnit.ToString() != detailSelectedStr)
                    {
                        Expression sec = new Expression($"(({MathExp})*[{inputUnit}])/[s]");
                        WinCnversion.output_1b.Text = $"Second: {sec.calculate()}";
                        WinCnversion.output_1b.Visibility = Visibility.Visible;
                        Expression min = new Expression($"(({MathExp})*[{inputUnit}])/[min]");
                        WinCnversion.output_2b.Text = $"Minute: {min.calculate()}";
                        WinCnversion.output_2b.Visibility = Visibility.Visible;
                        Expression mb = new Expression($"(({MathExp})*[{inputUnit}])/[h]");
                        WinCnversion.output_3b.Text = $"Hour: {mb.calculate()}";
                        WinCnversion.output_3b.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        DisplayResult("Select a unit");
                    }

                }
                else if (Conversion_ask.SelectedValue.ToString() == "uo_percent")
                {
                    Expression toBig = new Expression($"({MathExp})*100");
                    WinCnversion.output_1b.Text = $"Percent (←Decimal) : {toBig.calculate()}%";
                    WinCnversion.output_1b.Visibility = Visibility.Visible;
                    Expression toSm = new Expression($"({MathExp})/100");
                    WinCnversion.output_2b.Text = $"Decimal (←Percent) : {toSm.calculate()}";
                    WinCnversion.output_2b.Visibility = Visibility.Visible;
                    ClearAll();

                }
                else if (Conversion_ask.SelectedValue.ToString() == "uo_number")
                {
                    bool success = int.TryParse(MathExp, out int my_regular);
                    if (success)
                    {
                        WinCnversion.output_1b.Text = $"Integer: {my_regular}";
                        WinCnversion.output_1b.Visibility = Visibility.Visible;

                        var my_bin = ToBinary(my_regular);
                        WinCnversion.output_2b.Text = $"Binary: {my_bin}";
                        WinCnversion.output_2b.Visibility = Visibility.Visible;
                        var my_oct = Convert.ToString(my_regular, 8);
                        WinCnversion.output_3b.Text = $"Octal: {my_oct}";
                        WinCnversion.output_3b.Visibility = Visibility.Visible;
                        var my_hex = Convert.ToString(my_regular, 16);
                        WinCnversion.output_4b.Text = $"Hexadecimal: {my_hex}";
                        WinCnversion.output_4b.Visibility = Visibility.Visible;
                        ClearAll();
                    }
                    else
                    {
                        WinCnversion.output_1b.Text = $"Not a integer or other errors";
                        WinCnversion.output_1b.Visibility = Visibility.Visible;
                    }
                }
            }
            else
            {
                var warningMsg = "An input number required";
                DisplayResult(warningMsg);
            }





        }

        private static string ToBinary(int myValue)
        {
            string binVal = Convert.ToString(myValue, 2);
            int bits = 0;
            int bitblock = 4;

            for (int i = 0; i < binVal.Length; i += bitblock)
            { bits += bitblock; }

            return binVal.PadLeft(bits, '0');
        }


        private void Conversion_ask_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Conversion_ask.SelectedValue != null)
            {
                switch (Conversion_ask.SelectedValue.ToString())
                {
                    case "uo_info":
                        Units_info.Visibility = Visibility.Visible;
                        Units_length.Visibility = Visibility.Hidden;
                        Units_mass.Visibility = Visibility.Hidden;
                        Units_time.Visibility = Visibility.Hidden;
                        ShowWin2();
                        break;
                    case "uo_length":
                        Units_length.Visibility = Visibility.Visible;
                        Units_info.Visibility = Visibility.Hidden;
                        Units_mass.Visibility = Visibility.Hidden;
                        Units_time.Visibility = Visibility.Hidden;
                        ShowWin2();
                        break;
                    case "uo_mass":
                        Units_mass.Visibility = Visibility.Visible;
                        Units_info.Visibility = Visibility.Hidden;
                        Units_length.Visibility = Visibility.Hidden;
                        Units_time.Visibility = Visibility.Hidden;
                        ShowWin2();
                        break;
                    case "uo_number":
                        Units_info.Visibility = Visibility.Hidden;
                        Units_length.Visibility = Visibility.Hidden;
                        Units_mass.Visibility = Visibility.Hidden;
                        Units_time.Visibility = Visibility.Hidden;
                        ShowWin2();
                        break;
                    case "uo_time":
                        Units_time.Visibility = Visibility.Visible;
                        Units_info.Visibility = Visibility.Hidden;
                        Units_length.Visibility = Visibility.Hidden;
                        Units_mass.Visibility = Visibility.Hidden;
                        ShowWin2();
                        break;
                    case "uo_percent":
                        Units_time.Visibility = Visibility.Hidden;
                        Units_info.Visibility = Visibility.Hidden;
                        Units_length.Visibility = Visibility.Hidden;
                        Units_mass.Visibility = Visibility.Hidden;
                        ShowWin2();
                        break;
                    case "which":
                        HideComboBoxes();
                        WinCnversion.Close();
                        break;
                }
            }








        }
    }
}
