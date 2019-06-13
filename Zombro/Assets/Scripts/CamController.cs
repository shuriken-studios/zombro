using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public GameObject Lee;
    public GameObject Chris;
    public GameObject John;
    public float cameraWidth;
    public float cameraHeight;

    // LateUpdate is called after Update each frame
    void Update()
    {
        if (LeeController.leeActive)
        {
            Vector3 pos = Lee.transform.position;
            pos.y += cameraHeight;
            pos.z += cameraWidth;
            transform.position = pos;
        }

        if (ChrisController.chrisActive)
        {
            Vector3 pos = Chris.transform.position;
            pos.y += cameraHeight;
            pos.z += cameraWidth;
            transform.position = pos;
        }
        
        if (JohnController.johnActive)
        {
            Vector3 pos = John.transform.position;
            pos.y += cameraHeight;
            pos.z = cameraWidth;
            transform.position = pos;
        }
    }
}
