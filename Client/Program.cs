using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Client
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    public static void Main(string[] args)
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      var serverNameOrAddress = "127.0.0.1";
      int serverPort = 11000;
      if ((args.Length > 0) && !string.IsNullOrEmpty(args[0]))
      {
        serverNameOrAddress = args[0];
      }
      if ((args.Length > 1) && !string.IsNullOrEmpty(args[1]))
      {
        serverPort = Int32.Parse(args[1]);
      }

      Application.Run(new MainFrm(serverNameOrAddress, serverPort));
    }
  }
}