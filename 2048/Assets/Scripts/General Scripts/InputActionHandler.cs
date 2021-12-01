using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputActionHandler : MonoBehaviour
{
    public static InputActionHandler instance;
    private PlayerInput _playerInput;

    public static Action<Vector2> MoveDirectionBroadcast;
    
    void Awake()
    {
        SetupInput();
    }

    void HandleAction(InputAction.CallbackContext callbackContext)
    {
        if(callbackContext.action.name == "Move")
            if (callbackContext.action.triggered)
                MoveDirectionBroadcast.Invoke(callbackContext.action.ReadValue<Vector2>());
    }


    void SetupInput()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        if (_playerInput == null)
        {
            _playerInput = GetComponent<PlayerInput>();
        }
        _playerInput.onActionTriggered += HandleAction;
    }
}
