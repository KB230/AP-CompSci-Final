using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    
    public Bullet bulletPrefab;

    public Transform weaponT;
    //public Transform weaponT2;
    public bool shotFired; 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           print("shot");
            if (!shotFired)
            {
                Bullet b1 = Instantiate(bulletPrefab, weaponT.position, weaponT.rotation);
                FindObjectOfType<AudioManager>().Play("PlayerBulletShot");
                //Bullet b2 = Instantiate(bulletPrefab, weaponT2.position, weaponT2.rotation);
                b1.destroyed += LaserDestroyed;
                //b2.destroyed += LaserDestroyed;
                shotFired = true; 
            }
            
        }
    }
    void LaserDestroyed()
    {
        shotFired = false; 
    }
}
