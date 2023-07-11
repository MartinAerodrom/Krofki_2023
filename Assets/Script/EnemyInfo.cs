using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyInfo: MonoBehaviour
{
    float movespeed = 2f;
    Transform target;
    Vector2 moveDir;
    Rigidbody2D rb;


    public float damage;
    public int maxHealth = 50;
    public int currentHealth;

    public SpriteRenderer spriteRenderer;
    public Color hitColor = Color.red;
    public float hitColorDuration = 0.5f;

    private Color originalColor;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    void Start()
    {
        target = GameObject.Find("Player").transform;
        currentHealth = maxHealth;
        originalColor = spriteRenderer.color;

    }

    void Update()
    {
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
          
            moveDir = direction;
        }

        Debug.Log(currentHealth);


    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)

        {
            Die();
        }
        else
        {
            StartCoroutine(ChangeColor());
            
        }
    }

    IEnumerator ChangeColor()
    {
        spriteRenderer.color = hitColor;
        yield return new WaitForSeconds(hitColorDuration);
        spriteRenderer.color = originalColor;
    }
    void Die()
    {
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        if (target)
        {
            rb.velocity = new Vector2(moveDir.x, moveDir.y) * movespeed;
        }
    }
    
}
