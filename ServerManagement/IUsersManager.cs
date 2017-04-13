using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerManagement
{
  public enum RegistrationStatus
  {
    Successful,
    AlreadyRegistred,
    InvalidCredentials
  }

  /// <summary>
  /// The users management interface
  /// </summary>
  public interface IUsersManager
  {
    /// <summary>
    /// Register a new user to the server and save the user list in the disk
    /// </summary>
    RegistrationStatus RegisterNewUser(ProfileContainer newProfile);

    /// <summary>
    /// Connected/Disconnected user
    /// </summary>
    RegistrationStatus UpdateUserStatus(string userId, bool connectionStatus);

    /// <summary>
    /// Return true if the specified user is already registred in the server
    /// </summary>
    bool IsRegistredUser(string userId);

    /// <summary>
    /// Return all registred users and their status (connected or not)
    /// </summary>
    UsersStatusContainer RegistredUsers { get; }
  }
}
