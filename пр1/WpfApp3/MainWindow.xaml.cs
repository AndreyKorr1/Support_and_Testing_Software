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

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Func<double, double> selectedFunction;

        public MainWindow()
        {
            InitializeComponent();
            selectedFunction = Math.Sinh; // По умолчанию выбираем гиперболический синус
        }

        private void FunctionChanged(object sender, RoutedEventArgs e)
        {
            if (SinHButton.IsChecked == true)
                selectedFunction = Math.Sinh;
            else if (SquareButton.IsChecked == true)
                selectedFunction = x => x * x;
            else if (ExpButton.IsChecked == true)
                selectedFunction = Math.Exp;
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(InputX.Text, out double x) && double.TryParse(InputY.Text, out double y))
            {
                double fx = selectedFunction(x);
                double result;

                if (x > y)
                {
                    result = Math.Pow(fx - y, 3) + Math.Atan(fx);
                }
                else if (y > x)
                {
                    result = Math.Pow(y - fx, 3) + Math.Atan(fx);
                }
                else // y == x
                {
                    result = Math.Pow(y + fx, 3) + 0.5;
                }

                ResultTextBox.Text = result.ToString();
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректные числа для x и y.");
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            InputX.Clear();
            InputY.Clear();
            ResultTextBox.Clear();
            SinHButton.IsChecked = true; // Сброс к гиперболическому синусу
        }
    }
}