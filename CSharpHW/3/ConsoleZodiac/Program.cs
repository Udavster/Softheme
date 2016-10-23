using System;

namespace ConsoleZodiac {
    class Program {
        static void Main(string[] args) {
            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CurrentCulture;           
            bool wrongInput;
            do {
                wrongInput = false;
                try {
                    Console.WriteLine("Enter your birth date(DD/MM/YYYY):");
                    DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", culture);
                    Console.WriteLine("Your age is {0}", GetAge(date));
                    Console.WriteLine("Your zodiac sign is {0}", GetZodiac(date));
                } catch (FormatException) {
                    Console.WriteLine("Wrong date format, please try again.");
                    wrongInput = true;
                } catch (Exception) {
                    Console.WriteLine("Unhandled exception, exiting");
                }
            } while (wrongInput);
            Console.ReadLine();
        }
        public static int GetAge(DateTime dateOfBirth) {
            int age = DateTime.Now.Year - dateOfBirth.Year;
            bool birthdayRiched = (DateTime.Now.Month > dateOfBirth.Month) ||
                ((DateTime.Now.Month == dateOfBirth.Month) && (DateTime.Now.Day >= dateOfBirth.Day));
            if (!birthdayRiched) age--;
            return age;
        }
        public static string GetZodiac(DateTime dateOfBirth) {
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
                if (dateOfBirth <= ZodiacEndDates[i])
                    return ZodiacNames[i];
            }
            return ZodiacNames[0];
        }
    }
}
