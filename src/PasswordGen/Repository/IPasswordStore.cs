namespace PasswordGen.Repository
{
    public interface IPasswordStore
    {
        void AddPasswordForUsername(string username, string password);
        bool IsPasswordValidForUsername(string username, string password);
    }
}
