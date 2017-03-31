using System;

namespace Common
{
  /// <summary>
  /// A class that implements a command object.
  /// </summary>
  [Serializable]
  public class CommandContainer
  {
    #region Constructor

    public CommandContainer(CommandType type, IData data)
    {
      CommandType = type;
      Data = data;
    }

    #endregion

    #region Public Properties

    public CommandType CommandType { get; set; }

    public IData Data { get; set; }

    #endregion
  }
}
