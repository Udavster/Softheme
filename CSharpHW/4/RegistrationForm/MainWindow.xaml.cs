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

namespace RegistrationForm {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

        }

        private void sendButton_Click(object sender, RoutedEventArgs e) {
            bool correctInput;
            
            string firstName, lastName;
            correctInput = TryGetNameFromTextField(firstNameTextBox, out firstName);
            correctInput = correctInput & TryGetNameFromTextField(lastNameTextBox, out lastName);
            
            int day, month, year;
            correctInput = correctInput & TryGetNumFromTextField(dayTextBox, out day, 1, 31);
            correctInput = correctInput & TryGetNumFromTextField(monthTextBox, out month, 1, 12);
            correctInput = correctInput & TryGetNumFromTextField(yearTextBox, out year, 1901, DateTime.Now.Year - 1);
            
            string gender = genderTextBox.Text;
            if ((gender!="Male")&&(gender!="Female")) {
                genderTextBox.BorderBrush = Brushes.OrangeRed;
                correctInput = false;
            } else {
                genderTextBox.ClearValue(TextBox.BorderBrushProperty);
            }
            
            string email = emailTextBox.Text;
            if (!email.Contains('@')) {
                emailTextBox.BorderBrush = Brushes.OrangeRed;
                correctInput = false;
            } else {
                emailTextBox.ClearValue(TextBox.BorderBrushProperty);
            }
            ulong phoneNum;
            correctInput = correctInput & TryGetPhoneNumFromTextField(phoneTextBox, out phoneNum);
            string additionalInfo;
            correctInput = correctInput & TryGetLimitedStringFromTextField(addInfoTextBox, out additionalInfo, 1999);
            if (!correctInput) {
                MessageBox.Show("Sorry, provided info was incorrect. Try fixing it=)");
            } else {
                MessageBox.Show("Thank you!");
            }
        }
        private bool TryGetNameFromTextField(TextBox textBox, out string value) {
            value = textBox.Text;
            if ((!value.All(char.IsLetter)) || (value.Length >= 255)) {
                textBox.BorderBrush = Brushes.OrangeRed;
                return false;
            } 
            textBox.ClearValue(TextBox.BorderBrushProperty);
            return true;
        }
        private bool TryGetNumFromTextField(TextBox textBox, out int value,
            int MinValue = int.MinValue, int MaxValue = int.MaxValue) {
            bool properInput = Int32.TryParse(textBox.Text, out value);
            properInput &= (value <= MaxValue) && (value >= MinValue);
            if (!properInput) {
                textBox.BorderBrush = Brushes.OrangeRed;
                return false;
            }
            textBox.ClearValue(TextBox.BorderBrushProperty);
            return true;
        }
        private bool TryGetPhoneNumFromTextField(TextBox textBox, out UInt64 value) {
            bool properInput = (textBox.Text.Length == 12);
            properInput &= UInt64.TryParse(textBox.Text, out value);
            if (!properInput) {
                textBox.BorderBrush = Brushes.OrangeRed;
                return false;
            }
            textBox.ClearValue(TextBox.BorderBrushProperty);
            return true;
        }
        private bool TryGetLimitedStringFromTextField(TextBox textBox, out string value, int MaxLength) {
            value = textBox.Text;
            bool properInput = (value.Length <= MaxLength);
            if (!properInput) {
                textBox.BorderBrush = Brushes.OrangeRed;
                return false;
            }
            textBox.ClearValue(TextBox.BorderBrushProperty);
            return true;
        }
        
    }
}
