using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20;
    public int damage = 1;
    public System.Action destroyed;
    public ParticleSystem impactExplosion; 

    void Update()
    {
        transform.Translate((transform.up * speed * Time.deltaTime));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Border") || collision.gameObject.CompareTag("Barrier"))
        {
            this.destroyed.Invoke(); 
            Destroy(this.gameObject);

        }
        if (collision.gameObject.CompareTag("Green Boi") || collision.gameObject.CompareTag("Purple Boi") || collision.gameObject.CompareTag("Blue Boi"))
        {
            FindObjectOfType<AudioManager>().Play("Boom");
            Instantiate(impactExplosion, collision.gameObject.transform.position, Quaternion.identity);
            collision.gameObject.GetComponent<Enemy>().health -= damage;
            this.destroyed.Invoke();
            Destroy(this.gameObject);
        }
    }
}
