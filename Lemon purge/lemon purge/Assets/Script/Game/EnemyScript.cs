﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public int health = 5;
    public GameObject bullet;



    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }

    

    private void OnCollisionEnter(Collision other)
    {
        //Debug.Log("Collision");
        if (other.gameObject == this.bullet)
        {
            Debug.Log("Hit");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        this.health--;
        Debug.Log(this.health);
    }
}
