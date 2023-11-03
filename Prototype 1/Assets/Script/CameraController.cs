using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Added all cameras with gameobject
    public GameObject mainCamera;
    public GameObject targetCamera;
    public GameObject playerTwoMain;
    public GameObject playerTwoTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Player 1 camera settings
        if (Input.GetButtonDown("Switch1")) 
        {
            mainCamera.SetActive(true);
            targetCamera.SetActive(false);
        }
        if (Input.GetButtonDown("Switch2"))
        {
            mainCamera.SetActive(false);
            targetCamera.SetActive(true);
        }
        // Player 2 camera settings
        if (Input.GetButtonDown("Switch3"))
        {
            playerTwoMain.SetActive(true);
            playerTwoTarget.SetActive(false);
        }
        if (Input.GetButtonDown("Switch4"))
        {
            playerTwoMain.SetActive(false);
            playerTwoTarget.SetActive(true);
        }
    }
}
