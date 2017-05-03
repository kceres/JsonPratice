using System;
using System.IO;

namespace ConsoleApplication
{
    public class Program
    {
        public const string _jsonFileFirst = "Data/Example1.json";
        public const string _jsonFileSecond = "Data/Example2.json";
        public static void Main(string[] args)
        {
            var _jsonService = new JsonApp.Service.JsonService();

            _jsonService.SerializeJson();
            _jsonService.DeserializeJson(_jsonFileFirst);
            _jsonService.JsonDataStorage(_jsonFileSecond);
        }
    }
}
