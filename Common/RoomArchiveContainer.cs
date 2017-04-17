using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
  [Serializable]
  public class RoomArchiveContainer : IData
  {
    private RoomContainer _room;
    private IList<MessageContainer> _archive;

    #region Constructor

    public RoomArchiveContainer(RoomContainer room)
    {
      _room = room;
      _archive = new List<MessageContainer>();
    }

    #endregion

    #region Public

    public void AddMessage(MessageContainer message)
    {
      if (message.Room.Name.Equals(_room.Name))
      {
        _archive.Add(message);
      }
      else
      {
        throw new InvalidOperationException(string.Format("Invalid room message ({0}) insertion in this room {1}", message.Room.Name, _room.Name));
      }
    }

    public bool RemoveMessage(MessageContainer message)
    {
      int indexToRemove = 0;

      for (var index = 0; index < _archive.Count; index++)
      {
        if (_archive[index].Msg.Equals(message.Msg))
        {
          indexToRemove = index;
          break;
        }
      }

      if (indexToRemove != 0)
      {
        _archive.RemoveAt(indexToRemove);
        return true;
      }
      return false;
    }

    public RoomContainer GetRoom()
    {
      return _room;
    }
    public IList<MessageContainer> GetMessagesList()
    {
      return _archive;
    }


    #endregion
  }
}
