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
    void AddNewMessage(MessageContainer message);

    /// <summary>
    /// Remove a message from the server
    /// </summary>
    bool RemoveMessage(string userId, string roomId, int msgId);

    /// <summary>
    /// Return an archive of the specified room
    /// </summary>
    RoomArchiveContainer GetRoomArchive(RoomContainer room);
  }
}
