using AdventOfCode.Day5;
using NUnit.Framework;

namespace AdventOfCode.Tests.Day5
{
    [TestFixture]
    public class PasswordDecryptorTests
    {
        private PasswordDecryptor passwordDecryptor;

        [SetUp]
        public void Setup()
        {
            passwordDecryptor = new PasswordDecryptor();
        }

        [TestCase("abc", "18f47a30")]
        public void DecryptPassword(string doorID, string password)
        {
            var decryptedPassword = passwordDecryptor.Decrypt(doorID);
            Assert.That(decryptedPassword, Is.EqualTo(password));
        }

        [Test]
        public void DAY_5_1()
        {
            var decryptedPassword = passwordDecryptor.Decrypt("abbhdwsy");
            Assert.That(decryptedPassword.Length, Is.EqualTo(8));
            Assert.Pass($"The password is {decryptedPassword}");
        }

        [TestCase("abc", "05ace8e3")]
        public void DecryptFancyPassword(string doorID, string password)
        {
            var decryptedPassword = passwordDecryptor.FancyDecrypt(doorID);
            Assert.That(decryptedPassword, Is.EqualTo(password));
        }

        [Test]
        public void DAY_5_2()
        {
            var decryptedPassword = passwordDecryptor.FancyDecrypt("abbhdwsy");
            Assert.That(decryptedPassword.Length, Is.EqualTo(8));
            Assert.Pass($"The password is {decryptedPassword}");
        }
    }
}
