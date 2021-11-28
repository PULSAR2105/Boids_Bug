using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthGun : MonoBehaviour
{
    public BoidsManager manager;

    public float health = 100.0f;
    public float attackEnemy;
    public float attackRangeEnemy;
    public int destructionBonus;

    float dist;

    GameObject[] enemies;
    public Sprite[] sprites;

    void Start() {
        
    }

    void FixedUpdate() {
        enemies = GameObject.FindGameObjectsWithTag("Boid");

        foreach (GameObject enemy in enemies) {
            dist = Vector3.Distance(enemy.transform.position, transform.position);
            if (dist < attackRangeEnemy)
            {
                health -= attackEnemy;
                
                transform.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
            }
        }

        if (health <= 0) {
            Destroy(gameObject);
            manager.boidBonus = destructionBonus;
        }
    }
}
