using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGoal : MonoBehaviour
{
    public GameObject lightGoal;
    public Vector3 vectorBetGoal;

    public float speedMax;

    public float limitX;
    public float limitY;
    public float limitX2;
    public float limitY2;

    void Start() {

    }

    void FixedUpdate() {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        vectorBetGoal = transform.position - mousePosition;
        if(vectorBetGoal.magnitude > speedMax) {
            vectorBetGoal = vectorBetGoal.normalized * speedMax;
        }

        vectorBetGoal.z = 0;

        Collider();
        gameObject.transform.Translate(-vectorBetGoal * Time.deltaTime * 20, Space.World);
        lightGoal.transform.position = transform.position;
    }

    void Collider() {
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
