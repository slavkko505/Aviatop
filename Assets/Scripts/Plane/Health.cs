using Plane.Spawners;
using UnityEngine;

namespace Plane
{
    public class Health : MonoBehaviour
    {
        public delegate void ItemTouchedHandler();
        public static event ItemTouchedHandler OnItemTouched;
        public static event ItemTouchedHandler OnCoinTouched;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            var item = other.GetComponent<CollectableItem>();
            
            if (other.CompareTag("Coin"))
            {
                OnCoinTouched?.Invoke();
            }
            else
            {
                OnItemTouched?.Invoke();
                item.SetBoomEffect();
            }
            
            item.Collect();
            
        }
    }
}