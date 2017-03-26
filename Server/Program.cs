using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server
{
  class Program
  {
    private Server _server;

    public static void Main(string[] args)
    {
      Program programDomain = new Program();
      programDomain._server = new Server();

      var hostNameOrAddress = "127.0.0.1";
      int port = 11000;
      if ((args.Length > 0) && !string.IsNullOrEmpty(args[0]))
      {
        hostNameOrAddress = args[0];
      }
      if ((args.Length > 1) && !string.IsNullOrEmpty(args[1]))
      {
        port = Int32.Parse(args[1]);
      }
      programDomain._server.StartListening(hostNameOrAddress, port);
    }
  }
}
