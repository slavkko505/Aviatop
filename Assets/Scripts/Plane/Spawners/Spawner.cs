using System.Collections;
using UnityEngine;

namespace Plane.Spawners
{
    public class Spawner : MonoBehaviour
    {
        [Header("Random Pos")] 
        [SerializeField] private bool random;
        [SerializeField] private Transform Pos1;
        [SerializeField] private Transform Pos2;
        
        [Header("Controlls")] 
        [SerializeField] private ObjectPool objectPool; 
        [SerializeField] private float initialSpawnTime = 2f;
        [SerializeField] private float spawnAcceleration = 0.1f;
        [SerializeField] private float maxFallSpeed = 10f; 
        [SerializeField] private float fallSpeedIncrement = 0.5f; 
        [SerializeField] private float fallSpeed = 2f; 

        private float spawnTime; 
        private float screenWidth;
        private int spawnCount = 0;
        
        private void Start()
        {
            spawnTime = initialSpawnTime;
            screenWidth = Camera.main.orthographicSize * Camera.main.aspect;
            StartCoroutine(SpawnLoop());
        }

        private IEnumerator SpawnLoop()
        {
            while (true)
            {
                SpawnItem();
                yield return new WaitForSeconds(spawnTime);
                AccelerateSpawning();
            }
        }

        private void SpawnItem()
        {
            CollectableItem item = objectPool.GetItem();

            if (item != null)
            {
                Vector3 spawnPosition = new Vector3();
                if (!random)
                {
                    float randomX = Random.Range(-screenWidth+1, screenWidth-1);
                    spawnPosition = new Vector3(randomX, transform.position.y, 0);
                }
                else
                {
                    spawnPosition = RandomPos();
                }
                    
                item.Initialize(objectPool);
                item.transform.position = spawnPosition;
                item.transform.rotation = Quaternion.identity;
                
                item.SetFallSpeed(fallSpeed);
            }
            
            spawnCount++;
            if (spawnCount % 10 == 0)
            {
                AddFallSpeed();
            }
        }

        private Vector3 RandomPos()
        {
            int randomValue = Random.Range(1, 3);

            switch (randomValue)
            {
                case 1:
                    return Pos1.position;
                case 2:
                    return Pos2.position;
            }

            return Pos2.position;
        }

        private void AccelerateSpawning()
        {
            spawnTime = Mathf.Max(0.5f, spawnTime - spawnAcceleration);
        }

        public void AddFallSpeed()
        {
            fallSpeed = Mathf.Min(maxFallSpeed, fallSpeed + fallSpeedIncrement);
        }
    }
}