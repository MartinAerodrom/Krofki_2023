using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar_Enemy : MonoBehaviour
{
   public Image healthBar;
   public EnemyInfo enemyHealth;

    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
         healthBar.fillAmount = (float)enemyHealth.currentHealth / enemyHealth.maxHealth;
    }

  
}
