using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sbAlign : MonoBehaviour, ISteeringBehaviorRelationalToPlayer<Rigidbody, CharacterController>
{
    public float rotationSpeed;

    public string nameOfBehaviour = "Arrive";

    public string descriptionOfBehaviour = "Method based on steering behaviours presented by C. Reynols, see https://www.red3d.com/cwr/steer/";

    public void updateVelocity(ref Rigidbody ownRB, ref CharacterController targetRB)
    {
        float step = rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRB.transform.rotation, step);
    }
}
