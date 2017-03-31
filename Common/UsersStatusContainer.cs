using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
  [Serializable]
  public class UsersStatusContainer : IData
  {
    // User name + connection status
    private readonly IDictionary<string, bool> _clientsStatus;

    public UsersStatusContainer(IDictionary<string, bool> clientsStatus)
    {
      _clientsStatus = clientsStatus;
    }

    public IDictionary<string, bool> ClientsStatus
    {
      get { return _clientsStatus; }
    }
  }
}
