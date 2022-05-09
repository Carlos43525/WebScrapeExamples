using System;
using System.Linq;
using System.Collections.Generic;
using AngleSharp;
using AngleSharp.Html.Parser;

namespace WebScrapeExamples
{
    static internal class HtmlParsers
    {
        // Retrieves track listing from the WikipediaParse.cs class
        static internal void GetTrackListing(string html)
        {
            // Set up for AngleSharp
            var context = BrowsingContext.New(Configuration.Default);
            var parser = context.GetService<IHtmlParser>();
            var document = parser.ParseDocument(html);

            // QuerySelectorAll grabs the .tracklist table and all rows below but the header
            var elements = document.QuerySelectorAll(".tracklist tr:not(:first-child)").ToList();

            foreach (var e in elements)
            {
                Console.WriteLine(e.TextContent);
            }
        }

        // Retrieves track listing from the WikipediaParse.cs class and formats them into a table
        static internal async void GetTrackListingTable (string html)
        {
            // Set up for AngleSharp
            var context = BrowsingContext.New(Configuration.Default);
            var parser = context.GetService<IHtmlParser>();
            var document = await context.OpenAsync(req => req.Content(html));

            // QuerySelectorAll grabs the .tracklist table and all rows below but the header
            var elements = document.QuerySelectorAll(".tracklist tr:not(:first-child)");


            var query = elements.Select(row => new
            {
                Number = row.ChildNodes[0].TextContent.Trim(),
                Name = row.ChildNodes[1].TextContent.Trim(),
                Length = row.ChildNodes[2].TextContent.Trim(),
            });

            // Query syntax 
            //var query = from row in elements
            //            select new
            //            {
            //                Number = row.ChildNodes[0].TextContent.Trim(),
            //                Name = row.ChildNodes[1].TextContent.Trim(),
            //                Length = row.ChildNodes[2].TextContent.Trim(),
            //            };

            Console.WriteLine($"|{"Track No.", 10}|{"Title", 35}|{"Length", 20}|");

            foreach (var e in query)
            {
                Console.WriteLine($"|{e.Number, 10}|{e.Name, 35}|{e.Length, 20}|");
            }
        }
    }
}

//List<string> table = document.DocumentNode.SelectSingleNode("//table[@class='tracklist']")
//.Descendants("tr")
//.Skip(1)
//.Where(tr => tr.Elements("th").Count() >= 1)
//.SelectMany(tr => tr.ChildNodes)
//.Where(node => "td|th".Contains(node.Name))
////.Select(node => node.InnerText)
//.Select(node => new
//{
//    number = node.SelectSingleNode()
//    .Attributes[].
//});
//.ToList();