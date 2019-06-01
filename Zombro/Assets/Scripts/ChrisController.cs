using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChrisController : MonoBehaviour
{
    public float speed;
    public GameObject chrisHighlighter;
    public Camera chrisCam;
    public static bool chrisActive;

    void Start()
    {
        chrisActive = false; //Chris is inactive when the scene begins.
    }

    void Update()
    {
            ChrisMovement();

        if (Input.GetKeyDown(KeyCode.Alpha1)) //Player switches to Lee
        {
            chrisActive = false;
            LeeController.leeActive = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) //Player switches to John
        {
            chrisActive = false;
            JohnController.johnActive = true;
        }
    }

    void ChrisMovement()
    {
        if (chrisActive)
        {
            chrisCam.enabled = true; //Chris's camera is activated. 

            float hor = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");

            Vector3 chrisMovement = new Vector3(hor, 0, ver);
            chrisMovement = Vector3.ClampMagnitude(chrisMovement, 1) * speed * Time.deltaTime;
            transform.Translate(chrisMovement, Space.Self);

            chrisHighlighter.SetActive(true); //Chris is the highlighted character since he is being controlled by the player.
        }
        if (!chrisActive)
        {
            chrisCam.enabled = false; //Chris's camera is deactivated.
            chrisHighlighter.SetActive(false); //Chris is not the highlighted character.
        }
    }
}