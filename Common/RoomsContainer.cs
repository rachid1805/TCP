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
        if (theRoom.getRoom().Name.Equals(room.getRoom().Name))
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
        if (theRoom.getRoom().Name.Equals(room.getRoom().Name))
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
        if (theRoom.getRoom().Name.Equals(room.getRoom().Name))
        {
          foreach (string user in room.getRoomUsersList())
          {
            theRoom.AddUser(user);
          }
          return true;
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
