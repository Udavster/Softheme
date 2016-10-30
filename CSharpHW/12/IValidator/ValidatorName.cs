using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IValidator {
    class ValidatorName {
        public IUser ValidateUser(IUser user, IUser[] arr) {
            if (arr == null) return null;
            if ((user.Name == null) || (user.Name == "")) {
                throw new ArgumentException("No name to validate");
            }
            for (int i = 0; i < arr.Length; i++) {
                if (arr[i].Name == user.Name) {
                    if (arr[i].Password == user.Password) {
                        return arr[i];
                    } else {
                        throw new ArgumentException("Wrong password, try again");
                    }
                }
            }
            return null;
        }
    }
}
