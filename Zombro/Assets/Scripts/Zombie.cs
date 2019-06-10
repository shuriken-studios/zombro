using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{ 

    public Transform Lee;
    public Transform Chris;
    public Transform John;
    public Transform[] protags = new Transform[3];
    public Transform target;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        protags[0] = Lee;
        protags[1] = Chris;
        protags[2] = John;
    }

    // Update is called once per frame
    void Update()
    {
        target = GetClosestEnemy(protags);

        // rotate to look at the player
        transform.LookAt(target.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);//correcting the original rotation


        //move towards the player
        if (Vector3.Distance(transform.position, target.position) > 1f)
        {//move if distance from target is greater than 1
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
    }

    Transform GetClosestEnemy(Transform[] players)
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (Transform t in players)
        {
            float dist = Vector3.Distance(t.position, currentPos);
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }
        return tMin;
    }
}
