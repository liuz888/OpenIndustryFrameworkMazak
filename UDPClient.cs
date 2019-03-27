using System;
using System.Net;
using System.Net.Sockets;

namespace Mazak
{

    public class DataStream
  {
        private String ipAddress { get; set; }
        private int port { get; set; }

    private UdpClient Client;
   
    public void Execute()
    {
      Client = new UdpClient(port);
      Client.BeginReceive(new AsyncCallback(gotBytes), null);
    }

        //CallBack
        private void gotBytes(IAsyncResult res)
        {

            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, port);

            byte[] received = Client.EndReceive(res, ref groupEP);

            Parse.Execute(received);

            Client.BeginReceive(new AsyncCallback(gotBytes), null);

        }
  }
}
