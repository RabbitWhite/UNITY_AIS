using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sbFlee : MonoBehaviour, ISteeringBehaviorRelationalToPlayer<Rigidbody, CharacterController>
{
    public float movementSpeed = 4.0f;

    public string nameOfBehaviour = "Flee";

    public string descriptionOfBehaviour = "Method based on steering behaviours presented by C. Reynols, see https://www.red3d.com/cwr/steer/";

    public void updateVelocity(ref Rigidbody ownRB, ref CharacterController targetRB)
    {
        ownRB.velocity = (ownRB.transform.position - targetRB.transform.position).normalized * movementSpeed; 
    }
}
