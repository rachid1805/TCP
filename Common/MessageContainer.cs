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

    public MessageContainer(MessageContainer message)
    {
      User = message.User;
      Room = new RoomContainer(message.Room.Name, message.Room.Description);
      Msg = message.Msg;
      MsgId = message.MsgId;
      Likes = message.Likes;
    }

    #endregion

    #region Properties

    public string User { get; set; }
    public RoomContainer Room { get; set; }
    public string Msg { get; set; }
    public int MsgId { get; set; }
    public int Likes { get; private set; }

    #endregion

    #region Public

    public void AddLike()
    {
      Likes++;
    }

    #endregion
  }
}
