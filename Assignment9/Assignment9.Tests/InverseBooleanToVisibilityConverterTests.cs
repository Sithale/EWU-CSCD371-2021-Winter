using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;

namespace Assignment9.Tests
{
    [TestClass]
    public class InverseBooleanToVisibilityConverterTests
    {
        [TestMethod]
        public void InverseBooleanToVisibilityConverterTests_ConvertIsTrue_VisibilityBecomesCollapsed()
        {
            // Arrange
            InverseBooleanToVisibilityConverter convert = new();

            // Act
            Visibility visibility = (Visibility)convert.Convert(true, null, null, null);

            // Assert
            Assert.AreEqual<Visibility>(Visibility.Collapsed, visibility);

        }

        [TestMethod]
        public void InverseBooleanToVisibilityConverterTests_ConvertIsFalse_VisibilityBecomesVisibile()
        {
            // Arrange
            InverseBooleanToVisibilityConverter convert = new();

            // Act
            Visibility visibility = (Visibility)convert.Convert(false, null, null, null);

            // Assert
            Assert.AreEqual<Visibility>(Visibility.Visible, visibility);

        }

        [TestMethod]
        public void InverseBooleanToVisibilityConverterTests_ConvertBackIsVisible_VisibilityBecomesFalse()
        {
            // Arrange
            InverseBooleanToVisibilityConverter convert = new();

            // Act
            bool visibility = (bool)convert.ConvertBack(Visibility.Visible, null, null, null);

            // Assert
            Assert.AreEqual<bool>(false, visibility);

        }

        [TestMethod]
        public void InverseBooleanToVisibilityConverterTests_ConvertBackIsCollapsed_VisibilityBecomesTrue()
        {
            // Arrange
            InverseBooleanToVisibilityConverter convert = new();

            // Act
            bool visibility = (bool)convert.ConvertBack(Visibility.Collapsed, null, null, null);

            // Assert
            Assert.AreEqual<bool>(true, visibility);

        }
    }
}
