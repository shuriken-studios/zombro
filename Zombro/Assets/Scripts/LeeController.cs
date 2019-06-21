using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeeController : MonoBehaviour
{
    public float speed;
    public static bool leeActive;
    public Transform Chris;
    public Transform John;

    void Start()
    {
        leeActive = true; //John is not active when the scene begins.
    }

    void Update()
    {
        LeeMovement();

        if (Input.GetKeyDown(KeyCode.Alpha2)) //Player switches to Lee.
        {
            leeActive = false;
            ChrisController.chrisActive = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) //Player switches to Chris
        {
            leeActive = false;
            JohnController.johnActive = true;
        }

    }

    void LeeMovement()
    {
        if (leeActive)
        {
            //PUT THIS IN A SEPARATE SCRIPT AND ATTACH IT TO THE GUNS. CREATE NEW AXES CONTROLLED BY THE MOUSE!
            //float turn = Input.GetAxis("Horizontal");
            //transform.Rotate(transform.up, turn * m_TurnSpeed * Time.deltaTime);
                float hor = Input.GetAxis("Horizontal");
                float ver = Input.GetAxis("Vertical");
                Vector3 leeMovement = new Vector3(hor, 0, ver);
                leeMovement = Vector3.ClampMagnitude(leeMovement, 1) * speed * Time.deltaTime;
                transform.Translate(leeMovement, Space.World);
                //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(leeMovement), 15f);
                if (leeMovement != Vector3.zero)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(leeMovement.normalized), 0.1f);
                }
        }

        if (!leeActive)
        {

            if (ChrisController.chrisActive)
            {
                //rotate to look at the player
                transform.LookAt(Chris.position);
                transform.Rotate(new Vector3(0, -90, 0), Space.Self);//correcting the original rotation


                //move towards the player
                if (Vector3.Distance(transform.position, Chris.position) > 10f)
                {//move if distance from target is greater than 1
                    transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
                }
            }

            if (JohnController.johnActive)
            {
                //rotate to look at the player
                transform.LookAt(John.position);
                transform.Rotate(new Vector3(0, -90, 0), Space.Self);//correcting the original rotation


                //move towards the player
                if (Vector3.Distance(transform.position, John.position) > 10f)
                {//move if distance from target is greater than 1
                    transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
                }
            }
        }
    }
}

