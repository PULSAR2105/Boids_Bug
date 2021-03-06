using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBoid : MonoBehaviour
{
    public Dash dash;
    
    public float speedMax;
    public float speedMin;
    Vector2 speed;

    public float speedRotationMax;
    public float speedRotationMin;
    float speedRotation;

    public float multiRotation;
    public float multiSpeed;

    float distBetGoal;
    float angle;

    public float distRayMax;
    public float distRaySideMax;
    public float multiRotationHit;

    Vector3 vectorToTarget;
    Quaternion q;

    void Start() {
        speed.x = Random.Range(speedMin, speedMax);
        speedRotation = Random.Range(speedRotationMin, speedRotationMax);
    }

    void FixedUpdate() {
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.localPosition, transform.up, distRaySideMax);
        RaycastHit2D hitForward = Physics2D.Raycast(transform.localPosition, transform.right, distRayMax);
        RaycastHit2D hitRight = Physics2D.Raycast(transform.localPosition, -transform.up, distRaySideMax);

        if(dash.dashTarget != null) {
            vectorToTarget = dash.dashTarget.transform.localPosition - transform.localPosition;
        }
        else {
            vectorToTarget = Vector3.zero;
        }

        if(hitForward || hitLeft || hitRight) {
            // Managing the speed rotation of the boid
            if(hitForward && hitLeft && hitRight) {
                angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
                moveBoid(1f, angle);

            } else if(hitForward) {
                if(vectorToTarget.x * vectorToTarget.y <= 0) {
                    angle = (transform.eulerAngles.z + 90)%360;

                } else {
                    angle = (transform.eulerAngles.z - 90)%360;
                }
                moveBoid(multiRotationHit, angle);

            } else if(hitLeft) {
                    angle = (transform.eulerAngles.z - 45f)%360;
                    moveBoid(multiRotationHit, angle);

            } else if(hitRight) {
                    angle = (transform.eulerAngles.z + 45f)%360;
                    moveBoid(multiRotationHit, angle);

            } else {
                angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
                moveBoid(1f, angle);
            }
        } else {
                angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
                moveBoid(1f, angle);
        }
    }

    // Move the boid
    void moveBoid(float _multiRotationHit, float _angle) {
        q = Quaternion.AngleAxis(_angle, Vector3.forward);

        if(dash.dashTarget != null) {
            distBetGoal = Vector3.Distance(dash.dashTarget.transform.localPosition, transform.localPosition);
        }
        else {
            distBetGoal = 0;
        }
        
        if(dash.dashTarget != null) {
            transform.rotation = Quaternion.Slerp(transform.rotation, q, speedRotation * dash.multiRotation * _multiRotationHit * f(distBetGoal) * Time.deltaTime);
        }
        transform.Translate(speed * dash.multiSpeed * Time.deltaTime);
    }

    float f(float x){
        x = Mathf.Sqrt(x-1);
        if(x >= 1){
            return x;
        }

        return 1;
    }
}
