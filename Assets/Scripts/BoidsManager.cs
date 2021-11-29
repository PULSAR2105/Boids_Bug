using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoidsManager : MonoBehaviour
{
    public Text boidsCountText;

    public Transform prefab;
    public GameObject goal;
    GameObject[] boids;
    public float spawnSpeed;
    public float boidSpawnSpeed;

    public int numberEntities;
    public int boidBonus = 0;

    void Start() {
        goal = GameObject.Find("Goal");
        StartCoroutine(AddBoids(boidBonus, spawnSpeed));
        boidBonus = 0;
    }

    void FixedUpdate(){
        boids = GameObject.FindGameObjectsWithTag("Boid");
        if(boids.Length < numberEntities) {
            StartCoroutine(AddBoids(numberEntities - boids.Length, boidSpawnSpeed));
        }
        
        if(boidBonus > 0){
            if(goal != null) {
                StartCoroutine(AddBoids(boidBonus, boidSpawnSpeed));
                boidBonus = 0;
            }
        }
    }

    public void DestroyBoid(GameObject boid){
        Destroy(boid);
        numberEntities--;
        boidsCountText.text = numberEntities.ToString();
    }

    IEnumerator AddBoids(int _numberEntities, float _spawnSpeed) {
        for (int i = 0; i < _numberEntities; i++) {
            Instantiate(prefab, new Vector3(goal.transform.position.x, goal.transform.position.y, 0), Random.rotation);
            numberEntities++;
            boidsCountText.text = numberEntities.ToString();
            yield return new WaitForSeconds(_spawnSpeed);
        }
    }
}
