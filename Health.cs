using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 1;
    private void Update()
    {
        Die();
    }
    void Die()
    {
        if (health <= 0)
        {
            FindObjectOfType<AudioManager>().Play("PlayerDies");
            gameObject.SetActive(false); 
        }
    }
}
