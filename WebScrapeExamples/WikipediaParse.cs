using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;

namespace WebScrapeExamples
{
    static internal class WikipediaParse
    {
        static private async Task<string> GetSite()
        {
            // Hard coded wikipedia URL
            string url = "https://en.wikipedia.org/wiki/Good_News_for_People_Who_Love_Bad_News"; 

            Console.WriteLine("Fetching...");

            // HttpClient object for sending and receving HTTP requests/responses
            HttpClient client = new HttpClient(); 

            // Basic security for a proper HTTPS response
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls13;
            client.DefaultRequestHeaders.Accept.Clear();

            // Request the HTML content and wait for a response 
            var response = client.GetStringAsync(url);
            return await response;
        }

        // Returns unfiltered result of GetSite() task and returns it as a string
        static internal string FullResponse()
        {
            string response = GetSite().Result;

            return response;
        }
    }
}
