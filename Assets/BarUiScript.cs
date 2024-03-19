using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarUiScript : MonoBehaviour
{

    public HealthUiController hp;
    public SpriteRenderer sprite;
    private float health;
    // Update is called once per frame
    void Update()
    {
        health = hp.GetComponent<HealthUiController>().health;

        if (health > 0.7f)
        {
            sprite.color = Color.green;
        } else if (health < 0.7f && health > 0.3f) {
            sprite.color = Color.yellow;
        } else if (health < 0.3f) {
            sprite.color = Color.red;
        }
    }
}
