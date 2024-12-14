using UnityEngine;

namespace UI
{
    public class UILoaderRotate : MonoBehaviour
    {
        [SerializeField] float speedRotate;

        void Update()
        {
            transform.Rotate(0, 0, -speedRotate * Time.deltaTime);
        }
    }
}