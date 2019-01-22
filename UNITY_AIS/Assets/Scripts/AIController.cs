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
    
    // Currently active behaviour.
    enum Behaviour { Seek, Flee };
    Behaviour selectedBehaviour;

    void Start()
    {
        seekScript = GetComponent<sbSeek>();
        fleeScript = GetComponent<sbFlee>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.S))
            selectedBehaviour = Behaviour.Seek;

        if (Input.GetKeyUp(KeyCode.F))
            selectedBehaviour = Behaviour.Flee;
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
            case Behaviour.Seek:
            default:
                // Apply the steering behaviour and update the orientation.
                seekScript.updateVelocity(ref rigidbody, Target.GetComponent<Rigidbody>());
                transform.LookAt(Target.position);
                break;
        }
    }
}
