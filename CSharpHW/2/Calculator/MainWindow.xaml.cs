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

namespace Calculator {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
        private double result;
        private void calculateButton_Click(object sender, RoutedEventArgs e) {
            if (operation.SelectedValue == null) {
                ResultsLabel.Content = "No operation selected";
                return;
            }
            double leftOperand, rightOperand, result;
            try {
                try {
                    leftOperand = double.Parse(leftArgument.Text);
                    rightOperand = double.Parse(rightArgument.Text);
                } catch (FormatException) {
                    ResultsLabel.Content = "Format exception";
                    return;
                }
                ResultsLabel.Content = leftOperand.ToString() + " " + rightOperand.ToString();
                //string operationSymbol = (operationComboBox.SelectedValue ?? String.Empty).ToString();

                string operationSymbol = operation.SelectedValue.ToString();
                switch (operationSymbol) {
                    case "+":
                        result = leftOperand + rightOperand;
                        break;
                    case "-":
                        result = leftOperand - rightOperand;
                        break;
                    case "*":
                        result = leftOperand * rightOperand;
                        break;
                    case "/":
                        result = leftOperand / rightOperand;
                        break;
                    case "^":
                        result = Math.Pow(leftOperand, rightOperand);
                        ResultsLabel.Content = "";
                        MessageBox.Show("Power is made by Math.Pow, so the same rules applied to it as described at MSDN for Math.Pow");
                        break;
                    default:
                        return;
                }
                this.result = result;
                ResultsLabel.Content = String.Format("{0:0.00}", result);
            } catch (OverflowException) {
                ResultsLabel.Content = "Overflow exception";
            } catch (Exception) {
                ResultsLabel.Content = "Exception";
                MessageBox.Show("Problem is unknown but handled. Try fixing input");
            }
            //MessageBox.Show(operationSymbol);
        }

        private void seeFullResult_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show(this.result.ToString());
        }
    }
}
