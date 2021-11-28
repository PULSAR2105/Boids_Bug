using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public MoveGoal moveGoal;
    public GameObject goal;
    public GameObject dashGoal;
    public GameObject dashTarget;

    public float multiRotation;
    public float multiSpeed;
    float tmp_multiRotation;
    float tmp_multiSpeed;


    Vector3 vectorMove;
    public int distance;

    void Start()
    {
        tmp_multiRotation = multiRotation;
        tmp_multiSpeed = multiSpeed;
        dashTarget = goal;
    }

    void FixedUpdate()
    {
        if(goal != null) {
            vectorMove = moveGoal.vectorBetGoal / moveGoal.vectorBetGoal.magnitude * distance;
            transform.position = goal.transform.position + -vectorMove;
        }

        if(Input.GetMouseButton(0)){
            multiRotation = tmp_multiRotation;
            multiSpeed = tmp_multiSpeed;
        } else {
            multiRotation = 1;
            multiSpeed = 1;
        }

        if(Input.GetMouseButton(1)){
            dashTarget = dashGoal;
        } else {
            dashTarget = goal;
        }

    }
}
