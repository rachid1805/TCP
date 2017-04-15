using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
  [Serializable]
  public class RoomUsersContainer : IData
  {
    private RoomContainer _room;
    private IList<string> _users;

    #region Constructor

    public RoomUsersContainer(RoomContainer room)
    {
      _room = room;
      _users = new List<string>();
    }

    #endregion

    #region Public

    public bool AddUser(string user)
    {
      var userAdded = false;

      if (!_users.Contains(user))
      {
        _users.Add(user);
        userAdded = true;
      }

      return userAdded;
    }

    public bool RemoveUser(string user)
    {
      var userRemoved = false;

      if (_users.Contains(user))
      {
        _users.Remove(user);
        userRemoved = true;
      }

      return userRemoved;
    }

    public IList<String> GetRoomUsersList()
    {
      return _users;
    }

    public RoomContainer GetRoom()
    {
      return _room;
    }

    #endregion
  }
}
