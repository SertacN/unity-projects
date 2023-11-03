using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float horizontalInput;
    public float verticalInput;
    private float horizontalBound = 19f;
    private float verticalBound = 8f;
    public GameObject projectileFood;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Player Movement
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);
        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput); 
        
        // Player bound
        if(transform.position.x < -horizontalBound)
        {
            transform.position = new Vector3(-horizontalBound, transform.position.y,transform.position.z);
        }else if(transform.position.x > horizontalBound)
        {
            transform.position = new Vector3(horizontalBound, transform.position.y, transform.position.z);
        }
        if(transform.position.z < -verticalBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y , -verticalBound);
        }else if(transform.position.z > verticalBound){
            transform.position = new Vector3(transform.position.x, transform.position.y, verticalBound);
        }

        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            Instantiate(projectileFood, new Vector3(transform.position.x,transform.position.y,transform.position.z + 1.5f), transform.rotation);
        }
    }
}
