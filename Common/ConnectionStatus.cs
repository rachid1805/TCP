using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
  [Serializable]
  public class ConnectionStatus
  {
    private readonly IDictionary<string, bool> _clientsStatus;

    public ConnectionStatus(IDictionary<string, bool> clientsStatus)
    {
      _clientsStatus = clientsStatus;
    }

    public IDictionary<string, bool> ClientsStatus
    {
      get { return _clientsStatus; }
    }
  }
}
