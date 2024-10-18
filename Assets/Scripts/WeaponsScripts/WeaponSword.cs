using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSword : MonoBehaviour
{
    public int damageAmount = 5;
    

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy e = null;
            if (collision.TryGetComponent(out e))
            {
                e.EnemyTakeDamage(damageAmount);
            }

        }


    }

    public void UpDamage(int GF)
    {
        damageAmount += GF; 
    }

    

}
