using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 20f;
    private PlayerController playerController;
    private float leftBound = -15f;
   
    // Start is called before the first frame update
    void Start()
    {
    
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    { 
        if(playerController.gameOver == false && playerController.gameStart == true)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 35;
        }
        else
        {
            speed = 20;
        }
    }
}
