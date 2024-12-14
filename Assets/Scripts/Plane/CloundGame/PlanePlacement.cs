using System.Collections;
using UnityEngine;

namespace Plane.CloundGame
{
    public class PlanePlacement : MonoBehaviour
    {
        [SerializeField] private PlaneTile[] _planeTile;
        
        private int index = 0;
        
        private void Start()
        {
            SetAllPlacement();
            PlaceFirstLvl();
        }

        private void PlaceFirstLvl()
        {
            _planeTile[index].gameObject.SetActive(true);
        }

        public void PlaceNextTile()
        {
            StartCoroutine(NextTile());
        }
        
        private void SetAllPlacement()
        {
            foreach (var tile in _planeTile)
            {
                tile.Initialized(this);
                tile.gameObject.SetActive(false);
            }
        }

        private IEnumerator NextTile()
        {
            yield return new WaitForSeconds(1f);
            
            _planeTile[index].Reset();
            _planeTile[index].gameObject.SetActive(false);
            
            index += 1;
            if (index >= _planeTile.Length)
                index = 0;
            
            _planeTile[index].gameObject.SetActive(true);
        }
    }
    
}
