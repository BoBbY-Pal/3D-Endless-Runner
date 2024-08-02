using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float laneDistance = 2.5f; // Distance between lanes
    private int targetLane = 1; // Start in the middle lane
    private Vector2 swipeDirection;

    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        if (Keyboard.current.leftArrowKey.wasPressedThisFrame || swipeDirection.x < 0)
            targetLane = Mathf.Max(targetLane - 1, 0);
        if (Keyboard.current.rightArrowKey.wasPressedThisFrame || swipeDirection.x > 0)
            targetLane = Mathf.Min(targetLane + 1, 2);

        Vector3 targetPosition = new Vector3((targetLane - 1) * laneDistance, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    public void OnSwipe(InputAction.CallbackContext context)
    {
        if (context.performed)
            swipeDirection = context.ReadValue<Vector2>();
    }
}