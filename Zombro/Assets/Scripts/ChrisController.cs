using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class ChrisController : MonoBehaviour
    {
        //public GameObject Lee;
        //public GameObject John;
        public ThirdPersonCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
        private Transform m_Cam;                  // A reference to the main camera in the scenes transform
        private Vector3 m_CamForward;             // The current forward direction of the camera
        private Vector3 m_Move;
        private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.


        private void Start()
        {
            // get the transform of the main camera
            if (Camera.main != null)
            {
                m_Cam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning(
                    "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
                // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
            }

            // get the third person character ( this should never be null due to require component )
            m_Character = GetComponent<ThirdPersonCharacter>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }

            if (Input.GetKeyDown(KeyCode.Alpha1)) //Player switches to Chris
            {
                //leeActive = false;
                GetComponent<ChrisController>().enabled = false;
                //Lee.GetComponent<LeeController>().enabled = true;
                //ChrisController.chrisActive = true;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3)) //Player switches to John
            {
                //leeActive = false;
                GetComponent<ChrisController>().enabled = false;
                //John.GetComponent<JohnController>().enabled = true;
                //JohnController.johnActive = true;
            }
        }


        // Fixed update is called in sync with physics
        private void FixedUpdate()
        {
            // read inputs
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
            bool crouch = Input.GetKey(KeyCode.C);

            // calculate move direction to pass to character
            if (m_Cam != null)
            {
                // calculate camera relative direction to move:
                m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
                m_Move = v * m_CamForward + h * m_Cam.right;
            }
            else
            {
                // we use world-relative directions in the case of no main camera
                m_Move = v * Vector3.forward + h * Vector3.right;
            }
#if !MOBILE_INPUT
            // walk speed multiplier
            if (Input.GetKey(KeyCode.LeftShift)) m_Move *= 0.5f;
#endif

            // pass all parameters to the character control script
            m_Character.Move(m_Move, crouch, m_Jump);
            m_Jump = false;
        }
    }
}


/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChrisController : MonoBehaviour
{

    public float speed;
    public Camera chrisCam;
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
            //chrisCam.enabled = true; //Chris's camera is activated. 

            float hor = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");

            Vector3 chrisMovement = new Vector3(hor, 0, ver);
            chrisMovement = Vector3.ClampMagnitude(chrisMovement, 1) * speed * Time.deltaTime;
            transform.Translate(chrisMovement, Space.World);
        }
        if (!chrisActive)
        {
            chrisCam.enabled = false; //Chris's camera is deactivated.

            if (LeeController.leeActive)
            {
                //rotate to look at the player
                transform.LookAt(Lee.position);
                transform.Rotate(new Vector3(0, -90, 0), Space.World);//correcting the original rotation


                //move towards the player
                if (Vector3.Distance(transform.position, Lee.position) > 5f)
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
*/
