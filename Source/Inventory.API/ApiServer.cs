// ApiServer.cs
using System;
using System.Net;
using System.Threading;
using HttpListener = System.Net.HttpListener;

public class ApiServer
{
    private readonly HttpListener _listener = new HttpListener();
    private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
    private readonly ManualResetEvent _listenerStoppedEvent = new ManualResetEvent(false);

    public ApiServer()
    {
        _listener.Prefixes.Add("http://localhost:8080/"); // Mettez le préfixe que vous souhaitez utiliser
    }

    public void Start()
    {
        _listener.Start();

        // Lancer le traitement des requêtes dans un nouveau thread
        ThreadPool.QueueUserWorkItem(HandleRequests);
    }

    public void Stop()
    {
        // Demander l'annulation et attendre que le traitement des requêtes soit terminé
        _cancellationTokenSource.Cancel();
        _listenerStoppedEvent.WaitOne();

        _listener.Stop();
    }

    private void HandleRequests(object state)
    {
        try
        {
            while (!_cancellationTokenSource.Token.IsCancellationRequested)
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
        catch (HttpListenerException)
        {
            // L'exception HttpListenerException sera levée lorsque le listener sera fermé, ce qui est attendu lors de l'arrêt du serveur.
        }
        finally
        {
            _listenerStoppedEvent.Set(); // Indiquer que le traitement des requêtes est terminé
        }
    }
}

