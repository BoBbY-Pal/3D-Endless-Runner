using UnityEngine;
using UnityEngine.InputSystem;
using Utils;

[DefaultExecutionOrder(-1)]
public class InputManager : Singleton<InputManager>
{
    private PlayerControls playerControls;

    #region Events
    public delegate void StartTouchDelegate(Vector2 position, float time);
    public event StartTouchDelegate OnStartTouch;

    public delegate void EndTouchDelegate(Vector2 position, float time);
    public event EndTouchDelegate OnEndTouch;
    #endregion

    [HideInInspector] public Camera mainCamera;
    private void Awake()
    {
        playerControls = new PlayerControls();
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        playerControls.Enable();
        SubscribeToEvents();
    }

    private void OnDisable()
    {
        playerControls.Disable();
        UnsubscribeFromEvents();
    }

    private void SubscribeToEvents()
    {
        playerControls.Touch.PrimaryContact.started += StartTouch;
        playerControls.Touch.PrimaryContact.canceled += EndTouch;
    }

    private void UnsubscribeFromEvents()
    {
        playerControls.Touch.PrimaryContact.started -= StartTouch;
        playerControls.Touch.PrimaryContact.canceled -= EndTouch;
    }

    private void StartTouch(InputAction.CallbackContext context)
    {
            OnStartTouch?.Invoke(UtilityClass.ScreenToWorld(mainCamera, playerControls.Touch.PrimaryPosition.ReadValue<Vector2>()), (float) context.startTime);
        // Call OnStartTouch event
        if (OnStartTouch != null)
        {
        }
    }

    private void EndTouch(InputAction.CallbackContext context)
    {
            OnEndTouch?.Invoke(UtilityClass.ScreenToWorld(mainCamera, playerControls.Touch.PrimaryPosition.ReadValue<Vector2>()), (float) context.time);
        // Call OnEndTouch event
        if (OnEndTouch != null)
        {
        }
    }
}