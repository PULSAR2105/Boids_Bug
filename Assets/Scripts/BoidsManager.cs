using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidsManager : MonoBehaviour
{
    public Transform prefab;
    public GameObject goal;
    GameObject[] boids;
    public float spawnSpeed;

    public Sprite[] sprites;


    public int numberEntities;
    public int boidBonus = 0;
    float x, y;

    void Start() {
        goal = GameObject.Find("Goal");
        StartCoroutine(SpawnBoids(boidBonus));
        boidBonus = 0;
    }

    void FixedUpdate(){
        if(boidBonus > 0){
            StartCoroutine(SpawnBoids(boidBonus));
            boidBonus = 0;
        }
    }

    IEnumerator SpawnBoids(int _numberEntities) {
        for (int i = 0; i < _numberEntities; i++) {
            Instantiate(prefab, new Vector3(goal.transform.position.x, goal.transform.position.y, 0), Random.rotation);
            numberEntities++;
            yield return new WaitForSeconds(spawnSpeed);
        }
    }
}
