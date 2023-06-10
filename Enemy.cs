using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firepoint;
    public int reloadTime = 1;
    public int damage = 25;
    public int health = 5;
    //private bool canFire = false;
    public System.Action killed; 
    
    private void Awake()
    {
        //StartCoroutine(Reload());  
    }
    void Update()
    {
        //if (canFire == true)
       // {
            //InRange scripts
           // Shoot();
            //canFire = false;
            //StartCoroutine(Reload());
      //  }
        Die(); 
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);
        //canFire = true;
    }
    private void Shoot()
    {
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation); 
    }

    void Die()
    {
        if(health <=0)
        {
            Destroy(gameObject);
            this.killed.Invoke(); 
        }
    }
}
