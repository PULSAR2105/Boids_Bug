using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 position = Input.mousePosition;

        position.z = 0;
        transform.localPosition = position;
    }
}
