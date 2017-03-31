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

    public MessageContainer(string userName, RoomContainer room, string msg, int msgId)
    {
      User = userName;
      Room = room;
      Msg = msg;
      MsgId = msgId;
    }

    #endregion

    #region Properties

    public string User { get; set; }
    public RoomContainer Room { get; set; }
    public string Msg { get; set; }
    public int MsgId { get; set; }

    #endregion

    #region Object

    public override bool Equals(object obj)
    {
      // TODO
      return base.Equals(obj);
    }

    #endregion
  }
}
