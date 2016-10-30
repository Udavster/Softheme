using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IValidator {
    interface IValidator {
        IUser ValidateUser(IUser user, IUser[] arr);
    }
}
