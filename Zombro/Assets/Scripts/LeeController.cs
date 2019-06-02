using UnityEngine;
using System.Collections;

public class LeeController : MonoBehaviour
{
    public float speed;
    public GameObject leeHighlighter;
    public Camera leeCam;
    public static bool leeActive = true;

    void Start()
    {
        leeActive = true; //Lee is the first active character in the scene.
    }

    void Update()
    {
        LeeMovement();

        if (Input.GetKeyDown(KeyCode.Alpha2)) //Player switches to Chris
        {
            leeActive = false;
            ChrisController.chrisActive = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) //Player switches to John
        {
            leeActive = false;
            JohnController.johnActive = true;
        }
    }

    void LeeMovement()
    {
        if (leeActive)
        {
            leeCam.enabled = true; //Lee's camera is activated. 

            float hor = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");

            Vector3 leeMovement = new Vector3(hor, 0, ver);
            leeMovement = Vector3.ClampMagnitude(leeMovement, 1) * speed * Time.deltaTime;
            transform.Translate(leeMovement, Space.Self);

            leeHighlighter.SetActive(true); //Lee is the highlighted character since he is being controlled by the player.
        }

        if (!leeActive)
        {
            leeCam.enabled = false; //Lee's camera is deactivated.
            leeHighlighter.SetActive(false); //Lee is not the highlighted character.
        }
    }
}

