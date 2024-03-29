﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocusFileManager.Users.Model
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int AccessedXMLFiles { get; set; }
        public int AccessedTXTFiles { get; set; }
        public int AccessedJSONFiles { get; set; }
        public string Token { get; set; }
    }
}
