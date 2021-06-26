using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputActionHandler : MonoBehaviour
{
    public static InputActionHandler instance;
    private PlayerInput _PlayerInput;
    private Action<InputAction.CallbackContext> moveup;
    public static Action<Vector2> MoveDirectionBroadcast;
    public float movementThreshold;
    void Awake()
    {
        SetupInput();
    }

    public void Start()
    {
        if (_PlayerInput == null)
        {
            _PlayerInput = GetComponent<PlayerInput>();
        }
        _PlayerInput.onActionTriggered += HandleAction;
    }
    
    void HandleAction(InputAction.CallbackContext callbackContext)
    {
        //Debug.Log($"Got a callback. Action name was {callbackContext.action.name}");
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
    }

    public Action<InputAction.CallbackContext> Moveup
    {
        get => moveup;
        set => moveup = value;
    }
}
