using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
  [Serializable]
  public class RoomContainer : IData
  {
    #region Constructors

    public RoomContainer(string name)
      :this(name, "")
    {
    }

    public RoomContainer(string name, string description)
    {
      Name = name;
      Description = description;
    }

    #endregion

    #region Properties

    public string Name { get; set; }
    public string Description { get; set; }

    #endregion
  }
}
