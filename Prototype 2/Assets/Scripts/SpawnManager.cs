using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabsTop;
    public GameObject[] animalPrefabsHorizontal;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnAnimal", 1f, 2f);
        InvokeRepeating("SpawnAnimalHorizontal", 2f, 4f);
    }
   
    // Animal Spawn Methods
    void SpawnAnimal()
    {
        int randomAnimalIndex = Random.Range(0, 3);
        int randomAnimalTopPos = Random.Range(-17, 17);

        Instantiate(animalPrefabsTop[randomAnimalIndex], new Vector3(randomAnimalTopPos, 0, 12), Quaternion.Euler(0,180,0));
      
    }
    void SpawnAnimalHorizontal()
    {
        int randomAnimalIndexLeft = Random.Range(0, 3);
        int randomAnimalIndexRight = Random.Range(0, 3);
        int randomAnimalHorPos = Random.Range(-5, 5);

        Instantiate(animalPrefabsHorizontal[randomAnimalIndexLeft], new Vector3(-22, 0, randomAnimalHorPos), Quaternion.Euler(0, 90, 0));
        Instantiate(animalPrefabsHorizontal[randomAnimalIndexRight], new Vector3(22, 0, randomAnimalHorPos), Quaternion.Euler(0, -90, 0));
    }
}
