using System.Collections;
using Enums;
using Scriptable_Objects;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    
    public CollectibleType collectibleType;

    public float speedBoostDuration = 5f; // Duration for speed boost (blue collectible)
    public float timeToAdd = 10f; // Time to add (green collectible)
    [SerializeField] private MeshRenderer _meshRenderer;
    
    
    public void Init(CollectiblesData.CollectibleTypesData collectibleData)
    {
        collectibleType = collectibleData.CollectibleType;
        _meshRenderer.material = collectibleData.collectibleMaterial;
        switch (collectibleType)
        {
            case CollectibleType.Blue:
                speedBoostDuration = collectibleData.benefitValue;
                break;
            case CollectibleType.Green:
                timeToAdd = collectibleData.benefitValue;
                break;
        }

        int randomValue = Random.Range(0, 4);
        switch (randomValue)
        {
            case 0:
                gameObject.transform.localPosition = new Vector3(-3, 0, 0);
                break;
            case 1:
                gameObject.transform.localPosition = new Vector3(0, 0, 0);
                break;
            case 2:
                gameObject.transform.localPosition = new Vector3(3, 0, 0);
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
        }
    }

    private IEnumerator BoostSpeed(PlayerMovement player)
    {
        player.BoostSpeed(2);
        
        yield return new WaitForSeconds(speedBoostDuration);

        player.RestoreSpeed();
    }
}