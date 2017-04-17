using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerManagement
{
  class MessagesContainer
  {
    private readonly List<RoomArchiveContainer> _roomsArchive;

    public MessagesContainer()
    {
      _roomsArchive = new List<RoomArchiveContainer>();
    }

    public bool RoomExists(RoomArchiveContainer room)
    {
      return _roomsArchive.Contains(room);
    }

    public bool AddRoomArchive(RoomArchiveContainer room)
    {
      if (!RoomExists(room))
      {
        _roomsArchive.Add(room);
        return true;
      }
      else
      {
        return false;
      }
    }

    public bool RemoveRoomArchive(RoomArchiveContainer room)
    {
      if (RoomExists(room))
      {
        _roomsArchive.Remove(room);
        return true;
      }
      else
      {
        return false;
      }
    }

    public bool AddNewMessage(MessageContainer message)
    {
      foreach (RoomArchiveContainer roomArchive in _roomsArchive)
      {
        if (roomArchive.GetRoom().Name.Equals(message.Room.Name))
        {
          roomArchive.AddMessage(message);
          return true;
        }
      }
      return false;
    }

    public bool RemoveMessage(MessageContainer message)
    {
      foreach (RoomArchiveContainer roomArchive in _roomsArchive)
      {
        if (roomArchive.GetRoom().Name.Equals(message.Room.Name))
        {
          if (roomArchive.RemoveMessage(message))
          {
            return true;
          }
        }
      }
      return false;
    }

    public bool LikeMessage(MessageContainer message)
    {
      foreach (RoomArchiveContainer roomArchive in _roomsArchive)
      {
        if (roomArchive.GetRoom().Name.Equals(message.Room.Name))
        {
          if (roomArchive.LikeMessage(message))
          {
            return true;
          }
        }
      }
      return false;
    }

    public RoomArchiveContainer GetRoomArchive(RoomContainer room)
    {
      foreach (RoomArchiveContainer roomArchive in _roomsArchive)
      {
        if (roomArchive.GetRoom().Name.Equals(room.Name))
        {
          return roomArchive;
        }
      }
      return null;
    }
  }
}
