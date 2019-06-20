using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotate : MonoBehaviour
{
    // The target marker.
    Transform target;
    public Camera mainCam;
    // Angular speed in radians per sec.
    float speed;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.gameObject.tag == "RegZombie") //Just add any new enemies using tags to make them "shootable"
                {
                    //hit.collider.gameObject = target;
                    //hit.collider.gameObject.tag = target;
                    Debug.Log(hit.collider.gameObject.tag);
                    target = hit.transform;
                    transform.LookAt(target);
                }
            }
            /*
            Vector3 targetDir = target.position - transform.position;

            // The step size is equal to speed times frame time.
            float step = speed * Time.deltaTime;

            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
            Debug.DrawRay(transform.position, newDir, Color.red);

            // Move our position a step closer to the target.
            transform.rotation = Quaternion.LookRotation(newDir);
            */
        }

    }
}
