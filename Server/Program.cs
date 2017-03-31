using ServerManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Server
{
  class Program
  {
    private ServerManager _server;
    private BackgroundWorker _listenerThread;

    public static void Main(string[] args)
    {
      var hostNameOrAddress = "127.0.0.1";
      int port = 11000;
      if (args.Length > 0)
      {
        hostNameOrAddress = args[0];
      }
      if (args.Length > 1)
      {
        port = int.Parse(args[1]);
      }
      Program programDomain = new Program();
      programDomain._server = new ServerManager(hostNameOrAddress, port);

      programDomain._listenerThread = new BackgroundWorker();
      programDomain._listenerThread.WorkerSupportsCancellation = true;
      programDomain._listenerThread.DoWork += new DoWorkEventHandler(programDomain._server.StartListening);
      programDomain._listenerThread.RunWorkerAsync();

      Console.WriteLine("*** Listening on port {0}:{2} started. Press ENTER to shutdown server. ***\n", programDomain._server.Ip.ToString(), ":", programDomain._server.Port.ToString());

      Console.ReadLine();

      programDomain.DisconnectServer();
    }

    private void DisconnectServer()
    {
      _server.Close();
      _listenerThread.CancelAsync();
      _listenerThread.Dispose();
      GC.Collect();
    }
  }
}
