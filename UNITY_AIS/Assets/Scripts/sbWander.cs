using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sbWander : MonoBehaviour, ISteeringBehaviorIndividual<Rigidbody>
{
    public float movementSpeed = 4.0f;
    float wanderOffset = 10.0f;
    float wanderRadius = 5.0f;
    float wanderRate = 3.0f;
    float maxAcceleration = 5;

    Vector3 wanderBeaconPosition = Vector3.zero;
    Quaternion wanderBeaconRotation = Quaternion.identity;
    Vector3 wanderTarget = Vector3.zero;

    public string nameOfBehaviour = "Wander";

    public string descriptionOfBehaviour = "Method based on steering behaviours presented by C. Reynols, see https://www.red3d.com/cwr/steer/";

    void Start()
    {

    }

    public void updateVelocity(ref Rigidbody ownRB)
    {
        wanderBeaconPosition = ownRB.transform.position + ownRB.transform.forward * 10.0f;
        wanderBeaconRotation *= Quaternion.Euler(Vector3.up * Random.Range(-20.0f, 20.0f));
        wanderTarget = wanderBeaconPosition + ((wanderBeaconRotation*wanderBeaconPosition).normalized*3.0f);
        //Debug.DrawLine(ownRB.transform.position, wanderBeaconPosition, Color.red, 1.0f);
        //Debug.DrawLine(wanderBeaconPosition, wanderTarget, Color.green, 1.0f);
        //Debug.DrawLine(ownRB.transform.position, wanderTarget, Color.blue, 1.0f);
        ///Debug.Log(ownRB.transform.position + ":" + wanderBeacon);

        //wanderOrientation.Rotate(Vector3.up, Random.Range(-90.0f, 90.0f), Space.Self);
        //ownRB.transform.Rotate(Vector3.up, Random.Range(-25.0f, 25.0f), Space.Self);

        ownRB.velocity = (wanderTarget-ownRB.transform.position).normalized * movementSpeed;
        transform.LookAt(wanderTarget);
    }
}
