using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthClamper : MonoBehaviour
{

    public Image Health;
    public Camera mainCam;

    // Update is called once per frame
    void Update()
    {
        Vector3 healthPos = mainCam.WorldToScreenPoint(this.transform.position);
        Health.transform.position = healthPos;
    }
}
