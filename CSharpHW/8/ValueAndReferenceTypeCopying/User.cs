using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueAndReferenceTypeCopying {
    class User {
        public User(string name, string password, string email = null) {
            this.Name = name;
            this.password = password;
            this.Email = email;
        }
        public string Name { get; private set; }
        private string password;
        public string Email{get; private set;}
        public bool CheckPassword(string password) {
            return (this.password == password);
        }
        public bool TryChangePassword(string password, string newPassword) {
            if (!CheckPassword(password)) return false;
            this.password = newPassword;
            return true;
        }
        public void ChangePassword(string password, string newPassword) {
            if (!TryChangePassword(password, newPassword))
                throw new UnauthorizedAccessException("Wrong password");
        }
        public void ChangeCredentials(string password, string name = null, string newPassword = null, string email = null) {
            if (!CheckPassword(password)) {
                throw new UnauthorizedAccessException("Wrong password");
            }
            this.Name = name ?? this.Name;
            this.password = newPassword ?? this.password;
            this.Email = email ?? this.Email;
        }
    }
}
