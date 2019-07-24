using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sbArrive : MonoBehaviour, ISteeringBehaviorRelationalToPlayer<Rigidbody, CharacterController>
{
    public float movementSpeed;

    public float SlowingRadius;

    public string nameOfBehaviour = "Arrive";

    public string descriptionOfBehaviour = "Method based on steering behaviours presented by C. Reynols, see https://www.red3d.com/cwr/steer/";

    public void updateVelocity(ref Rigidbody ownRB, ref CharacterController targetRB)
    {
        if ((targetRB.transform.position - ownRB.transform.position).magnitude > SlowingRadius)
            ownRB.velocity = (targetRB.transform.position - ownRB.transform.position).normalized * movementSpeed;
        else
            ownRB.velocity = ((targetRB.transform.position - ownRB.transform.position).magnitude / SlowingRadius / 2) * (targetRB.transform.position - ownRB.transform.position).normalized * movementSpeed;

        transform.LookAt(targetRB.transform.position);
    }
}
