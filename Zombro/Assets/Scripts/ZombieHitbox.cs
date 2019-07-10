using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieHitbox : MonoBehaviour
{
    //Renderer rend;
    float enemyHealth = 100;
    public Image Healthbar;
    public Text EnemyHealthUI;

    void Start() { 
        //rend = GetComponent<Renderer>();
        EnemyHealthUI.GetComponent<Text>().text = "100";
    }

    // Update is called once per frame
    void Update()
    {
        EnemyHealthUI.GetComponent<Text>().text = enemyHealth + "%";

        if (enemyHealth == 100)
        {
          Healthbar.GetComponent<Image>().color = Color.green;

        }

        if (enemyHealth == 80)
        {
            Healthbar.GetComponent<Image>().color = new Color32(241,255,35,255);
        }

        if (enemyHealth == 60)
        {
            Healthbar.GetComponent<Image>().color = new Color32(255,190,0,255);
        }

        if (enemyHealth == 40)
        {
            Healthbar.GetComponent<Image>().color = new Color32(221,94,20,255);
        }

        if (enemyHealth == 20)
        {
            Healthbar.GetComponent<Image>().color = Color.red;
        }

        if (enemyHealth == 0) //Once the enemy is out of health, it will dissappear. This code may be modified to leave a corpse behind or something. 
        {
            Destroy(this.transform.parent.gameObject); //Enemy is destroyed. Will dissappear.
            Destroy(this.Healthbar.transform.parent);
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
