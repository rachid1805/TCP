using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
  public class RoomsContainer : IData
  {
    private IList<RoomContainer> _rooms;

    #region Constructor

    public RoomsContainer()
    {
      _rooms = new List<RoomContainer>();
    }

    #endregion

    #region Public

    public bool AddRoom(RoomContainer room)
    {
      foreach (RoomContainer theRoom in _rooms)
      {
        if (theRoom.Name.Equals(room.Name))
        {
          return false;
        }
      }
      _rooms.Add(room);

      return true;
    }

    public bool RemoveRoom(RoomContainer room)
    {
      foreach (RoomContainer theRoom in _rooms)
      {
        if (theRoom.Name.Equals(room.Name))
        {
          _rooms.Remove(room);
          return true;
        }
      }

      return false;
    }

    #endregion
  }
}
