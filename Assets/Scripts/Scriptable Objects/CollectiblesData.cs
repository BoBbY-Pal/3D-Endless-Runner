using System;
using Enums;
using UnityEngine;

namespace Scriptable_Objects
{
    [CreateAssetMenu(menuName = "Scriptable Objects/ CollectibleData", fileName = "New CollectibleData")]
    public class CollectiblesData : ScriptableObject
    {
        public CollectibleTypesData[] collectibleDatas;
        
        [Serializable]
        public struct CollectibleTypesData
        {
            public CollectibleType CollectibleType;
            public Material collectibleMaterial;
            public float benefitValue;
        }
    }
}