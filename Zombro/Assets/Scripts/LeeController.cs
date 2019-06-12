using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeeController : MonoBehaviour
{
    public float speed;
    public float jumpSpeed = 3;
    public Camera leeCam;
    public static bool leeActive;
    public Transform Chris;
    public Transform John;
    Vector3 m_EulerAngleVelocity;
    Rigidbody rb;

    void Start()
    {
        leeActive = true; //John is not active when the scene begins.
        rb = GetComponent<Rigidbody>();
        m_EulerAngleVelocity = new Vector3(0, 0, 0);
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
            leeCam.enabled = true; //Lee's camera is activated. 

            
            float hor = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");
            //transform.Rotate(0, Input.GetAxis("Rotate") * 60 * Time.deltaTime, 0);
            Vector3 leeMovement = new Vector3(hor, 0, ver);
            leeMovement = Vector3.ClampMagnitude(leeMovement, 1) * speed * Time.deltaTime;
            transform.Translate(leeMovement, Space.World);
            //transform.Rotate(0, Input.GetAxis("Horizontal"), 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(leeMovement), 15f);

        }

        if (!leeActive)
        {
           leeCam.enabled = false; //John's camera is deactivated.

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

