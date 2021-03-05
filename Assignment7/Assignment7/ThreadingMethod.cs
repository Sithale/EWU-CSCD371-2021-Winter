using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment7
{
    public class ThreadingMethod
    {
        public static async Task<int> DownloadTextAsync(params string[] urls)
        {
            WebClient webClient = new();

            int count = 0;

            return await Task.Run(async () =>
            {
                foreach (string url in urls)
                    count += await Task.Run(() => webClient.DownloadString(url).Length);
                
                return count;

            });
        }

        public static async Task<int> DownloadTextRepeatedlyAsync(int rep, CancellationToken cancel, IProgress<double> prog, params string[] urls)
        {
            if (rep < 0) throw new AggregateException(nameof(rep));
            if (prog is null) throw new AggregateException(nameof(prog));

            int count = 0;
            int x = 0;

            for (int y = 0; y < rep && !cancel.IsCancellationRequested; y ++)
            {
                x += await DownloadTextAsync(urls);

                if (prog is not null)
                    prog.Report(count ++ / rep);
            }

            return x;

        }
    }
}
