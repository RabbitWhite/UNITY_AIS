using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AIController : MonoBehaviour
{

    public Transform Target;

    Rigidbody targetRB;
    CharacterController targetCC;

    bool active = true;

    // Individual steering behaviour scripts.
    sbSeek seekScript;
    sbFlee fleeScript;
    sbArrive arriveScript;
    sbAlign alignScript;
    sbMatchVelocity matchVelocityScript;
    sbPursue pursueScript;
    sbEvade evadeScript;
    sbFace faceScript;
    

    GUIController guiController;
    PlayerController playerController;


    // Currently active behaviour.
    public enum Behaviour { Seek, Flee, Arrive, Align, MatchVelocity, Pursue, Evade, Face };
    public Behaviour selectedBehaviour;

    Animator anim;

    void Start()
    {
        seekScript = GetComponent<sbSeek>();
        fleeScript = GetComponent<sbFlee>();
        arriveScript = GetComponent<sbArrive>();
        alignScript = GetComponent<sbAlign>();
        matchVelocityScript = GetComponent<sbMatchVelocity>();
        pursueScript = GetComponent<sbPursue>();
        evadeScript = GetComponent<sbEvade>();
        faceScript = GetComponent<sbFace>();

        targetRB = Target.GetComponent<Rigidbody>();
        targetCC = Target.GetComponent<CharacterController>();

        anim = GetComponent<Animator>();

        guiController = GameObject.Find("Main Canvas").GetComponent<GUIController>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void FixedUpdate()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();

        if (active)
        {
            switch (selectedBehaviour)
            {
                case Behaviour.Flee:
                    // Apply the steering behaviour and update the orientation.
                    fleeScript.updateVelocity(ref rigidbody, ref targetCC);
                    transform.LookAt(transform.position - (Target.position - transform.position));

                    guiController.nameOfBehaviour.text = "Selected behaviour: \n" + fleeScript.nameOfBehaviour;
                    guiController.descriptionOfBehaviour.text = "Description: \n" + fleeScript.descriptionOfBehaviour;

                    break;
                case Behaviour.Arrive:
                    // Apply the steering behaviour and update the orientation.
                    arriveScript.updateVelocity(ref rigidbody, ref targetCC);             

                    guiController.nameOfBehaviour.text = "Selected behaviour: \n" + arriveScript.nameOfBehaviour;
                    guiController.descriptionOfBehaviour.text = "Description: \n" + arriveScript.descriptionOfBehaviour;

                    break;
                case Behaviour.Align:
                    // Apply the steering behaviour and update the orientation.
                    alignScript.updateVelocity(ref rigidbody, ref targetCC);

                    guiController.nameOfBehaviour.text = "Selected behaviour: \n" + alignScript.nameOfBehaviour;
                    guiController.descriptionOfBehaviour.text = "Description: \n" + alignScript.descriptionOfBehaviour;

                    break;
                case Behaviour.MatchVelocity:
                    // Apply the steering behaviour and update the orientation.
                    matchVelocityScript.updateVelocity(ref rigidbody, ref targetCC);

                    guiController.nameOfBehaviour.text = "Selected behaviour: \n" + matchVelocityScript.nameOfBehaviour;
                    guiController.descriptionOfBehaviour.text = "Description: \n" + matchVelocityScript.descriptionOfBehaviour;

                    break;
                case Behaviour.Pursue:
                    // Apply the steering behaviour and update the orientation.
                    pursueScript.updateVelocity(ref rigidbody, ref targetCC);
                    

                    guiController.nameOfBehaviour.text = "Selected behaviour: \n" + pursueScript.nameOfBehaviour;
                    guiController.descriptionOfBehaviour.text = "Description: \n" + pursueScript.descriptionOfBehaviour;

                    break;
                case Behaviour.Evade:
                    // Apply the steering behaviour and update the orientation.
                    evadeScript.updateVelocity(ref rigidbody, ref targetCC);


                    guiController.nameOfBehaviour.text = "Selected behaviour: \n" + pursueScript.nameOfBehaviour;
                    guiController.descriptionOfBehaviour.text = "Description: \n" + pursueScript.descriptionOfBehaviour;

                    break;
                case Behaviour.Face:
                    // Apply the steering behaviour and update the orientation.
                    faceScript.updateVelocity(ref rigidbody, ref targetCC);


                    guiController.nameOfBehaviour.text = "Selected behaviour: \n" + faceScript.nameOfBehaviour;
                    guiController.descriptionOfBehaviour.text = "Description: \n" + faceScript.descriptionOfBehaviour;

                    break;
                case Behaviour.Seek:
                default:
                    // Apply the steering behaviour and update the orientation.
                    seekScript.updateVelocity(ref rigidbody, ref targetCC);

                    guiController.nameOfBehaviour.text = "Selected behaviour: \n" + seekScript.nameOfBehaviour;
                    guiController.descriptionOfBehaviour.text = "Description: \n" + seekScript.descriptionOfBehaviour;

                    break;
            }
            anim.SetFloat("velocity", rigidbody.velocity.magnitude);
        }
        else
        {
            rigidbody.velocity = Vector3.zero;
            anim.SetFloat("velocity", 0.0f);

            if (Vector3.Distance(this.transform.position, Target.position) > 3.0f)
                active = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            active = false;
    }
}
