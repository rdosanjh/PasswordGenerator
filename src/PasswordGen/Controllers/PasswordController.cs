using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PasswordGen.Repository;

namespace PasswordGen.Controllers
{
    [Route("api/[controller]")]
    public class PasswordController : Controller
    {
        private readonly IPasswordGenerator _passwordGenerator;

        public PasswordController(IPasswordGenerator passwordGenerator)
        {
            _passwordGenerator = passwordGenerator;
        }
        // GET api/values/5
        [HttpGet("{username}")]
        public string Get(string username)
        {
            return _passwordGenerator.GeneratePassword(username);
            
        }
    }
}
