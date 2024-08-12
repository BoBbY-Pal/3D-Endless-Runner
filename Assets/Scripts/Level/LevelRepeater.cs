using UnityEngine;

namespace Level
{
    public class LevelRepeater : MonoBehaviour {

        public Level nextStreet;
        public Level currentStreet;
    
        private Level prevStreet;


        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Start"))
            {
                if (prevStreet != null)
                {
                    prevStreet.gameObject.SetActive(false);
                    nextStreet = prevStreet;
                }
            }
            else if (other.CompareTag("Middle"))
            {
                SpawnLevel();
            }
        }
        void SpawnLevel()
        {
            prevStreet = currentStreet;
            nextStreet.transform.position = currentStreet.endPoint.position;
            nextStreet.gameObject.SetActive(true);
            currentStreet = nextStreet;

        }
    }
}
