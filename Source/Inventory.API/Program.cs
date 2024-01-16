// Program.cs
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Starting your API...");
        var apiServer = new ApiServer();
        apiServer.Start();
        Console.WriteLine("API is running. Press Enter to exit.");
        Console.ReadLine();
        apiServer.Stop();
    }
}

