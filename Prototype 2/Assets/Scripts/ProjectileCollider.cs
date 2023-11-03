using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileCollider : MonoBehaviour
{
    private ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Animal"))
        {
            other.gameObject.GetComponent<AnimalHunger>().FeedAnimal(1);           
            Destroy(gameObject);
        }
          
    }
  
}
