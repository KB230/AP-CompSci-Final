using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_P1 : MonoBehaviour
{
    public int speed = 50;

    public GameManager GM; 
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("collided");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            GM.loss = true; 
        }
    }
}
