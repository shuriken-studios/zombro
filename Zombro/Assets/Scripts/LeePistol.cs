using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeePistol : MonoBehaviour
{

    public bool pistolActive; //This is the weapon the player is currently using.
    public GameObject Bullet; //The actual bullet
    public Transform spawnPoint; //This is where the bullet will first appear
    public int bulletSpeed; //The speed of the bullet
    public float bulletEnd = 3.0f; //The bullet will dissappear after three seconds
    public bool canShoot = true; //Gun can be fired
    public float waitBeforeNextShot = 0.25f; //Bullets can be fired at this time interval

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (canShoot)
            {
                canShoot = false;
                Shoot();
                StartCoroutine(ShootingYield());
            }
        }
    }

    IEnumerator ShootingYield()
    {
        yield return new WaitForSeconds(waitBeforeNextShot);
        canShoot = true;
    }
    void Shoot() //This method instantiates the bullet.
    {
        var bullet = Instantiate(Bullet, spawnPoint.position, spawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

        Destroy(bullet, bulletEnd);
    }
}
