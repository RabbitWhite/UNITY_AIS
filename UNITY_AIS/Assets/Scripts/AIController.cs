using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AIController : MonoBehaviour
{

    public Transform Player;
    int MoveSpeed = 4;
    int MaxDist = 10;
    int MinDist = 2;

    private CharacterController controller;


    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    void Update()
    {
        

        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {
            transform.LookAt(Player);

            controller.SimpleMove(transform.forward * MoveSpeed);


        }
        else
        {
            controller.SimpleMove(Vector3.zero);
        }
    }
}
