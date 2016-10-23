using System;

namespace ConsoleZodiac {
    class Program {
        static void Main(string[] args) {
            bool wrongInput;
            do {
                wrongInput = false;
                try {
                    Console.WriteLine("Enter your birth date(DD/MM/YYYY):");
                    DateTime date = ParseDate(Console.ReadLine(), date: new DateTime());
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
        public static DateTime ParseDate(string s,  DateTime date, int partN = 0){
            if ((partN==0)&&(s.Length < 9)) throw new FormatException();
            try {
                switch (partN) {
                    case 0:
                        date = new DateTime();
                        date = ParseDate(s.Substring(0, 3), date, 1);
                        date = ParseDate(s.Substring(3, 3), date, 2);
                        date = ParseDate(s.Substring(6, 4), date, 3);
                        break;
                    case 1:
                        if (s[2] != '/') throw new FormatException();
                        s = s.Substring(0, 2);
                        int day;
                        if (!Int32.TryParse(s, out day)) throw new FormatException();
                        if ((day < 0) || (day > 31)) throw new FormatException();
                        date = new DateTime(1000, 1, day);
                        break;
                    case 2:
                        if (s[2] != '/') throw new FormatException();
                        s = s.Substring(0, 2);
                        int month;
                        if (!Int32.TryParse(s, out month)) throw new FormatException();
                        if ((month < 0) || (month > 12)) throw new FormatException();
                        if (!Int32.TryParse(s, out month)) throw new FormatException();
                        date = new DateTime(1000, month, date.Day);
                        break;
                    case 3:
                        s = s.Substring(0, 4);
                        int year;
                        if (!Int32.TryParse(s, out year)) throw new FormatException();
                        if ((year < 1000) || (year > DateTime.Now.Year)) throw new FormatException();
                        if (!Int32.TryParse(s, out year)) throw new FormatException();
                        date = new DateTime(year, date.Month, date.Day);
                        break;
                }
            } catch (Exception) {
                throw new FormatException(); //29.02.2001
            }
            return date;
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
