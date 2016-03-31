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
            string caseSwitch = str;

            if (str.Contains("PH-"))
                playerHealth.negPHealth();
            else if (str.Contains("PH+"))
                playerHealth.posPHealth();
            else if (str.Contains("PS+"))
                playerMovement.posPSpeed();
            else if (str.Contains("PS-"))
                playerMovement.negPSpeed();
            else if (str.Contains("PD+"))
                playerShooting.posPDamage();
            else if (str.Contains("PD-"))
                playerShooting.negPDamage();
            else if (str.Contains("ED+"))
                enemyAttack.posEDamage();
            else if (str.Contains("ED-"))
                enemyAttack.negEDamage();
            else if (str.Contains("EH+"))
                enemyHealth.posEHealth();
            else if (str.Contains("EH-"))
                enemyHealth.negEHealth();


            //switch (caseSwitch)
            //{
            //    case "PH+":
            //        playerHealth.posPHealth();
            //        break;
            //    case "PH-":
            //        playerHealth.negPHealth();
            //        break;
            //    case "PS+":
            //        Debug.Log("Player Speed!!!!!!!!!!!!!!");
            //        playerMovement.posPSpeed();
            //        break;
            //    case "PS-":
            //        playerMovement.negPSpeed();
            //        break;
            //    case "PD+":
            //        playerShooting.posPDamage();
            //        break;
            //    case "PD-":
            //        playerShooting.negPDamage();
            //        break;
            //    case "EH+":
            //        enemyHealth.posEHealth();
            //        break;
            //    case "EH-":
            //        enemyHealth.negEHealth();
            //        break;
            //    //case "ES+":
            //    //    playerHealth.negPHealth();
            //    //    break;
            //    //case "ES-":
            //    //    playerHealth.negPHealth();
            //    //    break;
            //    case "ED+":
            //        enemyAttack.posEDamage();
            //        break;
            //    case "ED-":
            //        enemyAttack.negEDamage();
            //        break;
            //    default:
            //        Debug.Log("DEFAULT!!!");
            //        break;
            //}
            //;
        }
    }
}