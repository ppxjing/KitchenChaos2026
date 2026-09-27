using System;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteractAction;

    private GameControl gameControl;

    private void Awake()
    {
        InitializeInput();
    }

    private void OnEnable()
    {
        InitializeInput();
        gameControl.Player.Enable();
    }

    private void OnDisable()
    {
        if (gameControl != null)
        {
            gameControl.Player.Disable();
        }
    }

    private void OnDestroy()
    {
        if (gameControl != null)
        {
            gameControl.Player.Interact.performed -= Interact_Performed;
            gameControl.Dispose();
            gameControl = null;
        }
    }

    private void InitializeInput()
    {
        if (gameControl != null)
        {
            return;
        }

        gameControl = new GameControl();
        gameControl.Player.Interact.performed += Interact_Performed;
    }

    private void Interact_Performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector3 GetMovementDirectionVector()
    {
        InitializeInput();
        gameControl.Player.Enable();

        Vector2 inputVector2 = gameControl.Player.Move.ReadValue<Vector2>();
        Vector3 direction = new Vector3(inputVector2.x, 0, inputVector2.y);

        return direction.normalized;
    }
}

