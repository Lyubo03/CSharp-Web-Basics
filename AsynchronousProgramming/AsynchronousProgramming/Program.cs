namespace AsynchronousProgramming
{
    using System;
    using System.Threading.Tasks;
    using System.Threading;
    using System.IO;
    using System.Drawing;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Net.Sockets;

    public class Program
    {
        public static void EvenNums(int a, int b)
        {
            for (int i = a; i <= b; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
        public static void PrintNumsSlowly()
        {
            for (int i = 0; i < 1000; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine(i);
            }
        }
        private static string result;
        public static async Task Download()
        {
            WebClient clien = new WebClient();

            Console.WriteLine("Downloading...");

            await clien.DownloadFileTaskAsync(@"https://bg.wikipedia.org/wiki/%D0%91%D0%BB%D0%BE%D0%B3", "index.txt");

            Console.WriteLine("Finished!");
        }
        public static void Main(string[] args)
        {
            var port = 1337;
            var ipAddress = IPAddress.Parse("127.0.0.1");

            var tcpListener = new TcpListener(ipAddress, port);

            tcpListener.Start();

            Task.Run(async () => await Connect(tcpListener))
                .GetAwaiter()
                .GetResult();
        }
        public static async Task Connect(TcpListener listener)
        {
            while (true)
            {
                var client = await listener.AcceptTcpClientAsync();

                var buffer = new byte[1024];
                await client.GetStream().ReadAsync(buffer, 0, buffer.Length);
                var clientMessage = Encoding.UTF8.GetString(buffer);

                Console.WriteLine(clientMessage.TrimEnd('\0'));

                var responseMessage = "HTTP/1.1 200 OK\nContent-Type: text/plain\n\nHello from server!";
                var data = Encoding.UTF8.GetBytes(responseMessage);
                await client.GetStream().WriteAsync(data, 0, data.Length);

                client.Dispose();
            }
        }
        public static async Task GetHeaders(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var contentToSent = new StringContent("Hello");
                var response = await httpClient.PostAsync(url,contentToSent);

                
                if (response.IsSuccessStatusCode)
                {
                    var headers = response.Headers;

                    foreach (var header in headers)
                    {
                        Console.WriteLine(header.Key + ": " + string.Join(' ', header.Value));
                    }

                    var content = response.Content.ReadAsStringAsync();

                    Console.WriteLine(content);
                }
                else
                {
                    Console.WriteLine(response.StatusCode);
                }
            }
        }
        private static async void DoWork()
        {
            var results = new List<bool>();
            var tasks = new List<Task>();

            for (int i = 0; i < 10; i++)
            {
                tasks.Add(Task.Run(async () =>
                {
                    var result = await SlowMetod();
                    results.Add(result);
                }));
            }

            await Task.WhenAll(tasks.ToArray());

            Console.WriteLine("Finished");

        }
        private static async Task<bool> SlowMetod()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Result!");

            return true;
        }
    }
}
//const string resultDir = "Result";

//if (Directory.Exists(resultDir))
//{
//    Directory.Delete(resultDir, true);
//}
//Directory.CreateDirectory(resultDir);

//var currentDirectory = Directory.GetCurrentDirectory();
//var dirInfo = new DirectoryInfo(currentDirectory + "/../../../Images");

//var files = dirInfo.GetFiles();

//var tasks = new List<Task>();

//foreach (var file in files)
//{
//    var task = Task.Run(() =>
//{
//    Image image = Image.FromFile(file.FullName+"fsdhjs");
//    image.RotateFlip(RotateFlipType.Rotate180FlipX);
//    image.Save($"{resultDir}\\flip-{file.Name}");

//    Thread.Sleep(1000);
//    Console.WriteLine($"{file.Name} processed...");
//});
//    tasks.Add(task);
//}
//try
//{
//    Task.WaitAll(tasks.ToArray());

//}
//catch (AggregateException ex)
//{
//    foreach (var exception in ex.InnerExceptions)
//    {
//        Console.WriteLine(exception.Message );
//    }
//}
//Console.WriteLine("Finished");