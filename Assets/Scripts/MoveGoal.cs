using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGoal : MonoBehaviour
{
    public GameObject lightGoal;
    public Vector3 vectorBetGoal;

    void Start() {

    }

    void FixedUpdate() {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        vectorBetGoal = transform.position - mousePosition;

        vectorBetGoal.z = 0;

        gameObject.transform.Translate(-vectorBetGoal * Time.deltaTime * 20, Space.World);
        lightGoal.transform.position = transform.position;
    }
}
