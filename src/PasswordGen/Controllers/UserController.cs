using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PasswordGen.Models;
using PasswordGen.Repository;

namespace PasswordGen.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IPasswordStore _passwordStore;

        public UserController(IPasswordStore passwordStore)
        {
            _passwordStore = passwordStore;
        }
        // GET api/values/5
        public bool Get(Credentials credentials)
        {
            return _passwordStore.IsPasswordValidForUsername(credentials.Username, credentials.Password);

        }
    }
}
