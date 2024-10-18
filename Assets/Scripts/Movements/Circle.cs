using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Circle : EnemyMovement
{
    [SerializeField] float Amplitude;
    [SerializeField] float Frequency;
    private float RotationPosition;
    public float DistanceFromPlayer;
    public bool JustEntered;


    public override Vector3 Move(Vector3 aPlayerPosition)
    {

        Vector3 RetrunVelocity = aPlayerPosition - transform.position;
        DistanceFromPlayer = RetrunVelocity.magnitude;

        if (DistanceFromPlayer < Amplitude)
        {
            
            RotationPosition += 0.001f;

            if (DistanceFromPlayer < Amplitude - 1)
            {
                RetrunVelocity = RetrunVelocity.normalized * MovementSpeed * -0.35f;

            }
            else
            {
                RetrunVelocity = RetrunVelocity.normalized * MovementSpeed;
            }

            RetrunVelocity.y += Mathf.Sin(RotationPosition * Frequency) * Amplitude;
            RetrunVelocity.x += Mathf.Cos(RotationPosition * Frequency) * Amplitude;
 
        }

        else
        {
            JustEntered = true;
            RetrunVelocity = RetrunVelocity.normalized * MovementSpeed;
        }

        return RetrunVelocity;

    }

}

