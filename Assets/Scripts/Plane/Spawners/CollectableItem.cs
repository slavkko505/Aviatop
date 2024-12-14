using UnityEngine;

namespace Plane.Spawners
{
    public class CollectableItem : MonoBehaviour
    {
        [SerializeField] private GameObject boomImg;
        private float _fallSpeed;
        private ObjectPool _objectPool;

        private GameObject boomEffect;
        public void Initialize(ObjectPool objectPool)
        {
            _objectPool = objectPool;
        }
        
        private void Update()
        {
            transform.position += Vector3.down * _fallSpeed * Time.deltaTime;

            if (transform.position.y < -Camera.main.orthographicSize - 1f)
            {
                Collect();
            }
        }
        
        public void Collect()
        {
            _objectPool.ReturnItem(this);
        }
        
        public void SetFallSpeed(float fallSpeed)
        {
            _fallSpeed = fallSpeed;
        }

        public void SetBoomEffect()
        {
            if (boomImg != null)
            {
                boomEffect = Instantiate(boomImg, transform.position, Quaternion.identity);
                boomEffect.transform.position = transform.position;
                boomEffect.transform.parent = null;
                boomEffect.SetActive(true);
                boomEffect.GetComponent<Animator>().Play("IdleBoom");
            }
        }
    }
}