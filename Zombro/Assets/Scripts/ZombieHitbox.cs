using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieHitbox : MonoBehaviour
{
    Renderer rend;
    float enemyHealth = 100;
    //public Text EnemyHealthUI;
    public GameObject enemyHealthBar;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        //EnemyHealthUI.GetComponent<Text>().text = "100";
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth == 20)
        {

        }

        if (enemyHealth == 0) //Once the enemy is out of health, it will dissappear. This code may be modified to leave a corpse behind or something. 
        {
            Destroy(this.transform.parent.gameObject); //Enemy is destroyed. Will dissappear.
            Destroy(this.enemyHealthBar);
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
