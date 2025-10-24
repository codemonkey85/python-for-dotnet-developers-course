using System.Diagnostics;
using System.Net;
using HtmlAgilityPack;

namespace Ch9_Async;

internal class MainClass
{
    public static void Main()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("C# Concurrent Web Scraper.");
        var sw = Stopwatch.StartNew();

        GetTitleRange().Wait();

        Console.WriteLine($"Done in {sw.ElapsedMilliseconds / 1000.0} sec.");
    }

    public static async Task GetTitleRange()
    {
        var tasks = new List<Tuple<int, Task<string>>>();

        // Please keep this range pretty small to not DDoS my site. ;)
        for (var i = 220; i < 231; i++)
        {
            var task = GetEpisodeHtml(i);
            var item = new Tuple<int, Task<string>>(i, task);
            tasks.Add(item);
        }

        foreach (var item in tasks)
        {
            var episodeNumber = item.Item1;
            var task = item.Item2;
            var html = await task;
            var title = GetTitle(html);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Found title for #{episodeNumber}: {title}");
        }

        Console.ForegroundColor = ConsoleColor.White;
    }

    public static async Task<string> GetEpisodeHtml(int episodeNumber, string url = null)
    {
        if (string.IsNullOrEmpty(url))
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Getting HTML for episode {episodeNumber}");
        }

        if (url == null)
        {
            url = $"https://talkpython.fm/{episodeNumber}";
        }

        var client = new HttpClient();

        var response = await client.GetAsync(url);
        if (response.StatusCode == HttpStatusCode.Moved || response.StatusCode == HttpStatusCode.MovedPermanently)
        {
            url = response.Headers.Location.ToString();
            return await GetEpisodeHtml(episodeNumber, url);
        }

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Invalid request, got code {response.StatusCode}");
        }

        var html = await response.Content.ReadAsStringAsync();
        return html;
    }

    public static string GetTitle(string html)
    {
        var page = new HtmlDocument();
        page.LoadHtml(html);
        var h1 = page.DocumentNode.SelectSingleNode("//h1");

        return h1.InnerText.Trim();
    }
}
