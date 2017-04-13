using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Common;

namespace ServerManagement
{
  public class UsersManager : IUsersManager
  {
    private readonly IList<ProfileContainer> _profiles;
    private const string _fileName = "profiles.bin";

    #region Constructor

    public UsersManager()
    {
      _profiles = new List<ProfileContainer>();
      
      var size = Marshal.SizeOf(typeof(ProfileContainer));
      using (FileStream file = new FileStream(_fileName, FileMode.Open, FileAccess.Read))
      {
        while (file.Position != file.Length)
        {
          var buffer = new byte[size];
          file.Read(buffer, (int)file.Position, size);
          _profiles.Add((ProfileContainer)SerializerManager.Deserialize(buffer));
        }
      }
    }

    #endregion

    #region IUsersManager implementation

    public RegistrationStatus RegisterNewUser(ProfileContainer newProfile)
    {
      var registrationStatus = RegistrationStatus.Successful;
      var size = Marshal.SizeOf(typeof(ProfileContainer));

      if (_profiles.Any(profile => profile.UserName.Equals(newProfile.UserName)))
      {
        registrationStatus = RegistrationStatus.AlreadyRegistred;
      }
      if (registrationStatus != RegistrationStatus.AlreadyRegistred)
      {
        _profiles.Add(newProfile);
        using (FileStream file = new FileStream(_fileName, FileMode.Open, FileAccess.Write))
        {
          file.Write(SerializerManager.Serialize(newProfile), (int)file.Position, size);
        }
      }

      return registrationStatus;
    }

    public RegistrationStatus UpdateUserStatus(string userId, bool connectionStatus)
    {
      throw new NotImplementedException();
    }

    public bool IsRegistredUser(string userId)
    {
      throw new NotImplementedException();
    }

    public UsersStatusContainer RegistredUsers { get; private set; }

    #endregion
  }
}
