using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject inventoryScreen;

    void Update()
    {
        // Keyboard controls
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        // Move the character
        transform.position += new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * moveSpeed;

        // Open inventory screen
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }

    void ToggleInventory()
    {
        // Toggle the visibility of the inventory screen
        inventoryScreen.SetActive(!inventoryScreen.activeSelf);
    }
}

