using System;
using System.Collections;
using System.Security;
using Enums;
using Interfaces;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    
    public CollectibleType collectibleType;

    public float speedBoostDuration = 5f; // Duration for speed boost (blue collectible)
    public float timeToAdd = 10f; // Time to add (green collectible)
    [SerializeField] private MeshRenderer _meshRenderer;
    
    
    public void Init(CollectibleType type, Material material, float benefitValue)
    {
        collectibleType = type;
        _meshRenderer.material = material;
        switch (type)
        {
            case CollectibleType.Blue:
                speedBoostDuration = benefitValue;
                break;
            case CollectibleType.Green:
                timeToAdd = benefitValue;
                break;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        if (player != null)
        {
            switch (collectibleType)
            {
                case CollectibleType.Blue:
                    StartCoroutine(BoostSpeed(player));
                    Debug.Log("Speed boosted");
                    break;

                case CollectibleType.Green:
                    Debug.Log("Time added");
                    TimerController.Instance.AddTime(timeToAdd);
                    break;
            }

            // Destroy the collectible after being picked up
            Destroy(gameObject);
        }
    }

    private IEnumerator BoostSpeed(PlayerMovement player)
    {
        player.BoostSpeed(2);
        
        yield return new WaitForSeconds(speedBoostDuration);

        player.RestoreSpeed();
    }
}