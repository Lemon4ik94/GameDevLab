using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{
    public int health;
    public PlayerController player;
    public EnemyController enemyPrefab;
    public bool alive = true;
    public Animator animator;
    private Rigidbody2D rb;
    private BoxCollider2D bc;

    void Start() {
        health = 2;
    }

    public void TakeDamage()
    {
    
        health -= 1;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);

        alive = false;

        // if (player.GetComponent<PlayerController>().transform.position.x > 0)
        // {
        //     Instantiate(enemyPrefab, new Vector3(Random.Range(4.61f, 8.47f), 1.9f), enemyPrefab.transform.rotation);
        // }
    }
}
