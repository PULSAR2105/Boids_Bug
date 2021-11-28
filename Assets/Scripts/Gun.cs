using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public BoidsManager manager;

    public float distanceHit;
    public LineRenderer ray;
    Transform[] Positions;

    public float speedShot;
    public float _durationShot;
    public float reactionTime;
    bool _isShot = false;

    RaycastHit2D hitEnemy;
    RaycastHit2D hitWall;

    GameObject[] enemies;
    GameObject goal;
    GameObject target;
    public float speedRotation;
    float angle;
    Vector3 vectorToTarget;
    Quaternion q;
    float mindist;
    float dist;

    void Start() {
        ray.useWorldSpace = true;
        ray.positionCount = 2;
        ray.SetPosition(0, transform.position);
        ray.SetPosition(1, transform.position);

        goal = GameObject.Find("Goal");
    }

    void FixedUpdate() {
        mindist = Mathf.Infinity;
        enemies = GameObject.FindGameObjectsWithTag("Boid");

        foreach (GameObject enemy in enemies) {
            dist = Vector3.Distance(enemy.transform.position, transform.position);
            if (dist < mindist)
            {
                mindist = dist;
                target = enemy;
            }
            
        }

        if(goal != null) {
            dist = Vector3.Distance(goal.transform.position, transform.position);
        }
        
        if (dist < mindist)
        {
            mindist = dist;
            target = goal;
        }

        vectorToTarget = target.transform.localPosition - transform.localPosition;
        angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        q = Quaternion.AngleAxis(angle, Vector3.forward);
        
        if(!_isShot) {
            transform.rotation = Quaternion.Slerp(transform.rotation, q, speedRotation * Time.deltaTime);
        }

        hitEnemy = Physics2D.Raycast(transform.position, transform.right, distanceHit, 4);
        hitWall = Physics2D.Raycast(transform.position + transform.right * 1.5f, transform.right, distanceHit);
        
        if(hitEnemy && hitWall) {
             StartCoroutine(shot());
        } 
        if(hitEnemy && !hitWall) {
             StartCoroutine(shot());
        }
    }

    IEnumerator shot() {
        yield return new WaitForSeconds(reactionTime);

        if(hitEnemy && hitWall) {
           if(hitWall.distance > hitEnemy.distance) {
               if(!_isShot) {
                    _isShot = true;
                    ray.positionCount = 2;
                    ray.SetPosition(0, transform.position);
                    ray.SetPosition(1, hitEnemy.point);

                    manager.DestroyBoid(hitEnemy.collider.gameObject);

                    StartCoroutine(durationShot());
                    StartCoroutine(isShot());
               }
           }
       } 
       if(hitEnemy && !hitWall) {
            if(!_isShot) {
                    _isShot = true;
                    ray.positionCount = 2;
                    ray.SetPosition(0, transform.position);
                    ray.SetPosition(1, hitEnemy.point);

                    manager.DestroyBoid(hitEnemy.collider.gameObject);

                    StartCoroutine(durationShot());
                    StartCoroutine(isShot());
               }
       }
    }

    IEnumerator isShot() {
        yield return new WaitForSeconds(speedShot);
        _isShot = false;
    }

    IEnumerator durationShot() {
        yield return new WaitForSeconds(_durationShot);
        ray.positionCount = 2;
        ray.SetPosition(0, transform.position);
        ray.SetPosition(1, transform.position);
    }
}
