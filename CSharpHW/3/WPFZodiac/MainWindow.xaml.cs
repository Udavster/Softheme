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

namespace WPFZodiac {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
        public static int GetAge(DateTime dateOfBirth) {
            int age = DateTime.Now.Year - dateOfBirth.Year;
            bool birthdayRiched = (DateTime.Now.Month > dateOfBirth.Month) ||
                ((DateTime.Now.Month == dateOfBirth.Month) && (DateTime.Now.Day >= dateOfBirth.Day));
            if (!birthdayRiched) age--;
            return age;
        }
        public static string GetZodiac(DateTime dateOfBirth, out int zodiacNum) {
            DateTime[] ZodiacEndDates = new DateTime[]{
                new DateTime(dateOfBirth.Year, 1, 19),
                new DateTime(dateOfBirth.Year, 2, 18),
                new DateTime(dateOfBirth.Year, 3, 20),
                new DateTime(dateOfBirth.Year, 4, 19),
                new DateTime(dateOfBirth.Year, 5, 20),
                new DateTime(dateOfBirth.Year, 6, 20),
                new DateTime(dateOfBirth.Year, 7, 22),
                new DateTime(dateOfBirth.Year, 8, 22),
                new DateTime(dateOfBirth.Year, 9, 22),
                new DateTime(dateOfBirth.Year, 10, 22),
                new DateTime(dateOfBirth.Year, 11, 21),
                new DateTime(dateOfBirth.Year, 12, 21)
            };
            string[] ZodiacNames = new string[]{
                "Capricorn", "Aquarius", "Pisces",
                "Aries", "Taurus", "Gemini",
                "Cancer", "Leo", "Virgo",
                "Libra", "Scorpio", "Sagittarius"
            };
            for (int i = 0; i < ZodiacEndDates.Length; i++) {
                if (dateOfBirth <= ZodiacEndDates[i]) {
                    zodiacNum = i + 1;
                    return ZodiacNames[i];
                }
            }
            zodiacNum = 1;
            return ZodiacNames[0];
        }

        private void getInfoButton_Click(object sender, RoutedEventArgs e) {
            try {
                System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CurrentCulture;
                DateTime date = DateTime.ParseExact(dateOfBirthTextBox.Text, "dd/MM/yyyy", culture);
                int zodiacNum;
                string zodiacName = GetZodiac(date, out zodiacNum);
                responseLabel.Content =
                    String.Format("Your age: {0}\nYour Zodiac sign: {1}", GetAge(date), zodiacName);
                string imagePath = "Images/" + zodiacNum + ".png";
                zodiacSignImage.Source = new BitmapImage(new Uri(imagePath, UriKind.Relative));
            } catch (FormatException) {
                responseLabel.Content = "Format exception";
            } catch (Exception) {
                responseLabel.Content = "Unhandled exception";
            }
        }

    }
}
