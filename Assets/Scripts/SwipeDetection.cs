using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    private Vector2 startPosition;
    private float startTime;
    private Vector2 endPosition;
    private float endTime;

    [SerializeField] private float minimumDistance = 0.2f; // Min distance for swipe to consider.
    [SerializeField] private float maximumTime = 1f;       // Max time for the swipe to consider.
    [SerializeField] private PlayerMovement _playerMovement;
    private void OnEnable()
    {
        SubscribeToEvents();
    }

    private void OnDisable()
    {
        UnsubscribeFromEvents();
    }
    
    private void SubscribeToEvents()
    {
        InputManager.Instance.OnStartTouch += SwipeStart;
        InputManager.Instance.OnEndTouch += SwipeEnd;
    }

    private void UnsubscribeFromEvents()
    {
        InputManager.Instance.OnStartTouch -= SwipeStart;
        InputManager.Instance.OnEndTouch -= SwipeEnd;
    }

    private void SwipeStart(Vector2 position, float time)
    {
        startPosition = position;
        startTime = time;
    }

    private void SwipeEnd(Vector2 position, float time)
    {
        endPosition = position;
        endTime = time;

        DetectSwipe();
    }

    private void DetectSwipe()
    {
        if (Vector3.Distance(startPosition, endPosition) >= minimumDistance && endTime - startTime <= maximumTime)
        {
            Debug.DrawRay(startPosition, endPosition - startPosition, Color.red, 5f);

            Vector2 direction = endPosition - startPosition;
            direction = direction.normalized;

            SwipeDirection(direction);
        }
    }

    private void SwipeDirection(Vector2 direction)
    {
        if (Vector2.Dot(direction, Vector2.up) > 0.9f)
        {
            Debug.Log("Swipe Up");
        }
        else if (Vector2.Dot(direction, Vector2.down) > 0.9f)
        {
            Debug.Log("Swipe Down");
        }
        else if (Vector2.Dot(direction, Vector2.left) > 0.9f)
        {
            _playerMovement?.MoveLeft();
        }
        else if (Vector2.Dot(direction, Vector2.right) > 0.9f)
        {
           _playerMovement?.MoveRight();
        }
    }
}