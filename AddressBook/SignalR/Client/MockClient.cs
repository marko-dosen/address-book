using System;
using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json;

namespace Client
{
    public class MockClient
    {
        public static void Main(string[] args)
        {
            var connection = new HubConnection("https://localhost:44322/ContactHub",false);

            var hub = connection.CreateHubProxy("ContactHub");

            connection.TraceLevel = TraceLevels.All;
            connection.TraceWriter = Console.Out;

            Console.WriteLine($"Url:{connection.Url}");

            

            connection.Start().ContinueWith(task => {
                if (task.IsFaulted) {
                    Console.WriteLine("There was an error opening the connection:{0}",
                        task.Exception.GetBaseException());
                } else {
                    Console.WriteLine("Connected");
                }

            }).Wait();

            hub.On<object>("ContactCreate", payload =>
            {
                Console.WriteLine("Received create contact message.");
                Console.WriteLine($"Data: {JsonConvert.SerializeObject(payload)}");
            });

            hub.On<object>("ContactUpdate", payload =>
            {
                Console.WriteLine("Received update contact message.");
                Console.WriteLine($"Data: {JsonConvert.SerializeObject(payload)}");
            });

            hub.On<object>("ContactDelete", payload =>
            {
                Console.WriteLine("Received delete contact message.");
                Console.WriteLine($"Data: {JsonConvert.SerializeObject(payload)}");
            });

            Console.Read();
            connection.Stop();
        }
    }
}
