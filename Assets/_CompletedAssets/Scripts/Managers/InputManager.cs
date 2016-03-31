using UnityEngine;
using TCP;
using System.Collections;
using System;

namespace CompleteProject
{
    public class InputManager : MonoBehaviour, Listener
    {

        // Use this for initialization
        public testLib tcp;
        public OutputManager outputManager;
        public PlayerHealth playerHealth;
        public PlayerMovement playerMovement;
        public EnemyHealth enemyHealth;
        public EnemyMovement enemyMovement;
        public PlayerShooting playerShooting;
        public EnemyAttack enemyAttack;

        void Awake()
        {
            outputManager = GameObject.Find("TCP").GetComponent<OutputManager>();
            playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
            playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
            tcp = outputManager.tcpReturn();
            tcp.registerListener(this);
        }

        public void apply(byte[] action)
        {
            // Get input from the server in the form "method value"
            var str = System.Text.Encoding.Default.GetString(action);
            Debug.Log(str);

            // Method code
            string[] method = str.Split(' ');
            Debug.Log("method: " + method[0] + ", value: " + method[1]);
            // Value for method argument
            double val = Double.Parse(method[1]);

            

            
            string caseSwitch = method[0];

            if (caseSwitch.Contains("PH"))
                playerHealth.changePHealth((int)val);
            else if (str.Contains("PS"))
                playerMovement.changePSpeed((float)val);
            //else if (str.Contains("PD"))
            //    playerShooting.posPDamage();
            //else if (str.Contains("ED"))
            //    enemyAttack.posEDamage();
            //else if (str.Contains("EH"))
            //    enemyHealth.posEHealth();
        }
    }
}