using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : EnemyMovement
{
    [SerializeField] float Amplitude;
    [SerializeField] float Frequency;

    public override Vector3 Move(Vector3 aPlayerPosition)
    {
        Vector3 RetrunVelocity = aPlayerPosition - transform.position;

        RetrunVelocity.y += Mathf.Sin(Time.time * Frequency) * Amplitude;

        return RetrunVelocity.normalized * MovementSpeed;
    }

}
