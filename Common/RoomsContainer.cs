using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
  [Serializable]
  public class RoomsContainer : IData
  {
    private IList<RoomUsersContainer> _rooms;

    #region Constructor

    public RoomsContainer()
    {
      _rooms = new List<RoomUsersContainer>();
    }

        #endregion

    #region Public

    public bool RoomExist(RoomUsersContainer room)
    {
      foreach (RoomUsersContainer theRoom in _rooms)
      {
        if (theRoom.GetRoom().Name.Equals(room.GetRoom().Name))
        {
          return true;
        }
      }
      return false;
    }

    public void AddRoom(RoomUsersContainer room)
    {
      _rooms.Add(room);
      //return true;
    }

    public bool RemoveRoom(RoomUsersContainer room)
    {
      foreach (RoomUsersContainer theRoom in _rooms)
      {
        if (theRoom.GetRoom().Name.Equals(room.GetRoom().Name))
        {
          _rooms.Remove(theRoom);
          return true;
        }
      }

      return false;
    }
    //add check if user already in room
    public bool AddUsers(RoomUsersContainer room)
    {
      foreach (RoomUsersContainer theRoom in _rooms)
      {
        if (theRoom.GetRoom().Name.Equals(room.GetRoom().Name))
        {
          foreach (string user in room.GetRoomUsersList())
          {
            theRoom.AddUser(user);
          }
          return true;
        }
      }
      return false;
    }
    //Search if user is in a room and removes him
    public bool RemoveUser(string userRemove)
    {
      foreach (RoomUsersContainer theRoom in _rooms)
      {
        foreach (string user in theRoom.GetRoomUsersList())
        {
          if (userRemove.Equals(user))
          {
            theRoom.RemoveUser(user);
            return true;
          }
        }
      }
        return false;
    }
    //Search if user is in a specific room and removes him
    public bool RemoveUserFromRoom(RoomUsersContainer room)
    {
      foreach (RoomUsersContainer theRoom in _rooms)
      {
        if (theRoom.GetRoom().Name.Equals(room.GetRoom().Name))
          {
            foreach (string user in theRoom.GetRoomUsersList())
            {
              foreach (string userRemove in room.GetRoomUsersList())
              {
                if (userRemove.Equals(user))
                {
                  theRoom.RemoveUser(user);
                  return true;
                }
              }
            }
          }
       }
      return false;
    }
    public IList<RoomUsersContainer> GetAllRooms()
    {
      return _rooms;
    }

    #endregion
  }
}
