using Plane.Spawners;
using UnityEngine;

namespace Plane
{
    public class PlaneTouch : MonoBehaviour
    {
        [SerializeField] private CollectableItem _collectableItem;
        
        public delegate void ItemTouchedHandler();
        public static event ItemTouchedHandler OnItemTouched;
        
        public void OnPlanePress()
        {
            OnItemTouched?.Invoke();
            _collectableItem.Collect();
        }
    }
}