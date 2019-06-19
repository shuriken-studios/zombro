using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChrisController : MonoBehaviour
{

    public float speed;
    public static bool chrisActive;
    public Transform Lee;
    public Transform John;

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

            float hor = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");
            //transform.Rotate(0, Input.GetAxis("Rotate") * 60 * Time.deltaTime, 0);
            Vector3 chrisMovement = new Vector3(hor, 0, ver);
            chrisMovement = Vector3.ClampMagnitude(chrisMovement, 1) * speed * Time.deltaTime;
            transform.Translate(chrisMovement, Space.World);
            //transform.Rotate(0, Input.GetAxis("Horizontal"), 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(chrisMovement), 15f);

            /*
            float hor = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");

            Vector3 chrisMovement = new Vector3(hor, 0, ver);
            chrisMovement = Vector3.ClampMagnitude(chrisMovement, 1) * speed * Time.deltaTime;
            transform.Translate(chrisMovement, Space.World);
            */
        }
        if (!chrisActive)
        {

            if (LeeController.leeActive)
            {
                //rotate to look at the player
                transform.LookAt(Lee.position);
                transform.Rotate(new Vector3(0, -90, 0), Space.Self);//correcting the original rotation


                //move towards the player
                if (Vector3.Distance(transform.position, Lee.position) > 10f)
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
