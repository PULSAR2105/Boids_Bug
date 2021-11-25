using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessingShadow : MonoBehaviour
{

    public GameObject[] enemies;
    public GameObject[] rays;
    RaycastHit2D hitEnemy;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemies");
        rays = GameObject.FindGameObjectsWithTag("Rays");
        for (int i = 0; i < enemies.Length; i++)
        {
            hitEnemy = Physics2D.Raycast(transform.position, enemies[i].transform.position - transform.position, 15);
            
            if (hitEnemy) {

                if(hitEnemy.collider.gameObject.tag == "Enemies") {
                    enemies[i].GetComponent<Renderer>().enabled = true;
                    //rays[i].GetComponent<Renderer>().enabled = true;
                }
                else {
                    enemies[i].GetComponent<Renderer>().enabled = false;
                    //rays[i].GetComponent<Renderer>().enabled = false;
                }
            }
        }
    }
}
