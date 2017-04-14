using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
  /// <summary>
  /// Shynchronization time in ms
  /// </summary>
  public enum Definitions
  {
    SYNCHRONIZATION_TIME = 15000
  }

  /// <summary>
  /// The type of commands that you can sent to the server.(Note : These are just some comman types.You should do the desired actions when a command received to the client yourself.)
  /// </summary>
  public enum CommandType
  {
    /// <summary>
    /// Send a text message to the server
    /// </summary>
    Message,
    /// <summary>
    /// A registration of a new client
    /// </summary>
    ClientSignUp,
    /// <summary>
    /// A client login in the server
    /// </summary>
    ClientLogIn,
    /// <summary>
    /// A client logoff from the server
    /// </summary>
    ClientLogOff,
    
    IsNameExists,
    
    UserAlreadyExists,

    InvalidCredentials,

    ValidCredentials,

    CreateRoom,

    ConnectToRoom,

    /// <summary>
    /// To get a list of current connected clients to the server,Send this type of command to it.The server will replay to you one same command for each client with the metadata in this format : "ClientIP:ClientNetworkName".
    /// </summary>
    SendClientList,
    /// <summary>
    /// This is a free command that you can sent to the server.
    /// </summary>
    FreeCommand
  }
}
