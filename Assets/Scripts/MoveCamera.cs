using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float speed = 1.0f;
    Vector3 vectorBetGoal;
    GameObject goal;

    void Start() {
        goal = GameObject.Find("Goal");
    }

    void FixedUpdate() {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        vectorBetGoal = transform.position - mousePosition;

        vectorBetGoal.z = 0;

        if(goal != null) {
            gameObject.transform.Translate(-vectorBetGoal * speed * Time.deltaTime, Space.World);
        }
    }
}
