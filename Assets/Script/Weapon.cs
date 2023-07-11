using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float PlayerDamage = 10;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyInfo enemyHealth = collision.gameObject.GetComponent<EnemyInfo>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(10); // Replace 10 with the amount of damage you want to deal
            }
        }
    }
}
