using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Windows;

namespace Assignment9.Tests
{
    [TestClass]
    public class EmptyStringToVisibilityConverterTests
    {
        [TestMethod]
        public void EmptyStringToVisibilityConverterTests_PassedNullParams_ConvertsToCollapsed()
        {
            // Arrange
            EmptyStringToVisibilityConverter convert = new();

            // Act
            Visibility visible = (Visibility)convert.Convert(null, null, null, null);

            // Assert
            Assert.AreEqual<Visibility>(Visibility.Collapsed, visible);

        }

        [TestMethod]
        public void EmptyStringToVisibilityConverterTests_PassedStringParam_ConvertsToVisible()
        {
            // Arrange
            EmptyStringToVisibilityConverter convert = new();

            // Act
            Visibility visible = (Visibility)convert.Convert("Test", null, null, null);

            // Assert
            Assert.AreEqual<Visibility>(Visibility.Visible, visible);

        }

        [TestMethod]
        public void EmptyStringToVisibilityConverterTests_PassedEmptyParam_ConvertsToCollapsed()
        {
            // Arrange
            EmptyStringToVisibilityConverter convert = new();

            // Act
            Visibility visible = (Visibility)convert.Convert("", null, null, null);

            // Assert
            Assert.AreEqual<Visibility>(Visibility.Collapsed, visible);

        }
    }
}
