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

namespace практическая3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(InitialDepositTextBox.Text) ||
                string.IsNullOrEmpty(InvestmentTermTextBox.Text) ||
                string.IsNullOrEmpty(InterestRateTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (SimpleInterestRadioButton.IsChecked == false && CompoundInterestRadioButton.IsChecked == false)
            {
                MessageBox.Show("Пожалуйста, выберите схему начисления процентов.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                double initialDeposit = double.Parse(InitialDepositTextBox.Text);
                int investmentTermMonths = int.Parse(InvestmentTermTextBox.Text);
                double annualInterestRate = double.Parse(InterestRateTextBox.Text) / 100.0;

                double result = 0;
                if (SimpleInterestRadioButton.IsChecked == true)
                {
                    result = CalculateSimpleInterest(initialDeposit, annualInterestRate, investmentTermMonths);
                }
                else if (CompoundInterestRadioButton.IsChecked == true)
                {
                    result = CalculateCompoundInterest(initialDeposit, annualInterestRate, investmentTermMonths);
                }

                ResultTextBlock.Text = result.ToString("C");
            }
            catch (FormatException)
            {
                MessageBox.Show("Неверный формат данных. Пожалуйста, введите числовые значения.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private double CalculateSimpleInterest(double initialDeposit, double annualInterestRate, int investmentTermMonths)
        {
            double monthlyInterestRate = annualInterestRate / 12.0;
            return initialDeposit + (initialDeposit * monthlyInterestRate * investmentTermMonths);
        }

        private double CalculateCompoundInterest(double initialDeposit, double annualInterestRate, int investmentTermMonths)
        {
            double monthlyInterestRate = annualInterestRate / 12.0;
            double total = initialDeposit;

            for (int i = 0; i < investmentTermMonths; i++)
            {
                total += total * monthlyInterestRate;
            }

            return total;
        }
    }
}
