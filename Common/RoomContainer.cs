using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
  [Serializable]
  public class RoomContainer : IData
  {
    private string _roomName;
    private string _roomDescription;

    #region Constructors

    public RoomContainer(string name)
      :this(name, "")
    {
    }

    public RoomContainer(string roomName, string roomDescription)
    {
      _roomName = roomName;
      _roomDescription = roomDescription;
    }

    #endregion

    #region Properties

    public string Name
    {
      get { return _roomName; }
      set { _roomName = value; }
    }

    public string Description
    {
      get { return _roomDescription; }
      set { _roomDescription = value; }
    }

    #endregion
  }
}
