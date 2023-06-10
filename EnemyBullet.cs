using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 20;
    public int damage = 1;

    void Update()
    {
        transform.Translate((-transform.up * speed * Time.deltaTime));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Border"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Barrier"))
        {
            collision.gameObject.GetComponent<Health>().health -= damage;
            FindObjectOfType<AudioManager>().Play("Boom");
            Destroy(gameObject); 
        }
        
    }
}
