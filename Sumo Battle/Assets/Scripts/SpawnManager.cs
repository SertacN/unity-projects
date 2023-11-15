using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject bossPrefab;
    public GameObject powerup;
    private int enemyCount;
    private int waveNumber = 1;
   
    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount == 0 && waveNumber % 3 == 0)
        {
            SpawnBoss(waveNumber);
            SpawnPowerup();
            waveNumber++;
        }
        else if(enemyCount == 0)
        {
            SpawnEnemyWave(waveNumber);
            SpawnPowerup();
            waveNumber++;  
        }
       
    }
 
    void SpawnEnemyWave(int waveNumber)
    {
        for(int i =0; i < waveNumber; i++)
        {
            int randomIndex = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[randomIndex], GenerateSpawnPosition(), gameObject.transform.rotation);
            if (waveNumber % 3 == 0)
            {
                Instantiate(bossPrefab, GenerateSpawnPosition(), gameObject.transform.rotation);
            }
        } 
    }
    void SpawnBoss(int waveNumber)
    {
        Instantiate(bossPrefab, GenerateSpawnPosition(), gameObject.transform.rotation);
    }
    void SpawnPowerup()
    {
        Instantiate(powerup, GenerateSpawnPosition(), gameObject.transform.rotation);
    }
    Vector3 GenerateSpawnPosition()
    {
        float spawnRange = 8f;
        float randomX = Random.Range(-spawnRange, spawnRange);
        float randomZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomSpawnPos = new Vector3(randomX, 0, randomZ);
        return randomSpawnPos;
    }
}
