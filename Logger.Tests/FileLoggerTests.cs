using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        public void FileLogger_FilePathIsCreated()
        {
            // Arrange
            LogFactory logFac = new LogFactory();

            // Act
            //Path for file is subject to change if folder location is moved for the text file.
            logFac.ConfigureFileLogger("P:/.Net Programming Assignment 2/Logger/test.txt");
            FileLogger? fileLog = (FileLogger?)logFac.CreateLogger(nameof(FileLoggerTests));

            fileLog?.Debug("Message {0}", 531);

            // Assert

        }
    }
}
