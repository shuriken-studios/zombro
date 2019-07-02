using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChrisController : MonoBehaviour
{

    public float speed;
    public static bool chrisActive;
    public Transform Lee;
    public Transform John;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;
    Rigidbody rb;

    void Start()
    {
        chrisActive = false; //Chris is inactive when the scene begins.
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 3.0f, 0.0f);
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

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!chrisActive)
        {
            if (other.gameObject.tag == "Jump")
            {
                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                isGrounded = false;
                Debug.Log("Hit");
            }
        }
    }

    void ChrisMovement()
    {
        if (chrisActive)
        {
            float hor = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");
            Vector3 chrisMovement = new Vector3(hor, 0, ver);
            chrisMovement = Vector3.ClampMagnitude(chrisMovement, 1) * speed * Time.deltaTime;
            transform.Translate(chrisMovement, Space.World);
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(leeMovement), 15f);
            if (chrisMovement != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(chrisMovement.normalized), 0.2f);
            }
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
