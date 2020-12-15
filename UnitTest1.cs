using Xunit;
using System;
using IIG.PasswordHashingUtils;
namespace XUnitTestProject1
{
    public class UnitTest1
    {

        [Fact]
        public void TestHashingPasswordWith()
        {
            Assert.Throws<ArgumentNullException>(() => PasswordHasher.GetHash(null));
        }

        [Fact]
        public void TestHashingIdenticalPasswords()
        {
            string pass1 = "password";
            string pass2 = "password";
            Assert.Equal(PasswordHasher.GetHash(pass1), (PasswordHasher.GetHash(pass2)));
        }

        [Fact]
        public void TestHashingNonIdenticalPasswords()
        {
            string pass1 = "password1";
            string pass2 = "password2";
            Assert.NotEqual(PasswordHasher.GetHash(pass1), (PasswordHasher.GetHash(pass2)));
        }

        [Fact]
        public void TestHashingBlankPasswords()
        {
            string pass = "";
            Assert.NotNull(PasswordHasher.GetHash(pass));
        }

        [Fact]
        public void TestHashingPasswordWithSpaces()
        {
            string pass = " ";
            Assert.NotNull(PasswordHasher.GetHash(pass));
        }

        [Fact]
        public void TestHashingPasswordWithNonLatinSymbols()
        {
            string pass1 = "☆☆☆☆☆";
            string pass2 = "未知のたわごと";
            string pass3 = "абракадабра";

            Assert.NotNull(PasswordHasher.GetHash(pass1));
            Assert.NotNull(PasswordHasher.GetHash(pass2));
            Assert.NotNull(PasswordHasher.GetHash(pass3));
        }

        [Fact]
        public void TestHashingPasswordDifferentWithRegister()
        {
            string pass1 = "password";
            string pass2 = "PaSsWoRd";
            Assert.NotEqual(PasswordHasher.GetHash(pass1), PasswordHasher.GetHash(pass2));
        }

        //testing salt

        [Fact]
        public void TestHashingPasswordWithSameSalts()
        {
            string pass = "password";
            string salt = "salt";
            Assert.Equal(PasswordHasher.GetHash(pass, salt, null), PasswordHasher.GetHash(pass, salt, null));
        }

        [Fact]
        public void TestHashingPasswordWithDifferentSalts()
        {
            string pass = "password";
            string salt1 = "salt";
            string salt2 = "sugar";
            Assert.NotEqual(PasswordHasher.GetHash(pass, salt1, null), PasswordHasher.GetHash(pass, salt2, null));
        }

        [Fact]
        public void TestHashingPasswordWithSpacesAndNullSalts()
        {
            string pass = "password";
            string salt1 = "salt";
            
            Assert.Equal(PasswordHasher.GetHash(pass, salt1, null), PasswordHasher.GetHash(pass, null, null));
        }

        //testing adler32

        [Fact]
        public void TestHashingPasswordWithSameAdler32()
        {
            string pass = "password";

            Assert.Equal(PasswordHasher.GetHash(pass, null, 12345), PasswordHasher.GetHash(pass, null, 12345));
        }

        [Fact]
        public void TestHashingPasswordWithDifferentAdler32()
        {
            string pass = "password";

            Assert.NotEqual(PasswordHasher.GetHash(pass, null, 12), PasswordHasher.GetHash(pass, null, 12345));
        }
    }
}
