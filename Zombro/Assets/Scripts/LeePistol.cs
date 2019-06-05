using UnityEngine;

public class LeePistol : MonoBehaviour
{
    public bool pistolActive; //Tells whether or not this weapon is in use.
    public Rigidbody pistolBulletPrefab;
    public Transform spawnPoint; //This is where the bullet appears.

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Rigidbody pistolBulletInstance = Instantiate(pistolBulletPrefab, spawnPoint.position, spawnPoint.rotation) as Rigidbody;
            pistolBulletInstance.AddForce(spawnPoint.forward * 2000);

            Debug.Log("click");
        }
    }
}
