using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using D_Utilities;
using Newtonsoft.Json;

namespace D_UtilitiesUnitTests
{
    [TestClass]
    public class PBKDF_HelperUnitTest
    {
        [TestMethod]
        public void TestGenerateSaltMethod()
        {
            var salt = PBKDF_Helper.GenerateSalt();

            Assert.IsNotNull(salt);

            Assert.IsInstanceOfType(salt,typeof(byte[]));
        }

        [TestMethod]
        public void TestHashPasswordMethod()
        {
            var salt = PBKDF_Helper.GenerateSalt();

            var hashedpassword = PBKDF_Helper.HashPassword("password", salt, 200000);

            var hashedpassword2 = PBKDF_Helper.HashPassword("password", salt, 200000);

            Assert.IsTrue(hashedpassword.Equals(hashedpassword2));

        }
    }
}
