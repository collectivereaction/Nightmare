using UnityEngine;
using TCP;
using System.Collections;

namespace CompleteProject
{

    public class OutputManager : MonoBehaviour
    {
        public testLib tcp = new testLib();

        // Use this for initialization
        void Awake()
        {
            tcp.StartClient();

        }

        public testLib tcpReturn()
        {
            return tcp;
        }

    }
}