using System;
using System.Collections.Generic;
using System.Text;

namespace MEC3App.Model
{
     public class UserDto
    {
        public string data { get; set; }
        public string userEmail { get; set; }
        public string userName { get; set; }
        public string customerName { get; set; }

        public UserDto(string data, string userEmail, string userName, string customerName)
        {
            this.data = data;
            this.userEmail = userEmail;
            this.userName = userName;
            this.customerName = customerName;
        }
    }
}
