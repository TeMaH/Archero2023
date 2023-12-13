using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JoystickMovement : MonoBehaviour
{
    [SerializeField] Joystick joystick;

    void JoysticMove(float inputHorizontal, float inputVertical)
    {
        inputHorizontal = joystick.Horizontal;
        inputVertical = joystick.Vertical;
    }
}
