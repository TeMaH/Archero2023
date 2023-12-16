using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JoystickMovement : MonoBehaviour
{
    [SerializeField] Joystick joystick;
    [SerializeField] MovementComponent movementComponent;

    private void Update()
    {

        float inputHorizontal = joystick.Horizontal;
        float inputVertical = joystick.Vertical;

        Vector3 movement = new Vector3(inputHorizontal, 0, inputVertical);
        movementComponent.Move(movement);
    }
}
