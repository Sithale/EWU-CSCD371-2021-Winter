using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace Assignment7
{
    class ThreadingMethodTests
    {
        [TestClass]
        public class Assignment7Tests
        {
            private static void CancelTemp(double prog, double perc, CancellationTokenSource source)
            {
                if (perc > prog) source.Cancel();

            }

            [TestMethod]
            [ExpectedException(typeof(AggregateException))]
            public void DownloadTextAsync_NullParam_ReturnsAggregateException()
            {
                // Assert
                Console.WriteLine(ThreadingMethod.DownloadTextAsync(null!).Result);

            }

            [TestMethod]
            public void DownloadTextAsync_EmptyParam_ZeroSizeIsCorrect()
            {
                // Assert
                Assert.AreEqual<int>(0, ThreadingMethod.DownloadTextAsync().Result);

            }

            [TestMethod]
            public void DownloadTextAsync_ValidGoogleParam_ReturnsCorrectResult()
            {
                // Assert
                Assert.IsTrue(ThreadingMethod.DownloadTextAsync("https://google.com").Result > 5000);

            }

            [TestMethod]
            public void DownloadTextRepeatedlyAsync_ValidRepitionParam_ReturnsCorrectResult()
            {
                // Arrange
                CancellationTokenSource source = new();
                CancellationToken cancel = source.Token;

                // Act
                int res = ThreadingMethod.DownloadTextRepeatedlyAsync(99, cancel, new Progress<double>(perc =>
                    Console.WriteLine(perc)), "https://google.com").Result;

                // Assert
                Assert.IsTrue(res > 1000);

            }

            [TestMethod]
            [ExpectedException(typeof(AggregateException))]
            public void DownloadTextRepeatedlyAsync_GivenNegativeRepitition_ReturnsAggregateException()
            {
                // Arrange
                CancellationTokenSource source = new CancellationTokenSource();
                CancellationToken cancel = source.Token;

                // Assert
                Assert.AreEqual(0, ThreadingMethod.DownloadTextRepeatedlyAsync(-2020, cancel, new Progress<double>(x =>
                    Console.WriteLine(x)), "https://google.com").Result);

            }

            [TestMethod]
            [ExpectedException(typeof(AggregateException))]
            public void DownloadTextRepeatedlyAsync_NullProgress_ReturnsAggregateException()
            {
                // Arrange
                CancellationTokenSource source = new();
                CancellationToken cancel = source.Token;

                // Assert
                Assert.AreEqual<int>(0, ThreadingMethod.DownloadTextRepeatedlyAsync(50, cancel, null!, "https://google.com").Result);

            }

            [TestMethod]
            public void DownloadTextRepeatedlyAsync_CancelAction_SuccessfullyCancels()
            {
                // Arrange
                CancellationTokenSource source = new();
                CancellationToken cancel = source.Token;

                // Act
                int res = ThreadingMethod.DownloadTextRepeatedlyAsync(100, cancel, new Progress<double>(perc =>
                    CancelTemp(.9, perc, source)), "https://google.com").Result;

                // Assert
                Assert.IsTrue(100 < res && res < 999999999);

            }
        }
    }
}
