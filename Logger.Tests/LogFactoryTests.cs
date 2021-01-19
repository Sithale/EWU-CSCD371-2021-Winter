using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {

        [TestMethod]
        public void CreateLogger_FileLoggerFailsConfiguration_ReturnNull()
        {
            // Arrange
            LogFactory logFac = new LogFactory();

            // Act
            BaseLogger? baseLog = logFac.CreateLogger(nameof(LogFactoryTests));

            // Assert
            Assert.IsNull(baseLog);
        }

        [TestMethod]
        public void CreateLogger_ClassNameAndPath_ResultIsEnteredCorrectly()
        {
            // Arrange
            LogFactory logFac = new LogFactory();
            logFac.ConfigureFileLogger("FilePath");

            // Act
            FileLogger? fileLog = (FileLogger?)logFac.CreateLogger(nameof(LogFactoryTests));

            string className = "";
            string filePath = "";

            if(fileLog != null && !string.IsNullOrEmpty(fileLog.ClassName))
            {
                className = fileLog.ClassName;
                filePath = fileLog.FilePath;
            }

            // Assert
            Assert.AreEqual(nameof(LogFactoryTests), className);
            Assert.AreEqual(filePath, "FilePath");
        }
    }
}
