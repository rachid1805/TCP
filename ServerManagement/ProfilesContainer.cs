using System;
using System.Collections.Generic;
using Common;
using System.Linq;
using System.Text;

namespace ServerManagement
{
  [Serializable]
  public class ProfilesContainer
  {
    private IList<ProfileContainer> _profils;

    #region Constructor

    public ProfilesContainer()
    {
      _profils = new List<ProfileContainer>();
    }

    #endregion

    #region Public

    public bool AddProfile(ProfileContainer user)
    {
      var userAdded = false;

      if (!_profils.Contains(user))
      {
        _profils.Add(user);
        userAdded = true;
      }

      return userAdded;
    }

    public IList<ProfileContainer> Profiles
    {
      get { return _profils; }
    }

    #endregion
  }
}
