using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Common;

namespace ServerManagement
{
  public class UsersManager : IUsersManager
  {
    private readonly List<ProfileContainer> _profiles;
    private const string _fileName = "profiles.bin";

    #region Constructor

    public UsersManager()
    {
      _profiles = new List<ProfileContainer>();

      if (File.Exists(_fileName))
      {
        using (Stream stream = File.Open(_fileName, FileMode.Open))
        {
          var binaryFormatter = new BinaryFormatter();
          _profiles = (List<ProfileContainer>)binaryFormatter.Deserialize(stream);
        }
      }

      // Make sure all users are disconnected at startup
      foreach (ProfileContainer profile in _profiles)
      {
        profile.Connected = false;
      }
    }

    #endregion

    #region IUsersManager implementation

    public RegistrationStatus RegisterNewUser(ProfileContainer newProfile)
    {
      var registrationStatus = RegistrationStatus.Successful;

      if (_profiles.Any(profile => profile.UserName.Equals(newProfile.UserName)))
      {
        registrationStatus = RegistrationStatus.AlreadyRegistred;
      }
      if (registrationStatus != RegistrationStatus.AlreadyRegistred)
      {
        newProfile.Connected = true;
        _profiles.Add(newProfile);
        using (Stream stream = File.Open(_fileName, FileMode.Create))
        {
          var binaryFormatter = new BinaryFormatter();
          binaryFormatter.Serialize(stream, _profiles);
        }
      }

      return registrationStatus;
    }

    public RegistrationStatus UpdateUserStatus(string userId, bool connectionStatus)
    {
      foreach (ProfileContainer profile in _profiles)
      {
        if (profile.UserName.Equals(userId))
        {
          profile.Connected = connectionStatus;

          return RegistrationStatus.Successful;
        }
      }

      return RegistrationStatus.InvalidCredentials;
    }

    public bool IsRegistredUser(string userId, string password)
    {
      foreach (ProfileContainer profile in _profiles)
      {
        if (profile.UserName.Equals(userId) && profile.Password.Equals(password))
        {
          return true;
        }
      }

      return false;
    }

    public bool IsConnectedUser(string userId)
    {
      foreach (ProfileContainer profile in _profiles)
      {
        if (profile.UserName.Equals(userId) && profile.Connected)
        {
          return true;
        }
      }

      return false;
    }

    public UsersStatusContainer RegistredUsers
    {
      get
      {
        var clientsStatus = new Dictionary<string, bool>();

        foreach (ProfileContainer profile in _profiles)
        {
          clientsStatus.Add(profile.UserName, profile.Connected);
        }

        return new UsersStatusContainer(clientsStatus);
      }
    }

    public ProfileContainer GetUserProfile(string userId)
    {
      foreach (ProfileContainer profile in _profiles)
      {
        if (profile.UserName.Equals(userId) && profile.Connected)
        {
          return profile;
        }
      }

      return null;
    }

    #endregion
  }
}
