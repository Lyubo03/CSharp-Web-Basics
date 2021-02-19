namespace HttpRequester
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Net.Sockets;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class Program
    {
        static Dictionary<string, int> SessionStore = new Dictionary<string, int>();

        public static async Task Main(string[] args)
        {
            var listener = new TcpListener(IPAddress.Loopback, 80);
            listener.Start();

            while (true)
            {
                TcpClient client = await listener.AcceptTcpClientAsync();

                Task.Run(() => ProcessClientAsync(client));
            }
        }
        private static async Task ProcessClientAsync(TcpClient client)
        {
            const string NewLine = "\r\n";

            using NetworkStream stream = client.GetStream();
            byte[] requestedBytes = new byte[1000000];
            int bytesRead = await stream.ReadAsync(requestedBytes, 0, requestedBytes.Length);
            string request = Encoding.UTF8.GetString(requestedBytes, 0, bytesRead);

            byte[] fileContent = File.ReadAllBytes("Mustang.jpg");

            string headers =
                "HTTP/1.0 200 OK" + NewLine +
                "Server: SoftUniServer/1.0" + NewLine +
                "Content-Type: image/jpeg" + NewLine +
                "Content-Lenght: " + fileContent.Length + NewLine +
                NewLine;

            byte[] responseBytes = Encoding.UTF8.GetBytes(headers);
            await stream.WriteAsync(responseBytes, 0, responseBytes.Length);
            await stream.WriteAsync(fileContent);
            Console.WriteLine(request);
            Console.WriteLine(new string('=', 60));
        }
        public async static Task HttpRequest()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://softuni.bg/");
            string result = await response.Content.ReadAsStringAsync();
            File.WriteAllText("index.html", result);
        }
    }
}
//"<form action='/Action/Login' method='post'>
//< input type = date name = 'date' />
//   < input type = text name = 'username' />
//      < input type = password name = 'pasword' />
//         < input type = submit value = 'Login' />
//            </ form > " 