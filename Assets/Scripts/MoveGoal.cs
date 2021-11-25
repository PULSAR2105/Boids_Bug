using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGoal : MonoBehaviour
{
    public GameObject lightGoal;

    void Start() {

    }

    void FixedUpdate() {
        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        position.z = 0;
        gameObject.transform.localPosition = position;
        lightGoal.transform.localPosition = position;
    }
}
