using System;

namespace Common
{
  [Serializable]
  public class ProfileContainer : IData
  {
    private readonly string _user;
    private readonly string _password;
    private bool _connected;

    public ProfileContainer(string user, string password)
    {
      _user = user;
      _password = password;
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
  }
}
