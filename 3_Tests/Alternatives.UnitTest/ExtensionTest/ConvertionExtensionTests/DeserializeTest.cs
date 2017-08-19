﻿using System;
using Alternatives.Extensions;
using Alternatives.UnitTest.TestModel.ExtensionsTestClass;
using Alternatives.UnitTest.TestModel.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Alternatives.UnitTest.ExtensionTest.ConvertionExtensionTests
{
    [TestClass]
    public class DeserializeTest
    {
        [TestMethod]
        public void Alternatives_UnitTest_ExtensionsTest__Deserialize_Null()
        {
            IsValidTestClass actual = @"null".Deserialize<IsValidTestClass>();


            Assert.AreEqual(null, actual, $"{actual} is not expected");
        }

        [TestMethod]
        public void Alternatives_UnitTest_ExtensionsTest__Deserialize_NotMatchClass()
        {
            string item = @"
{""Phone"":null,
""Email"":""ademcatamak@gmail.com"",
""Username"":""ademcatamak"",
""RequiredPhone"":null,
""Id"":3,""ExtraData"":null}"
                .Replace(" ", string.Empty)
                .Replace(Environment.NewLine, string.Empty);

            AnotherTestGenericInterface actual = item.Deserialize<AnotherTestGenericInterface>();

            Assert.IsNull(actual.GenericField);
        }

        [TestMethod]
        public void Alternatives_UnitTest_ExtensionsTest__Deserialize()
        {
            IsValidTestClass expected = new IsValidTestClass
                                        {
                                            Id = 3,
                                            Username = "ademcatamak",
                                            Email = "ademcatamak@gmail.com"
                                        };
            string item = @"
{""Phone"":null,
""Email"":""ademcatamak@gmail.com"",
""Username"":""ademcatamak"",
""RequiredPhone"":null,
""Id"":3,""ExtraData"":null}"
                .Replace(" ", string.Empty)
                .Replace(Environment.NewLine, string.Empty);


            IsValidTestClass actual = item.Deserialize<IsValidTestClass>();


            Assert.AreEqual(expected.Id, actual.Id, $"{actual.Id} is not expected");
            Assert.AreEqual(expected.Username, actual.Username, $"{actual.Username} is not expected");
            Assert.AreEqual(expected.Email, actual.Email, $"{actual.Email} is not expected");
            Assert.AreEqual(expected.ExtraData, actual.ExtraData, $"{actual.ExtraData} is not expected");
            Assert.AreEqual(expected.Phone, actual.Phone, $"{actual.Phone} is not expected");
            Assert.AreEqual(expected.RequiredPhone, actual.RequiredPhone, $"{actual.RequiredPhone} is not expected");
        }
    }
}