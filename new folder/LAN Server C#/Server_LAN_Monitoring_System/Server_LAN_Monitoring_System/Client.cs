using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace Server_LAN_Monitoring_System
{
    class Client
    {
        internal string ipaddress;
        internal int connected_port;
        internal Socket socket;
        internal TcpListener tcpListener;
        internal bool isConnected;
        
        public Client(String ipaddress,int connected_port,Socket socket,TcpListener tcpListener,bool isConnected)
        {
            this.ipaddress = ipaddress;
            this.socket = socket;
            this.connected_port = connected_port;
            this.tcpListener = tcpListener;
            this.isConnected = isConnected ;
        }

        public Client()
        {

        }
        
    }


   


}
