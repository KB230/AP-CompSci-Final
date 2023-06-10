using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    /*
     EASTER EGG ++++ WOO MOO
     SRC CODE READERS R NERDS 
    PLAY THE GAME BOZOS
              UNLESS
                        
     */
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            this.gameObject.SetActive(false); 
        }
    }

}
