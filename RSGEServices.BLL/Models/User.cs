using System;
using System.Collections.Generic;
using System.Text;

namespace RSGEServices.BLL.Models
{
    public class User
    {
        public bool Authenticated { get; set; }
        public string FullName { get; set; }
        public string PersNo { get; set; }
        public string PayerType { get; set; }
        public string PayerTypeName { get; set; }
        public string Address { get; set; }
    }
}
