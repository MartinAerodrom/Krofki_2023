using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject inventoryScreen;
    public GameObject Weapon;
    Vector3 scaleChangeL = new Vector3(-1,1,1);
    Vector3 scaleChangeR = new Vector3(1,1,1);
   public Vector3 rotationChange = new Vector3(0,70,0);
    public Animator animator;

    void Update()
    {
        // Keyboard controls
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
         float vertical = Input.GetAxis("Vertical");
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
        
        // Move the character
        transform.position += new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * moveSpeed;

        // If the input is negative, the player is moving left
        if (horizontal < 0)
        {
            animator.SetTrigger("Left");
            Weapon.transform.localScale = scaleChangeL;
            Weapon.transform.rotation = Quaternion.Euler(0,0,0);
        }
           else if (horizontal > 0)
        {
            animator.ResetTrigger("Left");
            Weapon.transform.localScale = scaleChangeR;
            Weapon.transform.rotation = Quaternion.Euler(0,0,0);
           
        }
         else if (horizontal == 0)
        {
            animator.ResetTrigger("Left");
            animator.ResetTrigger("Right");
            Weapon.transform.rotation = Quaternion.Euler(0,70,0);
        }
        // Open inventory screen
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
          if (Input.GetMouseButtonDown(0))
        {
            SwingSword();
        }
    }

    void ToggleInventory()
    {
        // Toggle the visibility of the inventory screen
        inventoryScreen.SetActive(!inventoryScreen.activeSelf);
    }
    void SwingSword()
    {
        animator.SetTrigger("Swing");
    }
}


