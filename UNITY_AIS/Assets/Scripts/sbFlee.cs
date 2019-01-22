using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sbFlee : MonoBehaviour, ISteeringBehaviorRelational<Rigidbody>
{
    public float movementSpeed = 4.0f;

    public void updateVelocity(ref Rigidbody ownRB, Rigidbody targetRB)
    {
        ownRB.velocity = (ownRB.transform.position - targetRB.transform.position).normalized * movementSpeed; 
    }
}
