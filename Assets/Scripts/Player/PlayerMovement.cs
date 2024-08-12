using System;
using Interfaces;
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
        // if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        // {
        //     transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed);
        // }
        // if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        // {
        //     transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed * -1);
        // }
    }

    private void HorizontalMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position,
            new Vector3(xMovement, transform.position.y, transform.position.z), Time.deltaTime * horizontalSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        ICollectible collectible = other.GetComponent<ICollectible>();
        if (collectible != null)
        {
            collectible.Collect();
        }
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
        playerSpeed /= 2; 
        horizontalSpeed /= 2;
    }

    public void BoostSpeed(float multiplier)
    {
        // Double the player's speed
        playerSpeed *= multiplier; 
        horizontalSpeed *= multiplier;
    }
}
