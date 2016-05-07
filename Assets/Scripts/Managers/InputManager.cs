// Responsible for handling input strings from the socket

using UnityEngine;
using TCP;
using System.Collections;
using System;

namespace CompleteProject
{
    //Extend the Listener class from the DLL
    public class InputManager : MonoBehaviour, Listener
    {

        // Use this for initialization
        // Note that the components of this script need to be attached within Unity
        public testLib tcp;
        public OutputManager outputManager;
        public PlayerHealth playerHealth;
        public PlayerMovement playerMovement;
        public EnemyHealth enemyHealth;
        public EnemyMovement enemyMovement;
        public PlayerShooting playerShooting;
        public EnemyAttack enemyAttack;
        public EnemyManager enemyManager;

        void Awake()
        {
            // Find the objects in the game with the given name and reference the script component needed
            outputManager = GameObject.Find("TCP").GetComponent<OutputManager>();
            playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
            playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
            enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
            playerShooting = GameObject.Find("GunBarrelEnd").GetComponent<PlayerShooting>();

            // References to the TCP socket
            tcp = outputManager.tcpReturn();
            tcp.registerListener(this);
        }

        public void apply(string action)
        {
            // Get input from the server in the form "method value"
            // For example : "PH 5" or "PS -1"

            // Method code
            string[] method = action.Split(' ');
            Debug.Log("method: " + method[0] + ", value: " + method[1]);
            // Value for method argument
            double val = Double.Parse(method[1]);

            // Logic for separating out the method strings and calling 
            // the given method with the value as an argument
            string caseSwitch = method[0];
            if (caseSwitch.Contains("PH"))
                playerHealth.changePHealth((int)val);
            else if (caseSwitch.Contains("PS"))
                playerMovement.changePSpeed((float)val);
            else if (caseSwitch.Contains("ESR"))
                enemyManager.changeESpawnRate((float)val);
            else if (caseSwitch.Contains("PD"))
                playerShooting.changePDamage((int)val);
            else if (caseSwitch.Contains("ES"))
                enemyManager.changeESpeed((float)val);

        }
    }
}