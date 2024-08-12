using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 2;
    [SerializeField] private  float horizontalSpeed = 3;

    private float xMovement;

    void Update()
    {
        transform.Translate(Vector3.forward * (Time.deltaTime * playerSpeed), Space.World);
        HorizontalMovement();
    }

    private void HorizontalMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position,
            new Vector3(xMovement, transform.position.y, transform.position.z), Time.deltaTime * horizontalSpeed);
    }
    

    public void MoveRight()
    {
        if (xMovement == -3)
        {
            xMovement = 0;
        }
        else   if (xMovement == 0)
        {
            xMovement = 3;
        }
        
    }
    public void MoveLeft()
    {
        if (xMovement == 3)
        {
            xMovement = 0;
        }
        else   if (xMovement == 0)
        {
            xMovement = -3;
        }
        
    }

    public void RestoreSpeed()
    {
        // Revert to original speed
        playerSpeed = 25; 
        horizontalSpeed = 27;
    }

    public void BoostSpeed(float multiplier)
    {
        // Double the player's speed
        playerSpeed *= multiplier; 
        horizontalSpeed *= multiplier;
    }
}
