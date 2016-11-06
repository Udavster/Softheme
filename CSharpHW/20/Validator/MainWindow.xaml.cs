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

using System.ComponentModel.DataAnnotations;
using ValidationResult = System.ComponentModel.DataAnnotations.ValidationResult;

namespace RegistrationForm {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

        }

        private void sendButton_Click(object sender, RoutedEventArgs e) {
            int day, month, year;
            GetNumFromTextField(dayTextBox, out day);
            GetNumFromTextField(monthTextBox, out month);
            GetNumFromTextField(yearTextBox, out year);

            string gender = (genderTextBox.Text == "") ? null : genderTextBox.Text;
            string phone = (phoneTextBox.Text == "") ? null : phoneTextBox.Text;
            string additionalInfo = (addInfoTextBox.Text == "") ? null : addInfoTextBox.Text;

            var user = new User() { 
                FirstName = firstNameTextBox.Text,
                LastName = lastNameTextBox.Text,
                Gender = gender,
                BirthDay = day,
                BirthMonth = month,
                BirthYear = year,
                Email = emailTextBox.Text,
                PhoneNumber = phone, 
                AdditionalInfo = additionalInfo
            };

            var results = new List<ValidationResult>();
            var context = new ValidationContext(user);

            string errors = "";

            if (!Validator.TryValidateObject(user, context, results, true))
            {
                foreach (var error in results)
                {
                    errors+=error.ErrorMessage+"\n";
                }
                MessageBox.Show(errors);
            } else
            {
                MessageBox.Show("Success!");
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
        private bool GetNumFromTextField(TextBox textBox, out int value) {
            bool properInput = Int32.TryParse(textBox.Text, out value);
            return true;
        }
   }
}
