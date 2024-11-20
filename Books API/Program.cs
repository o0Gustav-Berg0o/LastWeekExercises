using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using HtmlAgilityPack;
using static System.Reflection.Metadata.BlobBuilder;

class Program
{
    private const string BOOKS_URL = "http://books.toscrape.com/";

    static async Task Main(string[] args)
    {
        try
        {
            using (var client = new HttpClient())
            {
                Console.WriteLine($"Fetching books from: {BOOKS_URL}");
                string htmlContent = await client.GetStringAsync(BOOKS_URL);

                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(htmlContent);

                // Find all book elements
                var bookNodes = htmlDoc.DocumentNode.SelectNodes("//article[@class='product_pod']");

                if (bookNodes != null)
                {
                    Console.WriteLine($"\nFound {bookNodes.Count} books:\n");

                    // TODO  Create Book class with properties:
                    // - Title (string)
                    // - Price (decimal)
                    // - Rating (int or enum)
                    // - Availability (string)
                    // - ImageUrl (string)


                    // TODO  Create a List<Book> to store the books


                    // Inside the foreach loop:
                    foreach (var bookNode in bookNodes)
                    {
                        // Extract title
                        var titleNode = bookNode.SelectSingleNode(".//h3/a");
                        string title = titleNode?.GetAttributeValue("title", "No title");

                        // Extract price and clean it
                        var priceNode = bookNode.SelectSingleNode(".//p[@class='price_color']");
                        string priceText = priceNode?.InnerText ?? "0";
                        // Remove currency symbol and any non-numeric characters except decimal point
                        priceText = new string(priceText.Where(c => char.IsDigit(c) || c == '.').ToArray());
                        decimal price = decimal.TryParse(priceText, out decimal p) ? p : 0m;

                        // Extract rating
                        var ratingNode = bookNode.SelectSingleNode(".//p[contains(@class, 'star-rating')]");
                        string ratingClass = ratingNode?.GetAttributeValue("class", "");
                        int rating = ConvertRating(ratingClass);

                        // Extract availability
                        var availabilityNode = bookNode.SelectSingleNode(".//p[@class='availability']");
                        string availability = availabilityNode?.InnerText.Trim() ?? "Unknown";

                        // Extract image URL
                        var imageNode = bookNode.SelectSingleNode(".//img");
                        string imageUrl = imageNode?.GetAttributeValue("src", "") ?? "";
                        // Make image URL absolute if it's relative
                        if (!string.IsNullOrEmpty(imageUrl) && imageUrl.StartsWith("//"))
                        {
                            imageUrl = "https:" + imageUrl;
                        }

                        //TODO Now you can use these values to create a Book object
                       
                        //TODO Add book to list                        
                       
                    }

                    //TODO - Display book info

                    // TODO Bonus: Add these features:
                    // - Filter books under £20
                    // - Sort by rating
                    // - Find books by rating (user input)
                    // - Save results to CSV file
                }
                else
                {
                    Console.WriteLine("No books found on the page.");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred: {e.Message}");
        }
    }
    public class Book
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Rating { get; set; }
        public string Availability { get; set; }
        public string ImageUrl { get; set; }

        // TODO Optional: Override ToString for easy display
        public override string ToString()
        {
            return $"{Title}\n" +
                   $"Price: £{Price:F2}\n" +
                   $"Rating: {Rating} stars\n" +
                   $"Availability: {Availability}";
        }

        // Optional: Method to convert to CSV format
        public string ToCsv()
        {
            return $"\"{Title}\",{Price},{Rating},\"{Availability}\",\"{ImageUrl}\"";
        }
       
    }
    private static int ConvertRating(string ratingClass)
    {
        //TODO match pattern and return int         
        return 1;
    }
}
