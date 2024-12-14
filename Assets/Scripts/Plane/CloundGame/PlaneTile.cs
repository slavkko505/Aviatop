using UnityEngine;

namespace Plane.CloundGame
{
    public class PlaneTile : MonoBehaviour
    {
        [SerializeField] private PlaneTileChild[] planeChild;
        
        private PlanePlacement _planePlacement;

        public delegate void PlaneSelected();
        public static event PlaneSelected OnWrongPlaneSelected;
        public static event PlaneSelected OnCorrectPlaneSelected;

        private bool canPick = true;
        public void Initialized(PlanePlacement placement)
        {
            _planePlacement = placement;
        }

        public void Reset()
        {
            canPick = true;
            
            foreach (var child in planeChild)
            {
                child.Reset();
            }
        }
        private void Update()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    CheckObjectOnTap(touch.position);
                }
            }

            #if UNITY_EDITOR
                if (Input.GetMouseButtonDown(0))
                {
                    CheckObjectOnTap(Input.mousePosition);
                }
            #endif
        }
        
        private void CheckObjectOnTap(Vector2 screenPosition)
        {
            if(!canPick)
                return;
            
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Closest"))
                {
                    canPick = false;
                    hit.collider.GetComponent<PlaneTileChild>().PressCorrectLine();
                    OnCorrectPlaneSelected?.Invoke();
                    _planePlacement.PlaceNextTile();
                }

                if (hit.collider.CompareTag("Wrong"))
                {
                    canPick = false;
                    hit.collider.GetComponent<PlaneTileChild>().PressWrongLine();
                    OnWrongPlaneSelected?.Invoke();
                    _planePlacement.PlaceNextTile();
                }
            }
        }
        
    }
}