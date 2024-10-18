using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyMovement : MonoBehaviour
{

    [SerializeField] public float MovementSpeed;

    public virtual Vector3 Move(Vector3 aPlaterPosition)
    {
        return Vector3.zero;
    }

 
}
