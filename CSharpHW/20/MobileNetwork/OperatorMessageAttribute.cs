using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace MobileNetwork
{
    enum OperatorMessageStatus
    {
        Info,
        Error
    }
    class OperatorMessageAttribute:Attribute
    {
        public OperatorMessageStatus Status { get; set; }
        public string Text{get; set;}
    }
}
