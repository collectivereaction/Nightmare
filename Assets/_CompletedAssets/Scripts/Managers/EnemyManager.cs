using UnityEngine;
using TCP;

namespace CompleteProject
{
    public class EnemyManager : MonoBehaviour
    {
        public PlayerHealth playerHealth;       // Reference to the player's heatlh.
        public GameObject enemy;                // The enemy prefab to be spawned.
        public float spawnTime = 3f;            // How long between each spawn.
        public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
        public bool spawned = false;
        public int enemyCount = 0;

        WriteFile writer = new WriteFile();

        //Reference to OutputManager and testLib Library instances
        public OutputManager outputManager;
        public testLib tcp;

        void Start ()
        {
            //Get instance of OutputManager
            outputManager = GameObject.Find("TCP").GetComponent<OutputManager>();
            tcp = outputManager.tcpReturn();

            // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
            InvokeRepeating ("Spawn", spawnTime, spawnTime);
        }


        public void Spawn ()
        {
            // If the player has no health left...
            if(playerHealth.currentHealth <= 0f)
                // ... exit the function.
                return;

            // Find a random index between zero and one less than the number of spawn points.
            int spawnPointIndex = Random.Range (0, spawnPoints.Length);

            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

            //Send Enemy Spawned to socket
            tcp.sendData("Enemy Spawned");
        }
    }
}