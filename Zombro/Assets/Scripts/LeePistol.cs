﻿using UnityEngine;
using System.Collections;

public class LeePistol : MonoBehaviour
{
    public static bool pistolActive; //Tells whether or not this weapon is in use.
    public bool firing = false; //A shot is being fired
    public PistolBulletController pistolBullet;
    public float bulletSpeed; //Speed of bullet
    public Transform spawnPoint;

    void Start()
    {
        pistolActive = true;
        firing = true; //The player can fire the first shot without waiting. 
    }

    void Update()
    {
        if (LeeController.leeActive) //Lee must be in control for the player to use his gun
        {
            if (pistolActive) //The pistol is the current weapon in use
            {
                if (firing)
                {
                    if (Input.GetMouseButtonDown(0)) //Fires a bullet when the player left-clicks.
                    {
                        PistolBulletController bulletInstance = Instantiate(pistolBullet, spawnPoint.position, spawnPoint.rotation) as PistolBulletController;
                        bulletInstance.speed = bulletSpeed;
                        StartCoroutine(Fire());
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
