using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sbEvade : MonoBehaviour, ISteeringBehaviorRelationalToPlayer<Rigidbody, CharacterController>
{
    public float movementSpeed = 4.0f;
    float maximumPrediction = 1.0f;
    float prediction = 0.0f;

    public string nameOfBehaviour = "Evade";

    public string descriptionOfBehaviour = "Method based on steering behaviours presented by C. Reynols, see https://www.red3d.com/cwr/steer/";

    PlayerController playerController;

    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    public void updateVelocity(ref Rigidbody ownRB, ref CharacterController targetCC)
    {
        Vector3 directionToTarget = targetCC.transform.position - ownRB.transform.position;
        float distanceToTarget = directionToTarget.magnitude;

        if (ownRB.velocity.magnitude <= distanceToTarget / maximumPrediction)
        {
            prediction = maximumPrediction;
        }
        else
        {
            prediction = distanceToTarget / ownRB.velocity.magnitude;
        }
        Vector3 predictedTargetPosition = targetCC.transform.position + playerController.currentVelocity * prediction;
        ownRB.velocity = (ownRB.transform.position - predictedTargetPosition).normalized * movementSpeed;
        Quaternion rotation = Quaternion.LookRotation(ownRB.velocity, Vector3.up);
        transform.rotation = rotation;
    }
}
