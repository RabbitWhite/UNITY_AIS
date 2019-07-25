using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sbMatchVelocity : MonoBehaviour, ISteeringBehaviorRelationalToPlayer<Rigidbody, CharacterController>
{
    public float movementSpeed = 4.0f;

    PlayerController playerController;

    public string nameOfBehaviour = "Arrive";

    public string descriptionOfBehaviour = "Method based on steering behaviours presented by C. Reynols, see https://www.red3d.com/cwr/steer/";

    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    public void updateVelocity(ref Rigidbody ownRB, ref CharacterController targetRB)
    {
        ownRB.velocity = playerController.currentVelocity;
        Quaternion rotation = Quaternion.LookRotation(ownRB.velocity, Vector3.up);
        transform.rotation = rotation;
    }
}
