using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene : MonoBehaviour
{

    public PlayerController player;
    public EnemyController enemyPrefab;
    private EnemyController enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = Instantiate(enemyPrefab, new Vector3(Random.Range(4.61f, 8.47f), 1.9f), enemyPrefab.transform.rotation);
        enemy.transform.Rotate(0, 180f, 0);
        enemy.health = 2;

    }

    void Update()
    {
        if (enemy.alive == false)
        {
            Debug.Log($"{enemy.alive} {enemyPrefab.alive}");

            if (player.GetComponent<PlayerController>().transform.position.x < 0)
            {
                enemy = Instantiate(enemyPrefab, new Vector3(Random.Range(4.61f, 8.47f), 1.9f), enemyPrefab.transform.rotation);
                enemy.transform.Rotate(0, 180f, 0);
            } else if (player.GetComponent<PlayerController>().transform.position.x > 0) {
                enemy = Instantiate(enemyPrefab, new Vector3(Random.Range(-9.11f, -1.69f), 0.9f), enemyPrefab.transform.rotation);

            }
            enemy.alive = true;
        }
    }
}
