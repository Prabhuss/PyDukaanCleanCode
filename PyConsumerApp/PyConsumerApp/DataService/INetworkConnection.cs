using System;
using System.Collections.Generic;
using System.Text;

namespace PyConsumerApp.DataService
{
    public interface INetworkConnection
    {
        bool IsConnected { get; }
        void CheckNetworkConnection();
    }
}
