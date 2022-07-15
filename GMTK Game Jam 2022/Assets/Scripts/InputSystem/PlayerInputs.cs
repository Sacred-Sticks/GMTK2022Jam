using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    [SerializeField] private InputActionAsset playerInputs;
    [Space]
    [SerializeField] private string actionMapStr;
    [SerializeField] private string movementActionStr;
    [SerializeField] private string firingActionStr;
    [SerializeField] private string aimingActionStr;

    private InputAction movementAction;
    private InputAction firingAction;
    private InputAction aimingAction;

    private Vector2 movementValue;
    private bool firingValue;
    private Vector2 aimingValue;

    private void Awake()
    {
        var actionMap = playerInputs.FindActionMap(actionMapStr);

        movementAction = actionMap.FindAction(movementActionStr);
        movementAction.performed += OnMovementChanged;
        movementAction.canceled += OnMovementChanged;
        movementAction.Enable();

        firingAction = actionMap.FindAction(firingActionStr);
        firingAction.performed += OnFiringChanged;
        firingAction.canceled += OnFiringChanged;
        firingAction.Enable();

        aimingAction = actionMap.FindAction(aimingActionStr);
        aimingAction.performed += OnAimingChanged;
        aimingAction.canceled += OnAimingChanged;
        aimingAction.Enable();
    }

    private void OnMovementChanged(InputAction.CallbackContext context)
    {
        movementValue = context.ReadValue<Vector2>();
    }

    private void OnFiringChanged(InputAction.CallbackContext context)
    {
        firingValue = context.ReadValue<bool>();
    }

    private void OnAimingChanged(InputAction.CallbackContext context)
    {
        aimingValue = context.ReadValue<Vector2>();
    }

    public Vector2 GetMovement()
    {
        return movementValue;
    }

    public bool GetFiring()
    {
        return firingValue;
    }

    public Vector2 GetAim()
    {
        return aimingValue;
    }
}
