using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Assignment9.Tests
{
    [TestClass]
    public class RelayCommandTests
    {
        [TestMethod]

        [ExpectedException(typeof(ArgumentNullException))]
        public void RelayCommand_GivenNullParams_ThrowsArgumentNullException()
        {
            // Act
            RelayCommand NullCommand = new RelayCommand(null, null);
        }

        [TestMethod]
        public void RelayCommand_CantExecute_ReturnsFalse()
        {
            // Act
            RelayCommand relayCommand = new RelayCommand(() => System.Console.WriteLine("Test"), () => false);

            // Assert
            Assert.IsFalse(relayCommand.CanExecute(null));
        }

        [TestMethod]

        public void RelayCommand_CanExecute_ReturnsTrue()
        {
            // Act
            RelayCommand relayCommand = new RelayCommand(() => System.Console.WriteLine("Test"), () => true);

            // Assert
            Assert.IsTrue(relayCommand.CanExecute(null));
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void RelayCommand_ExecutesWithNullParam_ThrowsNotImplementedException()
        {
            // Act
            RelayCommand relayCommand = new RelayCommand(() => throw new NotImplementedException(), () => true);
            relayCommand.Execute(null);
        }

    }
}
