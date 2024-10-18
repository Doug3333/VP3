using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : EnemyMovement
{
     

    public override Vector3 Move(Vector3 aPlayerPosition)
    {
        return (aPlayerPosition - transform.position).normalized * MovementSpeed;
    }

}
