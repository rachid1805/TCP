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
  /// The type of commands exchanged between the server and the clients
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
    /// A failure registration of an existing user name
    /// </summary>
    UserAlreadyExists,
    /// <summary>
    /// A client has entered a bad credentials
    /// </summary>
    InvalidCredentials,
    /// <summary>
    /// A client has entered a valid credentials
    /// </summary>
    ValidCredentials,
    /// <summary>
    /// A client requests the list of the status of all clients (connected or not to the chat system)
    /// </summary>
    RequestClientList,
    /// <summary>
    /// The server sends the list of the status of all clients (connected or not to the chat system)
    /// </summary>
    UsersConnectionStatus,
    /// <summary>
    /// A client requests the creation of a new discussion room
    /// </summary>
    CreateRoom,
    /// <summary>
    /// The server confirms the creation of the room
    /// </summary>
    RoomCreated,
    /// <summary>
    /// The specified room name already exists
    /// </summary>
    RoomAlreadyExists,
    /// <summary>
    /// The specified room name does not exists
    /// </summary>
    RoomDoesNotExists,
    /// <summary>
    /// A client requests the connection to an existing discussion room
    /// </summary>
    ConnectToRoom,
    /// <summary>
    /// Server confirmes the connection to the room
    /// </summary>
    UserConnectedToRoom,
    /// <summary>
    /// A client requests the list of all existing rooms
    /// </summary>
    RequestRoomList,
    /// <summary>
    /// The server sends the list of all existing rooms
    /// </summary>
    RoomList,
    /// <summary>
    /// A client requests the room archive
    /// </summary>
    RequestRoomArchive,
    /// <summary>
    /// The server sends the room archive
    /// </summary>
    RoomArchive
  }
}
