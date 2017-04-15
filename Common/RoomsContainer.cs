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

    public bool AddRoom(RoomUsersContainer room)
    {
      foreach (RoomUsersContainer theRoom in _rooms)
      {
        if (theRoom.getRoom().Name.Equals(room.getRoom().Name))
        {
          return false;
        }
      }
      _rooms.Add(room);

      return true;
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
    //Update users' list for a room
    public bool UpdateRoom(RoomUsersContainer room)
    {
        //to be implemented
        return false;
    }

    public IList<RoomUsersContainer> getAllRooms()
    {
        return _rooms;
    }
        #endregion
    }
}
