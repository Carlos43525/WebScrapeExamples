using System;
using WebScrapeExamples;

namespace WebScrapExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HtmlParsers.GetTrackListingTable(WikipediaParse.FullResponse());

            //HtmlParsers.GetTrackListing(WikipediaParse.FullResponse());
            //Console.WriteLine(WikipediaParse.FullResponse());
        }
    }
}