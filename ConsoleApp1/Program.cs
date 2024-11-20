using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;

class Program
{
    private const string API_KEY = "";
    private const string BASE_URL = "https://api.api-ninjas.com/v1/quotes";

    static async Task Main(string[] args)
    {
        Console.WriteLine("Welcome to Quote Generator!");
        Console.WriteLine("-------------------------");

        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("X-Api-Key", API_KEY);

            while (true)
            {
                try
                {
                    //TODO Show menu
                    Console.WriteLine("\nChoose a category:");
                   
                    //TODO Read choice

                    //TODO Map choice to category                    

                    //TODO Fetch and display quote
                    await FetchAndDisplayQuote(client, "Love");

                    // Ask if user wants another quote
                    Console.Write("\nPress Enter for another quote or 'Q' to return to menu: ");
                    string input = Console.ReadLine()?.ToUpper() ?? "";
                    if (input == "Q")
                        continue;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"\nAn error occurred: {e.Message}");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                }
            }
        }

        Console.WriteLine("\nThank you for using Quote Generator!");
    }

    static async Task FetchAndDisplayQuote(HttpClient client, string category)
    {
        string url = $"{BASE_URL}?category={category}";

        Console.WriteLine($"\nFetching a {category} quote...");

        HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();

        string jsonContent = await response.Content.ReadAsStringAsync();
        var quotes = JsonSerializer.Deserialize<List<Quote>>(jsonContent);

        //TODO - Display quote
        Console.WriteLine("Quotes");
    }
}

class Quote
{
    public string quote { get; set; }
    public string author { get; set; }
    public string category { get; set; }
}


/* Categorys to choose from: 
 
 category  optional
Category to limit results to. Possible values are:

age
alone
amazing
anger
architecture
art
attitude
beauty
best
birthday
business
car
change
communication
computers
cool
courage
dad
dating
death
design
dreams
education
environmental
equality
experience
failure
faith
family
famous
fear
fitness
food
forgiveness
freedom
friendship
funny
future
god
good
government
graduation
great
happiness
health
history
home
hope
humor
imagination
inspirational
intelligence
jealousy
knowledge
leadership
learning
legal
life
love
marriage
medical
men
mom
money
morning
movies
success*/