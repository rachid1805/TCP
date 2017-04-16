using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerManagement
{
  /// <summary>
  /// The messages management interface
  /// </summary>
  public interface IMessagesManager
  {
    /// <summary>
    /// Register a new message in the server memory
    /// </summary>
    bool AddNewMessage(MessageContainer message);

    /// <summary>
    /// Remove a message from the server
    /// </summary>
    bool RemoveMessage(MessageContainer message);

    /// <summary>
    /// Return an archive of the specified room
    /// </summary>
    RoomArchiveContainer GetRoomArchive(RoomContainer room);
  }
}
