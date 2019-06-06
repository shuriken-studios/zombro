using UnityEngine;
using System.Collections;

public class LeePistol : MonoBehaviour
{
    public static bool pistolActive; //Tells whether or not this weapon is in use.
    public bool firing = false; //A shot is being fired
    public PistolBulletController pistolBullet;
    public float bulletSpeed; //Speed of bullet
    public Transform spawnPoint;
    public float pistolAmmo = 50; //Amount of ammunition

    void Start()
    {
        pistolActive = true;
        firing = true; //The player can fire the first shot without waiting. 
    }

    void Update()
    {

        if (pistolAmmo >= 300) //Sets a cap of 300 pistol bullets
        {
            pistolAmmo = 300;
        }

        if (pistolAmmo <= 0) //Sets a min of 0 bullets.
        {
            pistolAmmo = 0;
        }

        if (LeeController.leeActive) //Lee must be in control for the player to use his gun
        {
            if (pistolActive) //The pistol is the current weapon in use
            {
                if (firing)
                {
                    if (pistolAmmo > 0)
                    {
                        if (Input.GetMouseButtonDown(0)) //Fires a bullet when the player left-clicks.
                        {
                            PistolBulletController bulletInstance = Instantiate(pistolBullet, spawnPoint.position, spawnPoint.rotation) as PistolBulletController;
                            bulletInstance.speed = bulletSpeed;
                            pistolAmmo -= 1;
                            Debug.Log(pistolAmmo);
                            StartCoroutine(Fire());
                        }
                    }
                }
            }
        }
    }
    
    IEnumerator Fire() //This method sets the period of time in between fires.
    {
        firing = false;
        yield return new WaitForSeconds(0.5f);
        firing = true;
    }

}
