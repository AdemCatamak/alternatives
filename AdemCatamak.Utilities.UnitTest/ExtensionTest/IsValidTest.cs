﻿using AdemCatamak.Utilities.UnitTest.ExtensionsTestClass;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdemCatamak.Utilities.UnitTest.ExtensionTest
{
    [TestClass]
    public class IsValidTest
    {
        [TestMethod]
        public void AdemCatamak_Utilities_UnitTest_ExtensionsTest__IsValid_NullTest()
        {
            bool isValid = ((object)null).IsValid();


            Assert.IsFalse(isValid, "Item is valid");
        }

        [TestMethod]
        public void AdemCatamak_Utilities_UnitTest_ExtensionsTest__IsValid_EmailFormat()
        {
            bool isValid = SetEmailAndTest("ademcatamak@gmail.com");
            Assert.IsTrue(isValid, "Email-1 format must be valid");


            isValid = SetEmailAndTest("catamak@itu.edu.tr");
            Assert.IsTrue(isValid, "Email-2 format must be valid");


            isValid = SetEmailAndTest("x@x.com");
            Assert.IsTrue(isValid, "Email-3 format must be valid");


            isValid = SetEmailAndTest("x@");
            Assert.IsFalse(isValid, "Email-4 format has not be valid");


            isValid = SetEmailAndTest("22343");
            Assert.IsFalse(isValid, "Email-5 format has not be valid");
        }

        private static bool SetEmailAndTest(string emailAddress)
        {
            IsValidTestClass item = new IsValidTestClass()
                                    {
                                        Phone = "555 555 55 55",
                                        RequiredPhone = "123",
                                        Username = "ademcatamak",
                                        Email = emailAddress
                                    };

            return item.IsValid();
        }

        [TestMethod]
        public void AdemCatamak_Utilities_UnitTest_ExtensionsTest__IsValid_Required()
        {
            bool isValid = SetUsernameAndTest("ademcatamak@gmail.com");
            Assert.IsTrue(isValid, "Username-1 format must be valid");


            isValid = SetUsernameAndTest(null);
            Assert.IsFalse(isValid, "Username-2 format has not be valid");
        }

        private static bool SetUsernameAndTest(string username)
        {
            IsValidTestClass item = new IsValidTestClass
                                    {
                                        Phone = "555-555-55-55",
                                        RequiredPhone = "123",
                                        Email = "ademcatamak@gmail.com",
                                        Username = username
                                    };

            return item.IsValid();
        }


        [TestMethod]
        public void AdemCatamak_Utilities_UnitTest_ExtensionsTest__IsValid_TurkeyPhoneFormat()
        {
            bool isValid = SetPhoneNumberAndTest("+90 555 555 55 55");
            Assert.IsTrue(isValid, "Phone-1 format is not valid");

            isValid = SetPhoneNumberAndTest("+90-555-555-55-55");
            Assert.IsTrue(isValid, "Phone-2 format is not valid");

            isValid = SetPhoneNumberAndTest("0555-555-55-55");
            Assert.IsTrue(isValid, "Phone-3 format is not valid");

            isValid = SetPhoneNumberAndTest("555-555-55-55");
            Assert.IsTrue(isValid, "Phone-4 format is not valid");

            isValid = SetPhoneNumberAndTest("+905555555555");
            Assert.IsTrue(isValid, "Phone-5 format is not valid");

            isValid = SetPhoneNumberAndTest("+90 555 555 55 5");
            Assert.IsFalse(isValid, "Phone-6 format is valid");

            isValid = SetPhoneNumberAndTest("+90 555 555 55 5a");
            Assert.IsFalse(isValid, "Phone-7 format is valid");

            isValid = SetPhoneNumberAndTest("+90 555 5?5 55 55");
            Assert.IsFalse(isValid, "Phone-8 format is valid");
        }

        private static bool SetPhoneNumberAndTest(string phoneNumber)
        {
            IsValidTestClass item = new IsValidTestClass()
                                    {
                                        RequiredPhone = "123",
                                        Username = "ademcatamak",
                                        Email = "ademcatamak@gmail.com",
                                        Phone = phoneNumber
                                    };

            return item.IsValid();
        }
    }
}