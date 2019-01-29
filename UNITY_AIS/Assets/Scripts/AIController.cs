using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AIController : MonoBehaviour
{

    public Transform Target;

    // Individual steering behaviour scripts.
    sbSeek seekScript;
    sbFlee fleeScript;
    sbArrive arriveScript;

    // Currently active behaviour.
    public enum Behaviour { Seek, Flee, Arrive };
    public Behaviour selectedBehaviour;

    Animator anim;

    void Start()
    {
        seekScript = GetComponent<sbSeek>();
        fleeScript = GetComponent<sbFlee>();
        arriveScript = GetComponent<sbArrive>();

        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();

        switch (selectedBehaviour)
        {
            case Behaviour.Flee:
                // Apply the steering behaviour and update the orientation.
                fleeScript.updateVelocity(ref rigidbody, Target.GetComponent<Rigidbody>());
                transform.LookAt(transform.position - (Target.position - transform.position));
                break;
            case Behaviour.Arrive:
                // Apply the steering behaviour and update the orientation.
                arriveScript.updateVelocity(ref rigidbody, Target.GetComponent<Rigidbody>());
                transform.LookAt(Target.position);
                break;
            case Behaviour.Seek:
            default:
                // Apply the steering behaviour and update the orientation.
                seekScript.updateVelocity(ref rigidbody, Target.GetComponent<Rigidbody>());
                transform.LookAt(Target.position);
                break;
        }

        anim.SetFloat("velocity", rigidbody.velocity.magnitude);
    }
}
