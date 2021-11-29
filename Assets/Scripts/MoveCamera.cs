using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float speed = 1.0f;
    Vector3 vectorBetGoal;
    GameObject goal;

    public float limitX;
    public float limitY;
    public float limitX2;
    public float limitY2;

    void Start() {
        goal = GameObject.Find("Goal");
    }

    void FixedUpdate() {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        vectorBetGoal = transform.position - mousePosition;

        vectorBetGoal.z = 0;

        Collider();
        if(goal != null) {
            gameObject.transform.Translate(-vectorBetGoal * speed * Time.deltaTime, Space.World);
        }
    }

    void Collider() {
        if(goal != null) {
            if(transform.position.x - 0.1 <= limitX) {
                if(vectorBetGoal.x > 0) {
                    vectorBetGoal.x = 0;
                }
            }

            if(transform.position.y + 0.25 >= limitY) {
                if(vectorBetGoal.y < 0) {
                    vectorBetGoal.y = 0;
                }
            }
        }
    }
}
