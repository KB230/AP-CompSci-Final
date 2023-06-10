using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Spawner : MonoBehaviour
{
    public Enemy[] prefabs;

    public int rows = 5;
    public int columns = 11;
    public float spacing = 2.0f;
    public float dimMultiplier = 2.0f;
    public float centerdivY = 2f;
    public float centerdivX = 2f;
    private Vector3 _direction = Vector2.right;
    public AnimationCurve speed;
    public float missleAttackRate = 1.0f;
    public int amountKilled { get; private set;}
    public int totalInvaders => this.rows * this.columns;
    public float percentKilled => (float)this.amountKilled / (float)this.totalInvaders; 
    public int amountAlive => this.totalInvaders - this.amountKilled;
    public GameObject misslePrefabGreen;
    public GameObject misslePrefabPurple;
    public GameObject misslePrefabBlue;
    public GameManager GM;
    
    private void Awake()
    {
        for(int row = 0; row < this.rows; row++)
        {
            float width = dimMultiplier * (this.columns - 1);
            float height = dimMultiplier * (this.rows - 1);
            Vector2 centering = new Vector2(-width / centerdivX, -height / centerdivY);
            Vector3 rowPosition = new Vector3(centering.x, centering.y + (row * spacing), 0.0f);

            for (int col = 0; col < this.columns; col++)
            {
                Enemy enemy = Instantiate(this.prefabs[row], this.transform);
                enemy.killed += InvaderKilled; 
                Vector3 position = rowPosition;
                position.x += col * spacing;
                enemy.transform.position = position; 
            }
        }
    }

    private void Start()
    {
        InvokeRepeating(nameof(MissleAttack), this.missleAttackRate, this.missleAttackRate);
        
    }

    private void Update()
    {
        this.transform.position += _direction * this.speed.Evaluate(this.percentKilled) * Time.deltaTime;

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        foreach (Transform enemy in this.transform)
        {
            if (!enemy.gameObject.activeInHierarchy)
            {
                continue;
            }

            if (_direction == Vector3.right && enemy.position.x >= (rightEdge.x - 1))
            {
                AdvanceRow(); 
            }else if(_direction == Vector3.left && enemy.position.x <= (leftEdge.x + 1))
            {
                AdvanceRow(); 
            }
        }

        if(amountKilled >= totalInvaders)
        {
            GM.win = true; 
        }

    }

    private void AdvanceRow()
    {
        _direction.x *= -1.0f;

        Vector3 position = this.transform.position;
        position.y -= 1.0f;
        this.transform.position = position; 
    }

    private void MissleAttack()
    {
        foreach (Transform enemy in this.transform)
        {
            if (!enemy.gameObject.activeInHierarchy)
            {
                continue;
            }

            if(Random.value < (1.0f / (float)this.amountAlive))
            {
                if(enemy.gameObject.CompareTag("Green Boi"))
                {
                    Instantiate(misslePrefabGreen, enemy.position, Quaternion.identity);
                    FindObjectOfType<AudioManager>().Play("EnemyShotFired");

                }
                else if (enemy.gameObject.CompareTag("Purple Boi"))
                {
                    Instantiate(misslePrefabPurple, enemy.position, Quaternion.identity);
                    FindObjectOfType<AudioManager>().Play("EnemyShotFired");
                }
                else if (enemy.gameObject.CompareTag("Blue Boi"))
                {
                    Instantiate(misslePrefabBlue, enemy.position, Quaternion.identity);
                    FindObjectOfType<AudioManager>().Play("EnemyShotFired");
                }
                
                break;
            }
        }

    }
    private void InvaderKilled()
    {
        this.amountKilled++;
    }

}
