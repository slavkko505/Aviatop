using UnityEngine;
using UnityEngine.UI;

namespace Plane.TileGame
{
    public class TileUI : MonoBehaviour
    {
        [SerializeField] private Image sprite;
        private int currentRotate = 90;

        private bool isCorrect;
        
        public delegate void CardPlaced();
        public static event CardPlaced OnCardPlaced;
        public void RotateTile()
        {
            if(isCorrect)
                return;
            
            transform.rotation = Quaternion.Euler(0, 0, (int)transform.rotation.z + currentRotate);
            currentRotate += 90;
            if (currentRotate >= 360)
            {
                currentRotate -= 360;
            }
            
            CheckOrientation();
        }
        
        public void CheckOrientation()
        {
            Vector3 rotation = transform.rotation.eulerAngles;

            if (Mathf.Approximately(rotation.z, 0f))
            {
                isCorrect = true;
                OnCardPlaced?.Invoke();
            }
        }

        public void SetSprite(Sprite _sprite)
        {
            sprite.sprite = _sprite;
        }
    }
}