using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IValidator {
    class Program {
        static void Main(string[] args) {
            User[] users = new User[0];
            ValidatorEmail emailValidator = new ValidatorEmail();
            ValidatorName nameValidator = new ValidatorName();
            try {
                while (true) {
                    try {
                        string validationWay;
                        string name = "";
                        string email = "";
                        do {
                            Console.WriteLine("Would you like to validate via Email (E) or Name (N)?");
                            validationWay = Console.ReadLine().ToUpper();
                        } while ((validationWay != "E") && (validationWay != "N"));
                        if (validationWay.ToUpper() == "E") {
                            Console.WriteLine("Enter email (To exit enter 'exit' here and in password field)");
                            email = Console.ReadLine();
                        } else {
                            Console.WriteLine("Enter name (To exit enter 'exit' here and in password field)");
                            name = Console.ReadLine();
                        }
                        Console.WriteLine("Enter password");
                        string password = Console.ReadLine();
                        if (((email.ToUpper() == "EXIT") || (name.ToUpper() == "EXIT"))
                            && (password.ToUpper() == "EXIT")) return;
                        User user = new User(password, name, email);
                        User authorisedUser;
                        if (validationWay.ToUpper() == "E") {
                            authorisedUser = (User)emailValidator.ValidateUser(user, users);
                        } else {
                            authorisedUser = (User)nameValidator.ValidateUser(user, users);
                        }
                        if (authorisedUser == null) {
                            Array.Resize(ref users, users.Length + 1);
                            users[users.Length - 1] = user;
                            Console.WriteLine("You've just been added to database");
                        } else {
                            Console.WriteLine("You're authorised");
                            Console.WriteLine(authorisedUser.GetFullInfo());
                        }
                    } catch (ArgumentException ex) {
                        Console.WriteLine("Exception: {0}", ex.Message);
                    }

                }
            } catch (Exception ex){
                Console.WriteLine("Sorry, unhandled exception ({0})", ex.Message);
            }
        }
    }
}
