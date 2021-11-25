using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{    
    public float distanceHit;
    public LineRenderer ray;
    Transform[] Positions;

    public float speedShot;
    public float _durationShot;
    public float reactionTime;
    bool _isShot = false;

    RaycastHit2D hitFriend;
    RaycastHit2D hitWall;

    void Start()
    {
        ray.useWorldSpace = true;
        ray.positionCount = 2;
        ray.SetPosition(0, transform.position);
        ray.SetPosition(1, transform.position);
    }

    void Update() {
       hitFriend = Physics2D.Raycast(transform.position, transform.right, distanceHit, 4);
       hitWall = Physics2D.Raycast(transform.position + transform.right * 1.5f, transform.right, distanceHit);
       
       if(hitFriend && hitWall) {
            StartCoroutine(shot());
       } 
       if(hitFriend && !hitWall) {
            StartCoroutine(shot());
       }
    }

    IEnumerator shot() {
        yield return new WaitForSeconds(reactionTime);

        if(hitFriend && hitWall) {
           if(hitWall.distance > hitFriend.distance) {
               if(!_isShot) {
                    _isShot = true;
                    ray.positionCount = 2;
                    ray.SetPosition(0, transform.position);
                    ray.SetPosition(1, hitFriend.point);
                    Destroy(hitFriend.transform.gameObject);
                    StartCoroutine(durationShot());
                    StartCoroutine(isShot());
               }
           }
       } 
       if(hitFriend && !hitWall) {
            if(!_isShot) {
                    _isShot = true;
                    ray.positionCount = 2;
                    ray.SetPosition(0, transform.position);
                    ray.SetPosition(1, hitFriend.point);
                    Destroy(hitFriend.transform.gameObject);
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
