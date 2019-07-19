using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 6.0f;
    public float rotationSpeed = 8.0f;

    public Vector3 currentVelocity = Vector3.zero;

    private CharacterController controller;

    Animator anim;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {

        // Rotate player character based on user input. 
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed, 0);

        // Determine where player character is facing.
        Vector3 forward = transform.TransformDirection(Vector3.forward);

        // Move the player.
        float curSpeed = movementSpeed * Input.GetAxis("Vertical");
        controller.SimpleMove(forward * curSpeed);

        anim.SetFloat("velocity", controller.velocity.magnitude);

        currentVelocity = controller.velocity;
        Debug.Log("target velocity before " + controller.velocity);

    }
}
