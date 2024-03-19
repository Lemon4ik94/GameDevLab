using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUiController : MonoBehaviour
{
    public PlayerController player;
    public float health;

    void Update()
    {
        health = player.GetComponent<PlayerController>().currentHealth / 100;

        transform.localPosition = new Vector3( player.GetComponent<PlayerController>().facingRight ? -0.5f + health / 2 : (-0.5f + health / 2)*-1, transform.localPosition.y, transform.localPosition.z);
        transform.localScale = new Vector3(health, transform.localScale.y, transform.localScale.z);

    }
}
