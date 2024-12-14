using UnityEngine;

namespace Plane
{
    public class Plane : MonoBehaviour
    {
        [SerializeField] private float speed;

        private float normalSpeed;
        private float screenWidthInWorldUnits;
        private void Start()
        {
            normalSpeed = speed;
            speed = 0;
            
            float screenHalfWidthInUnits = Camera.main.aspect * Camera.main.orthographicSize;
            screenWidthInWorldUnits = screenHalfWidthInUnits - (transform.localScale.x / 2); 
        }

        private void Update()
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            ClampedX();
        }

        private void ClampedX()
        {
            float clampedX = Mathf.Clamp(transform.position.x, -screenWidthInWorldUnits, screenWidthInWorldUnits);
            transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
        }
        
        public void Stop()
        {
            speed = 0;
        }
        
        public void MoveRight()
        {
            speed = normalSpeed;
        }

        public void MoveLeft()
        {
            speed = -normalSpeed;
        }
        
    }
}