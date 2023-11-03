using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontCameraController : MonoBehaviour
{
    // Camera position when game start
    public Vector3 offset = new Vector3(0, 2, 1);
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Camera track player and rotate when player turn
        transform.position = player.transform.position + offset;
        transform.rotation = player.transform.rotation;
    }
}
