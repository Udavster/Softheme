using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Human {
    class Human : IEquatable<Human> { //?
        public Human(string firstName, string lastName) {
            this.BirthDate = DateTime.Now;
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        public Human(string firstName, string lastName, DateTime birthDate) {
            this.BirthDate = birthDate;
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        public DateTime BirthDate { get; private set; }
        //FirstName, Lastame, Age.
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age {
            get {
                int age = DateTime.Now.Year - BirthDate.Year;
                bool birthdayRiched = (DateTime.Now.Month > BirthDate.Month) ||
                    ((DateTime.Now.Month == BirthDate.Month) && (DateTime.Now.Day >= BirthDate.Day));
                if (!birthdayRiched) age--;
                return age;
            }
        }
        public override int GetHashCode() {
            int hash = FirstName.GetHashCode() ^ LastName.GetHashCode();
            hash ^= BirthDate.Day ^ BirthDate.Month ^ BirthDate.Year;
            return hash;
        }
        public override bool Equals(object obj) {
            Human human = obj as Human;
            if (human == null) {
                return false;
            }
            return this.Equals(human);
        }
        public bool Equals(Human human) {
            return (this.FirstName == human.FirstName)
                && (this.LastName == this.LastName) && DateTimesEqualityByDate(this.BirthDate, human.BirthDate);
        }
        public override string ToString() {
            return string.Format("{0} {1}, {2}", FirstName, LastName, BirthDate);
        }
        private bool DateTimesEqualityByDate(DateTime dateTime1, DateTime dateTime2) {
            if ((dateTime1 == null) || (dateTime2 == null)) throw new ArgumentNullException();
            return (dateTime1.Year == dateTime2.Year) && (dateTime1.Month == dateTime2.Month)
                && (dateTime1.Day == dateTime2.Day);
        }
    }
}
