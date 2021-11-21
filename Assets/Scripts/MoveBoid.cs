using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBoid : MonoBehaviour
{
    public GameObject goal;

    public float speedMax;
    public float speedMin;
    Vector2 speed;

    public float speedRotationMax;
    public float speedRotationMin;
    float speedRotation;

    public float multiRotation = 2f;
    public float multiSpeed = 1.5f;

    float distBetGoal;
    float angle;

    public float distBetGoalMax;
    public float distBetGoalSideMax;
    public float multiRotationHit = 1f;

    void Start() {
        goal = GameObject.Find("Goal");

        speed.x = Random.Range(speedMin, speedMax);
        speedRotation = Random.Range(speedRotationMin, speedRotationMax);
    }

    void Update() {
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, transform.up, distBetGoalSideMax);
        RaycastHit2D hitForward = Physics2D.Raycast(transform.position, transform.right, distBetGoalMax);
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, -transform.up, distBetGoalSideMax);

        Vector3 vectorToTarget = goal.transform.position - transform.position;

        if(hitForward && hitLeft && hitRight) {
            angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            moveBoid(1f, angle);

        } else if(hitForward) {
            if(vectorToTarget.x * vectorToTarget.y <= 0) {
                angle = (transform.eulerAngles.z + 90)%360;

            } else if(vectorToTarget.x * vectorToTarget.y > 0) {
                angle = (transform.eulerAngles.z - 90)%360;

            }
            moveBoid(multiRotationHit, angle);

        } else if(hitLeft) {
            angle = (transform.eulerAngles.z - 45f)%360;
            moveBoid(multiRotationHit, angle);

        } else if(hitRight) {
            angle = (transform.eulerAngles.z + 45f)%360;
            moveBoid(multiRotationHit, angle);

        } else if(hitForward && hitLeft) {
            angle = (transform.eulerAngles.z - 90)%360;
            moveBoid(multiRotationHit, angle);

        } else if(hitForward && hitRight) {
            angle = (transform.eulerAngles.z + 90)%360;
            moveBoid(multiRotationHit, angle);

        } else {
            angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            moveBoid(1f, angle);
        }
    }

    void moveBoid(float _multiRotationHit, float _angle) {
        Quaternion q = Quaternion.AngleAxis(_angle, Vector3.forward);

        distBetGoal = Vector3.Distance(goal.transform.position, transform.position);
        if(Input.GetMouseButton(0)){
            transform.rotation = Quaternion.Slerp(transform.rotation, q, speedRotation * multiRotation * _multiRotationHit * f(distBetGoal) * Time.deltaTime);
            transform.Translate(speed * multiSpeed * Time.deltaTime);
        }
        else{
            transform.rotation = Quaternion.Slerp(transform.rotation, q, speedRotation * _multiRotationHit * f(distBetGoal) * Time.deltaTime);
            transform.Translate(speed * Time.deltaTime);
        }
    }

    float f(float x){
        x = Mathf.Sqrt(x-1);
        if(x >= 1){
            return x;
        }

        return 1;
    }
}
