using System;
using Moq;
using PasswordGen.Repository;
using Xunit;

namespace test
{
    public class Tests
    {
        [Fact]
        public void Can_create_user_and_verify() 
        {
            var clock = new Clock();
            var passwordStore = new PasswordStore(clock);
            var passwordGenerator = new PasswordGenerator(passwordStore);
            var username = "test-user";
            var password = passwordGenerator.GeneratePassword(username);
            var success = passwordStore.IsPasswordValidForUsername(username, password);

            Assert.True(success);
        }

        [Fact]
        public void user_cant_login_with_wrong_password()
        {
            var clock = new Clock();
            var passwordStore = new PasswordStore(clock);
            var passwordGenerator = new PasswordGenerator(passwordStore);
            var username = "test-user";
            var password = passwordGenerator.GeneratePassword(username);
            var success = passwordStore.IsPasswordValidForUsername(username, password + "te");

            Assert.False(success);
        }

        [Fact]
        public void user_cant_login_after_password_experation()
        {
            var clockMock = new Mock<IClock>();
            var fakeDateTime = new DateTime().AddYears(10);
            clockMock.Setup(c => c.Now()).Returns(fakeDateTime);
            var passwordStore = new PasswordStore(clockMock.Object);
            var passwordGenerator = new PasswordGenerator(passwordStore);
            var username = "test-user";
            var password = passwordGenerator.GeneratePassword(username);

            var futureClockMock = new Mock<IClock>();
            var futureFakeDateTime = fakeDateTime.AddSeconds(31);
            futureClockMock.Setup(c => c.Now()).Returns(futureFakeDateTime);
            var passwordStoreWithExpiredClock = new PasswordStore(futureClockMock.Object);
            var success = passwordStoreWithExpiredClock.IsPasswordValidForUsername(username, password);

            Assert.False(success);
        }
    }
}
