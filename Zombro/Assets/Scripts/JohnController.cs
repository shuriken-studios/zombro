using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnController : MonoBehaviour
{
    public float speed;
    public GameObject johnHighlighter;
    public Camera johnCam;
    public static bool johnActive;

    void Start()
    {
        johnActive = false; //John is not active when the scene begins.
    }

    void Update()
    {
            JohnMovement();

        if (Input.GetKeyDown(KeyCode.Alpha1)) //Player switches to Lee.
        {
            johnActive = false;
            LeeController.leeActive = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) //Player switches to Chris
        {
            johnActive = false;
            ChrisController.chrisActive = true;
        }

    }

    void JohnMovement()
    {
        if (johnActive)
        {
            johnCam.enabled = true; //Chris's camera is activated. 

            float hor = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");

            Vector3 johnMovement = new Vector3(hor, 0, ver);
            johnMovement = Vector3.ClampMagnitude(johnMovement, 1) * speed * Time.deltaTime;
            transform.Translate(johnMovement, Space.Self);

            johnHighlighter.SetActive(true); //John is the highlighted character since he is being controlled by the player.
        }

        if (!johnActive)
        {
            johnCam.enabled = false; //John's camera is deactivated.
            johnHighlighter.SetActive(false); //John is not the highlighted character.
        }
    }
}
