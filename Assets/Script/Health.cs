using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
      // The current health value
    public float currentHealth;

    // The maximum health value
    public float maxHealth;

    // The event that is invoked when the health changes
    public event System.Action<float, float> OnHealthChanged;

    // Start is called before the first frame update
    void Start()
    {
        // Set the current health to the max health
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(currentHealth);
    }

    // A method that increases the health by a certain amount
    public void IncreaseHealth(float amount)
    {
        // Add the amount to the current health
        currentHealth += amount;

        // Clamp the current health between zero and max health
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        // Invoke the event with the current and max health as parameters
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }

    // A method that decreases the health by a certain amount
    public void DecreaseHealth(float amount)
    {
        // Subtract the amount from the current health
        currentHealth -= amount;

        // Clamp the current health between zero and max health
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        // Invoke the event with the current and max health as parameters
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(20);
        }
    }
       void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }
     void Die()
    {
        // Game Over
        Debug.Log("Game Over");
        gameObject.SetActive(false);
    }
}

