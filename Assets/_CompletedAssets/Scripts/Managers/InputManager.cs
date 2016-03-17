using UnityEngine;
using TCP;
using System.Collections;

namespace CompleteProject
{
    public class InputManager : MonoBehaviour, Listener
    {

        // Use this for initialization
        public testLib tcp;
        public OutputManager outputManager;
        public PlayerHealth playerHealth;

        void Awake()
        {
            outputManager = GameObject.Find("TCP").GetComponent<OutputManager>();
            playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
            tcp = outputManager.tcpReturn();
            Debug.Log("Made it here?");
            tcp.registerListener(this);
        }
        // Update is called once per frame
        void Update()
        {

        }

        public void apply(byte[] action)
        {
            var str = System.Text.Encoding.Default.GetString(action);
            Debug.Log(str);
            playerHealth.Barf();
        }
    }
}