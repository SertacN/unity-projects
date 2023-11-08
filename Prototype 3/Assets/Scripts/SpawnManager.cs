using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public float startDelay = 1f;
    public float repeatRate = 1f;
    private Vector3 obstaclePosition = new Vector3(26, 0, 0);
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnBarrier", startDelay, repeatRate);
    }
    void SpawnBarrier()
    {
        if (playerController.gameOver == false && playerController.gameStart == true)
        {
            int randomIndex = Random.Range(0, obstaclePrefabs.Length);
            Instantiate(obstaclePrefabs[randomIndex], obstaclePosition, transform.rotation);
        }
        
    }
}
