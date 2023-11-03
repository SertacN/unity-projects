using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBond : MonoBehaviour
{
    private float verticalBound = 13f;
    private float horizontalBound = 28;
    private ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Vertical Object Destroy when out of bound
        if(transform.position.z > verticalBound || transform.position.z < -verticalBound)
        {
            // if animal out of vertical bound, player lose 1 healt
            if(transform.position.z < -verticalBound)
            {
                scoreManager.LoseLife(-1);
            }
            Destroy(gameObject);
        }
        // Horizontal object destroy when out of bound
        else if(transform.position.x < -horizontalBound || transform.position.x > horizontalBound)
        {
            Destroy(gameObject);
        }
    }
}
