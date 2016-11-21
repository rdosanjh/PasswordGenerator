﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;

namespace PasswordGen.Models
{
    public class Credentials
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime Expires { get; set; }
    }
}
