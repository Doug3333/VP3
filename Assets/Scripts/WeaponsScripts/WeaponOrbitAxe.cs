using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponOrbitAxe : MonoBehaviour
{
    public int damageAmount = 5;

    public BoxCollider2D PickupTrigger;
    public bool pickup;
    [SerializeField] float Orbitpeed;

    public void UpDamage(int GFK)
    {
        damageAmount += GFK;
        Orbitpeed += GFK;
    }

    //public float Orbitspeed;
    //public float Orbitradius;


    //private void Update()
    //{


    //    if (pickup)
    //    {

    //        //Vector3 OrbitAxe = transform.position;
    //        //Vector3 AxePositon = transform.position;


    //        Vector3 orbitPos = new Vector3(Mathf.Cos(Time.time * Orbitspeed), Mathf.Sin(Time.time * Orbitspeed), 0) * Orbitradius;
    //        transform.localPosition = orbitPos;

    //    }

    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && pickup ==true)
        {
            //OnPickUp.ChangeTagTo TagWeapon;

            Enemy e = null;
            if (collision.TryGetComponent(out e))
            {
                e.EnemyTakeDamage(damageAmount);
            }

        }

    }
}
