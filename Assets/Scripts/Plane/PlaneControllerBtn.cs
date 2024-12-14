using System;
using UnityEngine;

namespace Plane
{
    public class PlaneControllerBtn : MonoBehaviour
    {
        [SerializeField] private Transform _pointSpawn;
        [SerializeField] private Plane plane;

        private Plane _plane;

        private void Start()
        {
            SpawnPlayer(plane);
        }

        public void SpawnPlayer(Plane currrentPlane)
        {
            _plane = Instantiate(currrentPlane, _pointSpawn.position, Quaternion.identity);
        }

        public void LeftBtnPress()
        {
            if(_plane != null)
                _plane.MoveLeft();
        }
        
        public void RightBtnPress()
        {
            if(_plane != null)
                _plane.MoveRight();
        }

        public void StopFlight()
        {
            if(_plane != null)
                _plane.Stop();
        }
    }
}
