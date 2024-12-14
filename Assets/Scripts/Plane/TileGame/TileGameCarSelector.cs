using UnityEngine;

namespace Plane.TileGame
{
    public class TileGameCarSelector : MonoBehaviour
    {
        [SerializeField] private GameObject tilesContainer;
        [SerializeField] GameObject cardContainer;
        [SerializeField] GameObject timerContainer;
        [SerializeField] private TutorialScreen _tutorialScreen;
        
        public delegate void CardSelected(int index);
        public static event CardSelected OnCardSelected;

        private void Start()
        {
            InitializeTileGame(false);
        }

        private void InitializeTileGame(bool temp)
        {
            _tutorialScreen.gameObject.SetActive(temp);
            tilesContainer.SetActive(temp);
            cardContainer.SetActive(!temp);
            timerContainer.SetActive(temp);
        }

        public void SelectCard(int _index)
        {
            OnCardSelected?.Invoke(_index);
            InitializeTileGame(true);
        }
        
        
    }
}