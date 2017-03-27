using System;

namespace Common
{
  [Serializable]
  public class Profil : IData
  {
    private readonly string _user;
    private readonly string _password;
    private readonly bool _newUser;
    private bool _connected;

    public Profil(string user, string password, bool newUser)
    {
      _user = user;
      _password = password;
      _newUser = newUser;
    }

    public string UserName
    {
      get { return _user; }
    }

    public string Password
    {
      get { return _password; }
    }

    public bool NewUser
    {
      get { return _newUser; }
    }

    public bool Connected
    {
      get { return _connected; }
      set { _connected = value; }
    }
  }
}
