using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public class DontDestroyOnLoad : MonoBehaviour
    {
        private static Dictionary<string, DontDestroyOnLoad> instances = new Dictionary<string, DontDestroyOnLoad>();
        private void Awake()
        {
            // If there's no instance with this object's name, make this the instance and make it persistent
            if (!instances.ContainsKey(gameObject.name))
            {
                DontDestroyOnLoad(gameObject);
                instances[gameObject.name] = this;
            }
            else
            {
                // If there's already an instance with this object's name, and it's not this one, destroy this
                if (instances[gameObject.name] != this)
                {
                    Destroy(gameObject);
                    return;
                }
            }
        }
    }
}
