using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthMac : MonoBehaviour
{
    public float health;
    public float attackEnemy;
    public float attackRangeEnemy;

    public string sceneName;

    float dist;

    GameObject[] enemies;
    public Sprite[] sprites;

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
            SceneManager.LoadScene(sceneName);
        }
    }
}
