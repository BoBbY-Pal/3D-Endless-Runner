using System;
using Scriptable_Objects;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Level
{
    public class Level: MonoBehaviour
    {
        public Transform startPoint;
        public Transform midPoint;
        public Transform endPoint;

        public Collectible collectible;
        [SerializeField] private CollectiblesData _collectiblesData;
        private void Awake()
        {
            _collectiblesData = (CollectiblesData) Resources.Load("CollectibleData");
        }

        private void OnEnable()
        {
            int randomNum = Random.Range(0, _collectiblesData.collectibleDatas.Length);
            Debug.Log(randomNum);
            collectible.Init(_collectiblesData.collectibleDatas[randomNum]);
        }
    }
}