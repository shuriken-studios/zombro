using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnController : MonoBehaviour
{
    public float speed;
    public static bool johnActive;
    public Transform Lee;
    public Transform Chris;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;
    Rigidbody rb;

    void Start()
    {
        johnActive = false; //John is not active when the scene begins.
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 3.0f, 0.0f);
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

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!johnActive)
        {
            if (other.gameObject.tag == "Jump")
            {
                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                isGrounded = false;
                Debug.Log("Hit");
            }
        }
    }

    void JohnMovement()
    {
        if (johnActive)
        {
            float hor = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");
            Vector3 johnMovement = new Vector3(hor, 0, ver);
            johnMovement = Vector3.ClampMagnitude(johnMovement, 1) * speed * Time.deltaTime;
            transform.Translate(johnMovement, Space.World);
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(leeMovement), 15f);
            if (johnMovement != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(johnMovement.normalized), 0.2f);
            }
        }

        if (!johnActive)
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
        }
    }
}
