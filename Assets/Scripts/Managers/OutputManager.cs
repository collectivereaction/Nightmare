// Responsible for sending game states to be sent through the socket

using UnityEngine;
using TCP;
using System.Collections;

namespace CompleteProject
{
    public class OutputManager : MonoBehaviour
    {
        //Create socket library instance
        public testLib tcp = new testLib();

        // Use this for initialization
        void Awake()
        {
            //Create socket and start the client
            tcp.StartClient();
        }

        //Return instance of socket library
        public testLib tcpReturn()
        {
            return tcp;
        }

    }
}