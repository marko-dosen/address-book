using System;
using AddressBook.Contracts.Models;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;

namespace Client
{
    public class MockClient
    {
        public static void Main(string[] args)
        {
            var connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:44322/contacthub/");


            var hub = connection.Build();

            //connection.TraceLevel = TraceLevels.All;
            //connection.TraceWriter = Console.Out;
            //
            //Console.WriteLine($"Url:{connection.Url}");

            hub.StartAsync().ContinueWith(task => {
                if (task.IsFaulted) {
                    Console.WriteLine("There was an error opening the connection:{0}",
                        task.Exception.GetBaseException());
                } else {
                    Console.WriteLine("Connected");
                }

            }).Wait();

            hub.On<ContactWithId>("ContactCreate", payload =>
            {
                Console.WriteLine("Received create contact message.");
                Console.WriteLine($"Data: {JsonConvert.SerializeObject(payload)}");
            });

            hub.On<ContactWithId>("ContactUpdate", payload =>
            {
                Console.WriteLine("Received update contact message.");
                Console.WriteLine($"Data: {JsonConvert.SerializeObject(payload)}");
            });

            hub.On<Guid>("ContactDelete", payload =>
            {
                Console.WriteLine("Received delete contact message.");
                Console.WriteLine($"Data: {JsonConvert.SerializeObject(payload)}");
            });

            Console.Read();
            hub.StopAsync();
        }
    }
}
