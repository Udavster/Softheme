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

namespace GuessWhat {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private int num;
        private Random randomGenerator;
        public MainWindow() {
            InitializeComponent();
            Generate();
        }
        public void Generate() {
            this.randomGenerator = this.randomGenerator ?? new Random();
            this.num = this.randomGenerator.Next(1, 11);
        }

        private void readyButton_Click(object sender, RoutedEventArgs e) {
            int guessedNum;
            try {
                guessedNum = Int32.Parse(numTextBox.Text);
                if ((guessedNum < 1) || (guessedNum > 10)) {
                    throw new FormatException();
                }
            }catch(Exception){
                MessageBox.Show("Please fix your input");
                return;
            }
            if (this.num == guessedNum) {
                MessageBox.Show("Congratulations!");
            } else {
                MessageBox.Show("Sorry, it was " + this.num);
            }
            Generate();
        }
   }
}
