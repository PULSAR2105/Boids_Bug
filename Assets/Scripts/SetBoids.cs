using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBoids : MonoBehaviour
{
    public Transform prefab;
    public GameObject goal;
    public int numberEntites = 10;
    float x, y;

    void Start() {
        goal = GameObject.Find("Goal");

        for (int i = 0; i < numberEntites; i++) {
            Instantiate(prefab, new Vector3(goal.transform.position.x, goal.transform.position.y, 0), Random.rotation);
        }
    }

    void Update(){
        
    }
}
