using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
   public Image healthBar;
    public Health playerHealth;

    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
         healthBar.fillAmount = (float)playerHealth.currentHealth / playerHealth.maxHealth;
    }

  
}
