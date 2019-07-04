using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sbSeek : MonoBehaviour, ISteeringBehaviorRelational<Rigidbody>
{
    public float movementSpeed = 4.0f;

    public string nameOfBehaviour = "Seek";

    public string descriptionOfBehaviour = "Method based on steering behaviours presented by C. Reynols, see https://www.red3d.com/cwr/steer/";

    public void updateVelocity(ref Rigidbody ownRB, Rigidbody targetRB)
    {
        ownRB.velocity = (targetRB.transform.position - ownRB.transform.position).normalized * movementSpeed; 
    }
}
