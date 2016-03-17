using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace TCP
{
    public interface Listener
    {
        void apply(byte[] action);
    }

    public class testLib
    {
        string time;

        // Create a TCP/IP  socket.
        static Socket sender;
        static Listener actionListener;
        static byte[] bytes = new byte[1024];

        public testLib() { }

        public void StartClient()
        {
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 7777);

            sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                try
                {
                    sender.Connect(remoteEP);
                    var th = new Thread(ListenFromServer);
                    th.Start();
                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static void ListenFromServer()
        {
            while (true)
            {
                int bytesRec = sender.Receive(bytes);
                actionListener.apply(bytes);
            }
        }

        public void sendData(String gameEvent)
        {
            time = (ToUnixTime()).ToString();
            byte[] msg = Encoding.ASCII.GetBytes(time + "," + gameEvent + "\r");

            sender.Send(msg);
        }

        // convert datetime to unix epoch seconds
        public static long ToUnixTime()
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return Convert.ToInt64((DateTime.Now.ToUniversalTime() - epoch).TotalMilliseconds);
        }

        public void registerListener(Listener listener)
        {
            actionListener = listener;
            return;
        }
    }
    
}
