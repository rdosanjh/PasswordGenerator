using System;

namespace PasswordGen.Repository
{
    public class PasswordGenerator: IPasswordGenerator
    {
        private readonly IPasswordStore _passwordStore;
        public PasswordGenerator(IPasswordStore passwordStore)
        {
            _passwordStore = passwordStore;
        }

        public string GeneratePassword(string username)
        {
            var password = Guid.NewGuid().ToString();
            _passwordStore.AddPasswordForUsername(username, password);
            return password;
        }
    }
}
