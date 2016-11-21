using System;

namespace PasswordGen.Repository
{
    public class Clock : IClock
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }

    public interface IClock
    {
        DateTime Now();
    }
}
