using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Assignment9.Tests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        [TestMethod]
        public void MainWindowViewModel_UsingCreateAndDeleteCommands_ContactIsCreatedAndDeleted()
        {
            // Arrange
            MainWindowViewModel model = new();

            // Act
            int before = model.Contacts.Count;
            var contact = model.Contacts.Last();

            model.SelectedContact = contact;
            model.DeleteContactCommand.Execute(null);

            // Assert
            Assert.AreEqual<int>(before - 1, model.Contacts.Count);
            Assert.IsFalse(model.Contacts.Contains(contact));

        }

        [TestMethod]
        public void MainWindowViewModel_UsingEditContactCommand_IsBeingEditedReturnsTrue()
        {
            // Arrange
            MainWindowViewModel model = new();

            // Act
            model.IsBeingEdited = false;
            model.EditContactCommand.Execute(null);

            // Assert
            Assert.IsTrue(model.IsBeingEdited);

        }

        [TestMethod]
        public void MainWindowViewModel_UsingSaveContactCommandToExitEditing_IsBeingEditedReturnsFalse()
        {
            // Arrange
            MainWindowViewModel model = new();

            // Act
            model.IsBeingEdited = true;
            model.SelectedContact = model.Contacts.First();
            model.SaveContactCommand.Execute(null);

            // Assert
            Assert.IsFalse(model.IsBeingEdited);

        }

        [TestMethod]
        public void MainWindowViewModel_UsingSaveContactCommand_LastModifiedIsUpdated()
        {
            // Arrange
            MainWindowViewModel model = new();

            // Act
            model.SelectedContact = model.Contacts.First();
            DateTime originalDate = DateTime.Now;
            model.SelectedContact = model.Contacts.First();
            model.SelectedContact.LastModified = originalDate;
            model.SaveContactCommand.Execute(null);

            // Assert
            Assert.AreNotEqual<DateTime>(originalDate, (DateTime)model.SelectedContact.LastModified);

        }
    }
}

