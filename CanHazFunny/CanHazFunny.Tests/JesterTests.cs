using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JesterTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Jester_NullJokeOutput_ArgumentNullException()
        {
            // Assign
            _ = new Jester(new JokeService(), null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Jester_NullJokeService_ArgumentNullException()
        {
            // Assign
            _ = new Jester(null, new JokeOutput());
        }

        [TestMethod]
        public void Jester_WorkingJokeOutput()
        {
            // Assign
            IJokeService jokeServ = new JokeService();
            IJokeOutput jokeOut = new JokeOutput();

            Jester jester = new Jester(jokeServ, jokeOut);

            // Act

            // Assert
            Assert.AreEqual(jokeOut, jester.JokeOut);
        }

        [TestMethod]
        public void Jester_WorkingJokeService()
        {
            // Assign
            IJokeService jokeServ = new JokeService();
            IJokeOutput jokeOut = new JokeOutput();

            Jester jester = new Jester(jokeServ, jokeOut);

            // Act

            // Assert
            Assert.AreEqual(jokeServ, jester.JokeServ);
        }

        [TestMethod]
        public void TellJoke_ChuckNorrisTest_FindNewJoke()
        {
            // Assign
            Mock<IJokeService> mock = new Mock<IJokeService>();

            mock.SetupSequence(jokeService => jokeService.GetJoke())
                .Returns("Chuck Norris does not sleep. He waits.")
                .Returns("Chuck Norris can divide by zero, and counted to infinity 3 times.")
                .Returns("When Chuck Norris falls in water, Chuck Norris doesn't get wet. Water gets Chuck Norris.")
                .Returns("No joke can stand up to this competition!")
                .Returns("Just any other old knee-slapper.");

            Jester jester = new Jester(mock.Object, new JokeOutput());

            // Act
            jester.TellJoke();

            // Assert
            mock.Verify(jokeService => jokeService.GetJoke(), Times.Exactly(4));
        }
        
        [TestMethod]
        public void PrintJoke_JokeOutputToTheConsole_JokeIsPrinted()
        {
            //Assign
            Mock<IJokeService> mockService = new Mock<IJokeService>();
            mockService.SetupSequence(JokeService => JokeService.GetJoke())
                .Returns("Just any other old knee-slapper.");

            Mock<IJokeOutput> mockOutput = new Mock<IJokeOutput>();
            mockOutput.SetupSequence(JokeOutput => JokeOutput.TellJoke("Just any other old knee-slapper."));
            Jester jester = new Jester(mockService.Object, mockOutput.Object);

            // Act
            jester.TellJoke();

            // Assert
            mockOutput.VerifyAll();
        }
    }
}
