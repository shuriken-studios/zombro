using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public GameObject Lee;
    public GameObject Chris;
    public GameObject John;

    private Vector3 offset;            //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start()
    {
        if (LeeController.leeActive)
        {
            //Calculate and store the offset value by getting the distance between the player's position and camera's position.
            offset = transform.position - Lee.transform.position;
        }

        if (ChrisController.chrisActive)
        {
            offset = transform.position - Chris.transform.position;
        }

        if (JohnController.johnActive)
        {
            offset = transform.position - John.transform.position;
        }
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        if (LeeController.leeActive)
        {
            // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
            transform.position = Lee.transform.position + offset;
        }

        if (ChrisController.chrisActive)
        {
            transform.position = Chris.transform.position + offset;
        }
        
        if (JohnController.johnActive)
        {
            transform.position = John.transform.position + offset;
        }
    }
}
