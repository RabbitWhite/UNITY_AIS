using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sbSeek : MonoBehaviour, ISteeringBehaviorRelational<Rigidbody>
{
    public float movementSpeed = 4.0f;

    public void updateVelocity(ref Rigidbody ownRB, Rigidbody targetRB)
    {
        ownRB.velocity = (targetRB.transform.position - ownRB.transform.position).normalized * movementSpeed; 
    }
}
