﻿using System;
using System.Collections.Generic;
using System.Linq;
using Alternatives.Extensions;
using Xunit;

namespace Alternatives.UnitTest.ExtensionTest.ReflectionExtensionTests
{
    public class GetInheritedTypesTest
    {
        #region TestModel

        private interface IInterface
        {
        }

        private interface IGenericInterface<T>
        {
            T GenericField { get; set; }
        }

        private abstract class FirstLevelAbstract
        {
        }

        private abstract class SecondLevelAbstractClass : FirstLevelAbstract
        {
        }

        private class TestAbstract : SecondLevelAbstractClass
        {
        }

        private class TestInterface : IInterface
        {
        }

        private class TestGenericInterface : IGenericInterface<int>
        {
            public int GenericField { get; set; }
        }

        private class AnotherTestInterface : IInterface
        {
        }

        private class AnotherTestGenericInterface : IGenericInterface<string>
        {
            public string GenericField { get; set; }
        }

        #endregion

        [Fact]
        public void Alternatives_UnitTest_ExtensionsTest__GetInheritedTypes_BaseInterface()
        {
            // Act
            DateTime startTime = DateTime.Now;
            List<Type> typeList = ReflectionExtensions.GetInheritedTypes(typeof(IInterface)).ToList();
            DateTime endTime = DateTime.Now;


            Console.WriteLine($"Runtime : {endTime.Ticks - startTime.Ticks:#,0}");

            // Assert
            Assert.Equal(2, typeList.Count);
            Assert.True(typeList.Contains(typeof(TestInterface)));
            Assert.True(typeList.Contains(typeof(AnotherTestInterface)));
        }

        [Fact]
        public void Alternatives_UnitTest_ExtensionsTest__GetInheritedTypes_BaseGenericInterface()
        {
            // Act
            DateTime startTime = DateTime.Now;
            List<Type> typeList = ReflectionExtensions.GetInheritedTypes(typeof(IGenericInterface<>)).ToList();
            DateTime endTime = DateTime.Now;


            Console.WriteLine($"Runtime : {endTime.Ticks - startTime.Ticks:#,0}");

            // Assert
            Assert.Equal(2, typeList.Count);
            Assert.True(typeList.Contains(typeof(TestGenericInterface)));
            Assert.True(typeList.Contains(typeof(AnotherTestGenericInterface)));
        }


        [Fact]
        public void Alternatives_UnitTest_ExtensionsTest__GetInheritedTypes_BaseGenericInterfaceSpesific()
        {
            // Act
            DateTime startTime = DateTime.Now;
            List<Type> typeList = ReflectionExtensions.GetInheritedTypes(typeof(IGenericInterface<int>)).ToList();
            DateTime endTime = DateTime.Now;


            Console.WriteLine($"Runtime : {endTime.Ticks - startTime.Ticks:#,0}");

            // Assert
            Assert.Equal(1, typeList.Count);
            Assert.True(typeList.Contains(typeof(TestGenericInterface)));
        }


        [Fact]
        public void Alternatives_UnitTest_ExtensionsTest__GetInheritedTypes_BaseAbstractClassImplemetor_Parent()
        {
            // Act
            DateTime startTime = DateTime.Now;
            List<Type> typeList = ReflectionExtensions.GetInheritedTypes(typeof(SecondLevelAbstractClass)).ToList();
            DateTime endTime = DateTime.Now;


            Console.WriteLine($"Runtime : {endTime.Ticks - startTime.Ticks:#,0}");

            // Assert
            Assert.Equal(1, typeList.Count);
            Assert.True(typeList.Contains(typeof(TestAbstract)));
        }

        [Fact]
        public void Alternatives_UnitTest_ExtensionsTest__GetInheritedTypes_BaseAbstractClassImplemetor_GrandParent()
        {
            // Act
            DateTime startTime = DateTime.Now;
            List<Type> typeList = ReflectionExtensions.GetInheritedTypes(typeof(FirstLevelAbstract)).ToList();
            DateTime endTime = DateTime.Now;


            Console.WriteLine($"Runtime : {endTime.Ticks - startTime.Ticks:#,0}");

            // Assert
            Assert.Equal(2, typeList.Count);
            Assert.True(typeList.Contains(typeof(TestAbstract)));
        }
    }
}