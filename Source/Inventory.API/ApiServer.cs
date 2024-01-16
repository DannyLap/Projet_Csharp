// ApiServer.cs
using System;
using System.Net;
using System.Threading;
using HttpListener = System.Net.HttpListener;

public class ApiServer
{
    private readonly HttpListener _listener = new HttpListener();
    private readonly Thread _listenerThread;

    public ApiServer()
    {
        _listener.Prefixes.Add("http://localhost:8080/"); // Mettez le préfixe que vous souhaitez utiliser
        _listenerThread = new Thread(HandleRequests);
    }

    public void Start()
    {
        _listener.Start();
        _listenerThread.Start();
    }

    public void Stop()
    {
        _listenerThread.Abort();
        _listener.Stop();
    }

    private void HandleRequests()
    {
        while (true)
        {
            var context = _listener.GetContext(); // Bloque jusqu'à ce qu'une requête soit reçue
            var response = context.Response;

            // Traitez la requête ici
            var responseBody = "Hello, World!";
            var buffer = System.Text.Encoding.UTF8.GetBytes(responseBody);

            response.ContentLength64 = buffer.Length;
            var output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            output.Close();
        }
    }
}
