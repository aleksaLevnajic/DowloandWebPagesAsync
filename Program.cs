using System.Net;
using System;
using static System.Net.WebRequestMethods;

namespace DowloandWebPagesAsync
{
    internal class Program
    {
        static async Task Main()
        {
            Task task1 = DownloadWebPage("https://sh.wikipedia.org/wiki/Berlinski_zid");
            Task task2 = DownloadWebPage("https://sh.wikipedia.org/wiki/Drugi_svjetski_rat");
            Task taks3 = DownloadWebPage("https://sr.wikipedia.org/sr-ec/Svetska_finansijska_kriza_2007.");

            //await Task.WhenAll(task1, task2, taks3);
            await Task.WhenAny(task1, task2, taks3);
        }

        public static async Task DownloadWebPage(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string page = await client.GetStringAsync(url);
                    Console.WriteLine($"Downloaded from { url }:\n { page }\n");
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Error downloading { url }: { ex.Message }\n");
                }
            }

        }
    }
}
