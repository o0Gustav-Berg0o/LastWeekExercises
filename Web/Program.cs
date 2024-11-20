using System;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Collections.Generic;  // Add this for List<T>

class Program
{
    private const string WEB_URL = "https://quotes.toscrape.com/";
    static async Task Main(string[] args)
    {
        try
        {
            using (var client = new HttpClient())
            {
                Console.WriteLine($"Fetching content from: {WEB_URL}");
                string htmlContent = await client.GetStringAsync(WEB_URL);

                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(htmlContent);

                var quoteNodes = htmlDoc.DocumentNode.SelectNodes("//div[@class='quote']");

                if (quoteNodes != null)
                {
                    Console.WriteLine($"\nFound {quoteNodes.Count} quotes:\n");

                    // TODO Exercise 1: Create a Quote class with properties:
                    // - Text (string)
                    // - Author (string)
                    // - Tags (string)


                    // TODO Exercise 2: Create a List<Quote> to store the quotes
                    // Hint: List<Quote> quotes = new List<Quote>();


                    foreach (var quoteNode in quoteNodes)
                    {
                        var textNode = quoteNode.SelectSingleNode(".//span[@class='text']");
                        var text = textNode?.InnerText.Trim('"', ' ');

                        var authorNode = quoteNode.SelectSingleNode(".//small[@class='author']");
                        var author = authorNode?.InnerText;

                        var tagNodes = quoteNode.SelectNodes(".//div[@class='tags']/a[@class='tag']");
                        var tags = tagNodes != null
                            ? string.Join(", ", tagNodes.Select(n => n.InnerText))
                            : "No tags";

                        // TODO Exercise 3: Create a new Quote object and add to list
                        // Hint: quotes.Add(new Quote { ... });


                        // TODO Exercise 4: Display the quote information using
                        // Console.WriteLine()
                        // Show: Text, Author, and Tags

                    }
                }
                else
                {
                    Console.WriteLine("No quotes found on the page.");
                }
            }
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Error fetching webpage: {e.Message}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred: {e.Message}");
        }
    }
}

