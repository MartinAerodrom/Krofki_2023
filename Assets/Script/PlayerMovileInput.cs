using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovileInput : MonoBehaviour
{
    public Vector2 MovementVector {get; private set;}

    public event Action OnAttack;
    public event Action OnJumpPressed;
    public event Action OnJumpRelesed;
    public event Action<Vector2> OnMovement;
    public event Action OnWeaponChange;

    [SerializeField]
    private MobileJoystick joystick;




    void Start()
    {
        joystick.OnMove += Move;

    }

   private void Move(Vector2 input)
   {
    MovementVector = input;
    OnMovement?.Invoke(MovementVector);
   }

}

