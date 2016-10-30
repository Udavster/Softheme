using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IValidator {
    class User : IUser {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public User(string password, string name = null, string email = null) {
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.lastVisit = DateTime.Now;
        }
        private DateTime lastVisit;
        public string GetFullInfo() {
            lastVisit = DateTime.Now;
            return String.Format("User of name {0} with Email {1}"
                + ", password {2} last visit - {3}",
                this.Name, this.Email, this.Password, this.lastVisit.ToString());
        }
    }
}
