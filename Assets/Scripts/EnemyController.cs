﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public int health;
    public GameObject explosion;

    public float playerRange = 10f;

    public Rigidbody2D rb;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, PlayerController.instance.transform.position)< playerRange)
        {
            Vector3 playerDiection = PlayerController.instance.transform.position - transform.position;
            rb.velocity = playerDiection.normalized * moveSpeed;

        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void takeDamage()
    {
        this.health--;
        if (this.health <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }
}