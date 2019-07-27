using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sbFace : MonoBehaviour, ISteeringBehaviorRelationalToPlayer<Rigidbody, CharacterController>
{
    public string nameOfBehaviour = "Face";

    public string descriptionOfBehaviour = "Method based on steering behaviours presented by C. Reynols, see https://www.red3d.com/cwr/steer/";

    public void updateVelocity(ref Rigidbody ownRB, ref CharacterController targetRB)
    {
        transform.LookAt(targetRB.transform.position);
    }
}
