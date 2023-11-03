using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    public float scale = 1.3f;
    //public float rotateSpeed = 5.0f;
    public float opacity = 1f;
    private float horizontalInput;
    private float verticalInput;
    public float horizontalBound = 5f;
    public float verticalBound = 13f;
    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        InvokeRepeating("ChangeColor", 0f,1f);
    }
    
    void Update()
    {
        //Cube Rotate;
        //transform.Rotate(rotateSpeed * Time.deltaTime, 0.0f, 0.0f);
        
        // Cube Scale
        transform.localScale = Vector3.one * scale;
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            scale++;
        }else if (Input.GetKeyUp(KeyCode.Space))
        {
            scale--;
        }

        //Cube Movement
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * 5.0f * Time.deltaTime * horizontalInput);
        transform.Translate(Vector3.left * 5.0f * Time.deltaTime * verticalInput);

        // X Axis Bound
        if(transform.position.x > horizontalBound)
        {
            transform.position = new Vector3(horizontalBound, transform.position.y,transform.position.z);
        }else if(transform.position.x < -verticalBound)
        {
            transform.position = new Vector3(-verticalBound, transform.position.y, transform.position.z);
        }
        // Z Axis Bound
        if(transform.position.z < -horizontalBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -horizontalBound);
        }else if(transform.position.z > 13)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 13);
        }
    }

    void ChangeColor()
    {
        Material material = Renderer.material;
        float randomRed = Random.Range(0.0f, 1.0f);
        float randomGreen = Random.Range(0.0f, 1.0f);
        float randomBlue = Random.Range(0.0f, 1.0f);
        material.color = new Color(randomRed, randomGreen, randomBlue, opacity);

        //Debug.Log(material.color);
    }
   
}
