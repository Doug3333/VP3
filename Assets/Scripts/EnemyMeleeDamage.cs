using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeDamage : MonoBehaviour
{
    public int damageAmount = 1;
    [SerializeField] private float damageDelay = 1;
    private float nextDamageTime = 0;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Damageble>().TakeDamage(damageAmount);

        }



    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (Time.time > nextDamageTime)
        {
            nextDamageTime = Time.time + damageDelay;
            if (collision.CompareTag("Player"))
            {
                collision.GetComponent<Damageble>().TakeDamage(damageAmount);

            }
        }

    }

}

