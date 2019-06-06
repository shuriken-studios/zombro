using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject Lee;
    public GameObject Chris;
    public GameObject John;
    public float xOffset = 0;
    public float yOffset = 0;
    public float zOffset = 0;

    void LateUpdate()
    {
        if (LeeController.leeActive)
        {
            this.transform.position = new Vector3(Lee.transform.position.x + xOffset,
                                                  Lee.transform.position.y + yOffset,
                                                  Lee.transform.position.z + zOffset);
        }

        if (ChrisController.chrisActive)
        {
            this.transform.position = new Vector3(Chris.transform.position.x + xOffset,
                                      Chris.transform.position.y + yOffset,
                                      Chris.transform.position.z + zOffset);
        }

        if (JohnController.johnActive)
        {
            this.transform.position = new Vector3(John.transform.position.x + xOffset,
                                      John.transform.position.y + yOffset,
                                      John.transform.position.z + zOffset);
        }
    }
}