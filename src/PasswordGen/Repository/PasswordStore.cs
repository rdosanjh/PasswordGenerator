using System;
using System.Collections.Generic;
using System.Linq;
using PasswordGen.Models;

namespace PasswordGen.Repository
{
    public class PasswordStore : IPasswordStore
    {
        private static readonly List<Credentials> _credetials = new List<Credentials>();

        private readonly IClock _clock;

        public PasswordStore(IClock clock)
        {
            _clock = clock;
        }

        public void AddPasswordForUsername(string username, string password)
        {
            _credetials.Add(new Credentials
            {
                Username = username,
                Password = password,
                Expires = _clock.Now().Add(TimeSpan.FromSeconds(30))
            });
        }

        public bool IsPasswordValidForUsername(string username, string password)
        {
            return _credetials.Any(c => c.Username == username &&
                                       c.Password == password &&
                                       DateTime.Compare(c.Expires, _clock.Now()) > 0);
        }
    }
}
