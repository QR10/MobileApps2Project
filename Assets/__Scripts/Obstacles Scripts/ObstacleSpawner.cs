using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    // Variables
    private float waitSpawnMin = 1.5f;
    private float waitSpawnMax = 4.5f;

    [SerializeField] private GameObject[] obstacles;

    private List<GameObject> obstaclesForSpawning = new List<GameObject> ();

    void Awake()
    {
        InitializeObstacles();
    }

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(SpawnRandomObstacle());
    }


    private void Update()
    {
        SpeedUpSpawn();
    }

    // Insert obstacles into game objects array
    void InitializeObstacles()
    {
        int index = 0;

        // Adding each element 6 times to the list
        for(int i = 0; i < obstacles.Length * 6; i++)
        {
            // Creating a game object on the index position
            GameObject obj = Instantiate(obstacles[index], new Vector3(transform.position.x, transform.position.y, 1), Quaternion.identity) as GameObject;
            // Added to the obstacles for spawning list
            obstaclesForSpawning.Add(obj);
            // Seting object to not active
            obstaclesForSpawning[i].SetActive(false);
            index++;

            // If index is auto of bounds, reset it to 0
            if (index == obstacles.Length)
                index = 0;
        }
    }


    // Shuffle the list of objects
    void Shuffle()
    {
        for(int i = 0; i < obstaclesForSpawning.Count; i++)
        {
            // Creating a temporary game object
            GameObject temp = obstaclesForSpawning[i];
            // Generating a random index
            int random = Random.Range(i, obstaclesForSpawning.Count);
            // Using the random index to shuffle the objects positions
            obstaclesForSpawning[i] = obstaclesForSpawning[random];
            obstaclesForSpawning[random] = temp;
        }
    }
    
    // Creating a coroutine to spawn obstacles
    IEnumerator SpawnRandomObstacle()
    {
        yield return new WaitForSeconds(Random.Range(waitSpawnMin, waitSpawnMax));

        // Creating a random index
        int index = Random.Range(0, obstaclesForSpawning.Count);

        while (true)
        {
            // Search for an object that is not active in the hierarchy
            if(!obstaclesForSpawning[index].activeInHierarchy)
            {
                // Set the object to active and break out of the loop
                obstaclesForSpawning[index].SetActive(true);
                // Set the object position to the spawner position
                obstaclesForSpawning[index].transform.position = new Vector3(transform.position.x, transform.position.y, 1);
                break;
            }
            // Reset the index to search for another object that is not active
            else
            {
                index = Random.Range(0, obstaclesForSpawning.Count);
            }
        }

        // Start the coroutine to spawn the object
        StartCoroutine (SpawnRandomObstacle());
    }

    // Reduce the wait time range for spawning objects
    void SpeedUpSpawn()
    {
        if (waitSpawnMax <= waitSpawnMin)
            waitSpawnMax = waitSpawnMin;
        else
            waitSpawnMax -= 0.1f;
    }

} // ObstacleSpawner
