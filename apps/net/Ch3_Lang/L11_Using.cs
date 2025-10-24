using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Ch3_Lang;

internal class Using
{
    public static void Run()
    {
        var data = new Dictionary<string, string>
        {
            { "Name", "Michael" },
            { "Language", "C#" }
        };

        using (var file = File.CreateText(@"file.json"))
        {
            var serializer = new JsonSerializer();
            serializer.Serialize(file, data);
        }

        Console.WriteLine("Created file.json in working directory.");
    }
}
