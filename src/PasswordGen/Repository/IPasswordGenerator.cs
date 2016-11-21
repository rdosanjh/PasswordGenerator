namespace PasswordGen.Repository
{
    public interface IPasswordGenerator
    {
        string GeneratePassword(string username);
    }
}
