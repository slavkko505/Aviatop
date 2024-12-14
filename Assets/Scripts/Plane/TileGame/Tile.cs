using UnityEngine;

namespace Plane.TileGame
{
    [System.Serializable]
    public class Tile
    {
        [SerializeField] public Sprite[] tileImg;
        
        public Sprite GetTile(int index)
        {
            if(index <= tileImg.Length)
                return tileImg[index];
            
            return null;
        }
        
        
    }
}