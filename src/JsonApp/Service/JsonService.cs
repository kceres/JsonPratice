
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using ConsoleApplication.JsonApp.Entities;

namespace ConsoleApplication.JsonApp.Service
{
    public class JsonService
    {
        public void SerializeJson()
        {
            Person p1 = new Person() { name = "Maria", age = 2 };
            string outputJson = JsonConvert.SerializeObject(p1);

            File.WriteAllText("Data/Output.json", outputJson);
        }

        public void DeserializeJson(string _fileName)
        {
            String jsonString = File.ReadAllText(_fileName);
            Person p1 = JsonConvert.DeserializeObject<Person>(jsonString);

            Console.WriteLine(p1);
            Console.ReadLine();
        }

        public void JsonDataStorage(string _fileName)
        {
            Console.WriteLine("Reading " + _fileName);
            string jsonString = File.ReadAllText(_fileName);

            List<Item> myList = JsonConvert.DeserializeObject<List<Item>>(jsonString);

            if (myList == null)
                myList = new List<Item>();

            string input = "";
            int inputInt = 0;
            string inputString = "";

            while (input != "q")
            {
                Console.WriteLine("Press 'a' to add new Item");
                Console.WriteLine("Press 'd' to Delete Item");
                Console.WriteLine("Press 's' to Show Content");
                Console.WriteLine("Press 'q' to Quit Program");

                input = Console.ReadLine();

                switch (input)
                {
                    case "a":
                        Console.WriteLine("Adding a new item");
                        Console.WriteLine("Enter item name:");
                        inputString = Console.ReadLine();
                        Console.WriteLine("Enter item price (Numeric Value Only) :");
                        inputInt = Convert.ToInt32(Console.ReadLine());
                        myList.Add(new Item(inputString, inputInt));
                        Console.WriteLine("Add item " + inputString + " with price R$" + inputInt);
                        break;
                    case "d":
                        Console.WriteLine("Deleting item");
                        Console.WriteLine("Enter item name to delete:");
                        inputString = Console.ReadLine();
                        myList.Remove(new Item(inputString, inputInt));
                        Console.WriteLine("Deleted item with name " + inputString);
                        break;
                    case "s":
                        Console.WriteLine("Showing Contents:");
                        foreach (Item item in myList)
                            Console.WriteLine("Item: " + item.name + " | R$" + item.price);
                        Console.WriteLine("\n");
                        break;
                    case "q":
                        Console.WriteLine("Quit Program");
                        break;
                    default:
                        Console.WriteLine("Incorrect command, try again!");
                        break;
                }
            }

            Console.WriteLine("Rewriting " + _fileName);
            string data = JsonConvert.SerializeObject(myList);
            File.WriteAllText(_fileName, data);
            Console.ReadLine();
        }
    }
}