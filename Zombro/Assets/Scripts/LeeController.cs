using UnityEngine;
using System.Collections;

public class LeeController : MonoBehaviour
{
    public float speed;
    public static bool leeActive = true;
    public Transform Chris;
    public Transform John;
    //private Rigidbody rb;
    //private Vector3 moveInput;
    //private Vector3 moveVelocity;
    //public Camera LeeCam;

    void Start()
    {
        leeActive = true; //Lee is the first active character in the scene.
        //rb = GetComponent<Rigidbody>();
       // LeeCam = FindObjectOfType<Camera>();
        
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
            //LeeCam.enabled = true; //Lee's camera is activated. 

            float moveHorizontal = Input.GetAxisRaw("Horizontal");
            float moveVertical = Input.GetAxisRaw("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            transform.rotation = Quaternion.LookRotation(movement);


            transform.Translate(movement * speed * Time.deltaTime, Space.World);
            //float hor = Input.GetAxis("Horizontal");
            //float ver = Input.GetAxis("Vertical");


            // Vector3 leeMovement = new Vector3(hor, 0, ver);
            // leeMovement = Vector3.ClampMagnitude(leeMovement, 1) * speed * Time.deltaTime;
            //transform.Translate(leeMovement, Space.World);

            // moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            //moveVelocity = moveInput * speed;

            // Ray cameraRay = LeeCam.ScreenPointToRay(Input.mousePosition);
            //Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            //float rayLength;

            //if(groundPlane.Raycast(cameraRay, out rayLength))
            // {
            // Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            //transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
            //}
        }

        /*
        void FixedUpdate()
        {
            rb.velocity = moveVelocity;
        }
        */
        if (!leeActive)
        {

            //LeeCam.enabled = false; //Lee's camera is deactivated.

            if (ChrisController.chrisActive)
            {
                //rotate to look at the player
                transform.LookAt(Chris.position);
                transform.Rotate(new Vector3(0, -90, 0), Space.World);//correcting the original rotation


                //move towards the player
                if (Vector3.Distance(transform.position, Chris.position) > 5f)
                {//move if distance from target is greater than 1
                    transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
                }
            }

            if (JohnController.johnActive)
            {
                //rotate to look at the player
                transform.LookAt(John.position);
                transform.Rotate(new Vector3(0, -90, 0), Space.World);//correcting the original rotation


                //move towards the player
                if (Vector3.Distance(transform.position, John.position) > 5f)
                {//move if distance from target is greater than 1
                    transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
                }
            }
        }
    }
}

