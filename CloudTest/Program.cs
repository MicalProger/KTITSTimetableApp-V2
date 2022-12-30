using System.Net;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace CloudTest
{
    public class Asnwer
    {
        public string href { get; set; }
    }
    internal class Program
    {
        static string ParseUrl(string resultString)
        {
            string pattern = "https://(.+?)\"";
            return Regex.Match(resultString, pattern).Value.TrimEnd('"');
        }

        public static void DownloadUrl(string fileName = "/", string localFileName = "")
        {
            WebClient web = new WebClient();
            web.DownloadProgressChanged += Web_DownloadProgressChanged;
            using (HttpClient cl = new HttpClient())
            {
                var loadLink = cl.GetAsync($"https://cloud-api.yandex.net/v1/disk/public/resources/download?public_key=" + fileName).Result.Content.ReadAsStringAsync().Result;
                var finalLink = JsonDocument.Parse(loadLink).RootElement.GetProperty("href").GetString();
                web.DownloadFileAsync(new Uri(finalLink), localFileName);
            }
        }

        private static void Web_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Console.WriteLine((double)e.BytesReceived  / (double)e.TotalBytesToReceive * 100);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            DownloadUrl("https://disk.yandex.ee/i/cvkguOXkF-U68g", "load.mp4");
            while(true);
        }
    }
}