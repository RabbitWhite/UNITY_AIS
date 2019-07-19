using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sbPursue : MonoBehaviour, ISteeringBehaviorRelationalToPlayer<Rigidbody, CharacterController>
{
    public float movementSpeed = 4.0f;
    float maximumPrediction = 10.0f;
    float prediction = 0.0f;

    public string nameOfBehaviour = "Pursue";

    public string descriptionOfBehaviour = "Method based on steering behaviours presented by C. Reynols, see https://www.red3d.com/cwr/steer/";

    public void updateVelocity(ref Rigidbody ownRB, ref CharacterController targetCC)
    {
        Vector3 directionToTarget = targetCC.transform.position - ownRB.transform.position;
        float distanceToTarget = directionToTarget.magnitude;Debug.Log("target velocity before P " + targetCC.velocity);
        
        //Debug.Log("distance to target " + distanceToTarget);
        if (ownRB.velocity.magnitude <= distanceToTarget / maximumPrediction)
        {
            prediction = maximumPrediction;
        }
        else
        {
            prediction = distanceToTarget / ownRB.velocity.magnitude;
        }
        //Debug.Log("prediction " + prediction);
        Vector3 predictedTargetPosition = targetCC.transform.position + targetCC.velocity * prediction;
        //Debug.Log("target position " + targetRB.transform.position);
        //Debug.Log("predicted target position " + predictedTargetPosition);
        //Debug.Log("own velocity before " + ownRB.velocity);
        //ownRB.velocity = (predictedTargetPosition - ownRB.transform.position).normalized * movementSpeed;
        //Debug.Log("own velocity after" + ownRB.velocity);
    }
}
