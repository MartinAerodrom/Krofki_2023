using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentMovement : MonoBehaviour
{
    float movespeed = 2f;
    Transform target;
    Vector2 moveDir;
    Rigidbody2D rb;
    public float damage;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    void Start()
    {
        target = GameObject.Find("Player").transform;
     
    }

 


    void Update()
    {
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
          
            moveDir = direction;
        }
    }

    private void FixedUpdate()
    {
        if (target)
        {
            rb.velocity = new Vector2(moveDir.x, moveDir.y) * movespeed;
        }
    }
    
}
