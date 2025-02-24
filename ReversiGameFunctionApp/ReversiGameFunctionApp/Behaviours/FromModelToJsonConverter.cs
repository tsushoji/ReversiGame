using Newtonsoft.Json.Linq;
using ReversiGameFunctionApp.Models;
using System;
using System.Text.Json;

namespace ReversiGameFunctionApp.Behaviours
{
    public class FromModelToJsonConverter
    {
        public FromModelToJsonConverter() { }

        public string Convert<T>(List<T> items)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            return JsonSerializer.Serialize(items, options);
        }
    }
}

