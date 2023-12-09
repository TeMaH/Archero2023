using UnityEngine;
using UnityEngine.InputSystem;

public class BasePlayer : MonoBehaviour
{
    private PlayerInput input;

    private void Start()
    {
        input = new PlayerInput();
        input.Enable();
        input.Player.Move.performed += Move_performed;
    }

    private void Move_performed(InputAction.CallbackContext context)
    {
        Debug.Log("Move");//todo call move method
    }
}
