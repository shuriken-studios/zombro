using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHitbox : MonoBehaviour
{
    float enemyHealth = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth == 0) //Once the enemy is out of health, it will dissappear. This code may be modified to leave a corpse behind or something. 
        {
            Destroy(this.transform.parent.gameObject); //Enemy is destroyed. Will dissappear.
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PistolBullet") //Will be updated for different bullets and attacks to effect it. 
        {
            enemyHealth -= 20;
            Destroy(other.gameObject); //Bullet will be destroyed upon hitting enemy. Some kind of visual could be added later.
            Debug.Log(enemyHealth);
        }
    }
}
