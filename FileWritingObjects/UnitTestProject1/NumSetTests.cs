using FileWritingObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Assignment4.Tests
{
    [TestClass]
    public class NumSetTests
    {
        NumSet Set = new();

        void buildArray()
        {
            Set = new(1, 1, 3, 4);
        }

        [TestMethod]
        public void NumSet_ConstructorCall_AcceptsParamList()
        {
            // Act
            buildArray();
        }

        [TestMethod]
        public void NumSet_Contains_ElementIsContained()
        {
            // Act
            buildArray();

            // Assert
            Assert.IsTrue(Set.Contains(4));
        }

        [TestMethod]
        public void NumSet_Contains_MissingElementIsntContained()
        {
            // Act
            buildArray();

            // Assert
            Assert.IsFalse(Set.Contains(6));
        }

        [TestMethod]
        public void NumSet_ToString_ContainsListedElements()
        {
            // Act
            string res = new NumSet(42, 21, 69).ToString();

            // Assert
            Assert.IsTrue(res.Contains("42"));
            Assert.IsTrue(res.Contains("21"));
            Assert.IsTrue(res.Contains("69"));
        }

        [TestMethod]
        public void NumSet_ElementArray_ContainsListedElements()
        {
            // Act
            int[] set = new NumSet(42, 21, 69).GetArray();

            // Assert
            Assert.IsTrue(Array.Exists(set, element => element == 42));
            Assert.IsTrue(Array.Exists(set, element => element == 21));
            Assert.IsTrue(Array.Exists(set, element => element == 69));
        }

        [TestMethod]
        public void NumSet_GetArray_ArraySetDoesntGetChanged()
        {
            // Assign
            NumSet set = new(1, 2, 3);

            // Act
            int[] array = set.GetArray();
            array[0] = 42;

            // Assert
            Assert.IsFalse(set.Contains(42));
        }

        [TestMethod]
        public void Equals_GivenTwoArrayComparedValues_ReturnsFalseOnDifference()
        {
            //Assign
            int[] tempArray1 = new int[] { 1, 1, 3, 4, 9, 9 };
            int[] tempArray2 = new int[] { 1, 1, 3, 3, 9, 9 };

            NumSet set1 = new NumSet(tempArray1);

            NumSet set2 = new NumSet(tempArray2);

            //Assert
            Assert.IsFalse(set1.Equals(set2));
        }

        [TestMethod]
        public void Equals_PassedNumSet_ReturnsTrueOnSameValue()
        {
            //Assign
            int[] intArray = new int[] { 1, 1, 3, 4, 9, 9 };
            NumSet set = new NumSet(intArray);

            //Assert
            Assert.IsTrue(set.Equals(set));
        }

        [TestMethod]
        public void Equals_PassedNumSet_ReturnsFalseOnDifferentValue()
        {
            //Assign
            int[] intArray = new int[] { 1, 1, 3, 4, 9, 9 };

            NumSet set = new NumSet(intArray);

            Object obj = new object();

            //Assert
            Assert.IsFalse(set.Equals(obj));
        }
    }
}
