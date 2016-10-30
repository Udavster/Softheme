using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IValidator {
    class ValidatorEmail: IValidator {
        public IUser ValidateUser(IUser user, IUser[] arr) {
            if (arr == null) return null;
            if((user.Email == null)||(user.Email=="")){
                throw new ArgumentException("No email to validate");
            }
            for (int i = 0; i < arr.Length; i++) {
                if (arr[i].Email == user.Email) {
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
