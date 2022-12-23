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

        public static string DownloadUrl(string fileName = "/", string localFileName = "")
        {
            //var req = WebRequest.Create(new Uri("https://cloud-api.yandex.net/v1/disk/resources/download?path=disk:/" + Uri.EscapeUriString(fileName)));
            ////((HttpWebRequest)req).Accept = "*/*";
            ////req.Headers["Depth"] = "1";
            //req.Headers["Authorization"] = "OAuth 0aab0aa10dd44578bcfe23f65d51f410";
            //((HttpWebRequest)req).Proxy = null;
            //var resp = req.GetResponse();

            //var text = new StreamReader(resp.GetResponseStream()).ReadToEnd();
            HttpClient client = new HttpClient();
            var x = client.GetAsync("https://cloud-api.yandex.net/v1/disk/public/resources/download?public_key=https%3A%2F%2Fdisk.yandex.ee%2Fd%2Frn4Zyytc-qr5gw")..Result.Content.ReadAsStringAsync().Result;
            Asnwer a = JsonSerializer.Deserialize<Asnwer>(x);
            return client.GetAsync(a.href).Result.Content.ReadAsStringAsync().Result;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine(DownloadUrl("https://disk.yandex.ee/d/rn4Zyytc-qr5gw"));
        }
    }
}