using System;

namespace Common
{
  [Serializable]
  public class ProfileContainer : IData
  {
    private readonly string _user;
    private readonly string _password;
    private bool _connected;
    private DateTime _dateJoined;
    private DateTime _lastConnected;

    public ProfileContainer(string user, string password)
    {
      _user = user;
      _password = password;
      _dateJoined = DateTime.Now;
      _lastConnected = DateTime.Now;
    }

    public string UserName
    {
      get { return _user; }
    }

    public string Password
    {
      get { return _password; }
    }

    public bool Connected
    {
      get { return _connected; }
      set { _connected = value; }
    }
    public DateTime DateJoined
    {
      get { return _dateJoined; }
    }
    public DateTime LastConnected
    {
      get { return _lastConnected; }
      set { _lastConnected = value; }
    }
  }
}
