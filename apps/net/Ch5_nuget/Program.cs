﻿using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using HtmlAgilityPack;

namespace Ch5_nuget;

internal class MainClass
{
    public static void Main()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(".NET Web Scraper");
        var sw = Stopwatch.StartNew();

        GetTitleRange();

        Console.WriteLine($"Done in {sw.ElapsedMilliseconds / 1000.0} sec.");
    }

    public static void GetTitleRange()
    {
        // Please keep this range pretty small to not DDoS my site. ;)
        for (var i = 220; i < 231; i++)
        {
            var html = GetEpisodeHtml(i);
            var title = GetTitle(html);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Found title for #{i}: {title}");
        }

        Console.ForegroundColor = ConsoleColor.White;
    }

    public static string GetEpisodeHtml(int episodeNumber, string url = null)
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

        var response = client.GetAsync(url).Result;
        if (response.StatusCode == HttpStatusCode.Moved || response.StatusCode == HttpStatusCode.MovedPermanently)
        {
            url = response.Headers.Location.ToString();
            return GetEpisodeHtml(episodeNumber, url);
        }

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Invalid request, got code {response.StatusCode}");
        }

        var html = response.Content.ReadAsStringAsync().Result;
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
