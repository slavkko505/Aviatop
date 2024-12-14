using System.Collections.Generic;
using UnityEngine;

namespace Plane.Spawners
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private CollectableItem[] prefab;
        [SerializeField] private int poolSize = 10;

        private Queue<CollectableItem> pool = new Queue<CollectableItem>();

        private void Start()
        {
            for (int i = 0; i < poolSize; i++)
            {
                CollectableItem item = Instantiate(prefab[Random.Range(0, prefab.Length)], transform);
                item.gameObject.SetActive(false);
                pool.Enqueue(item);
            }
        }

        public CollectableItem GetItem()
        {
            if (pool.Count > 0)
            {
                CollectableItem item = pool.Dequeue();
                item.gameObject.SetActive(true);
                return item;
            }
            else
            {
                return null;
            }
        }

        public void ReturnItem(CollectableItem item)
        {
            item.gameObject.SetActive(false);
            pool.Enqueue(item);
        }
    }
}