using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace Assignment7
{
    [TestClass]
    public class ThreadingTests
    {
        [TestMethod]
        public void DownloadTextAsync_GoogleParam_LargeNumOfUrls()
        {
            Assert.IsTrue(Assignment7.DownloadTextAsync("https://google.com").Result > 1000);
        }

        [TestMethod]
        public void DownloadTextAsync_NothingInParams_LenghtOfZeroExpected()
        {
            Assert.AreEqual<int>(0, Assignment7.DownloadTextAsync().Result);
        }

        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void DownloadTextAsync_NullValueInserted_ExceptionExpected()
        {
            Console.WriteLine(Assignment7.DownloadTextAsync(null!).Result);
        }

        [TestMethod]
        public void DownloadTextRepeatedlyAsync_GoogleParam_LargeNumOfUrls()
        {
            CancellationTokenSource source = new();
            CancellationToken token = source.Token;
            int rep = 10;
            int res = 0;
            res = Assignment7.DownloadTextRepeatedlyAsync(rep, token, new Progress<double>(bar => Console.WriteLine(bar)), "https://google.com").Result;
            Assert.IsTrue(res > 1000);
        }

        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void DownloadTextRepeatedlyAsync_NegRepititions_ExceptionExpected()
        {
            CancellationTokenSource source = new();
            CancellationToken token = source.Token;
            Assert.AreEqual<int>(0, Assignment7.DownloadTextRepeatedlyAsync(-100, token, new Progress<double>(bar => Console.WriteLine(bar)), "https://google.com").Result);
        }

        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void DownloadTextRepeatedlyAsync_NullProgress_ExceptionExpected()
        {
            CancellationTokenSource source = new();
            CancellationToken token = source.Token;
            Assert.AreEqual<int>(0, Assignment7.DownloadTextRepeatedlyAsync(100, token, null!, "https://google.com").Result);
        }

        [TestMethod]
        public void DownloadTextRepeatedlyAsync_Cancel_GetsCancelled()
        {
            CancellationTokenSource source = new();
            CancellationToken token = source.Token;
            int res = Assignment7.DownloadTextRepeatedlyAsync(100, token, new Progress<double>(bar => CancelTask(.1, bar, source)), "https://google.com").Result;
            Assert.IsTrue(100 < res && res < 10000000);
        }

        private void CancelTask(double progress, double bar, CancellationTokenSource source)
        {
            if (bar > progress) source.Cancel();
        }
    }
}
}
