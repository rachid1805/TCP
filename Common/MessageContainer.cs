using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
  [Serializable]
  public class MessageContainer : IData
  {
    #region Constructor

    public MessageContainer(string userName, RoomContainer room, string msg)
    {
      User = userName;
      Room = room;
      Msg = msg;
    }

    #endregion

    #region Properties

    public string User { get; set; }
    public RoomContainer Room { get; set; }
    public string Msg { get; set; }

    #endregion
  }
}
