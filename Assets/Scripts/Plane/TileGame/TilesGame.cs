using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Plane.TileGame
{
    public class TilesGame : MonoBehaviour
    {
        [Header("UI Component")] 
        [SerializeField] private Image mainImg;
        [SerializeField] private TileUI[] TilesImg;
        
        [Header("Additional UI")] 
        [SerializeField] private List<Sprite> mainImgList;
        [SerializeField] private List<Tile> tilesList;

        private int indexGame;
        
        public delegate void WinGame();
        public static event WinGame OnWinGame;

        private int CountTiles;
        
        private void OnEnable()
        {
            TileGameCarSelector.OnCardSelected += CardSelected;
            TutorialScreen.OnStartGame += StartGame;
            TileUI.OnCardPlaced += CheckCountPlacedCard;
        }
        
        private void OnDisable()
        {
            TileGameCarSelector.OnCardSelected -= CardSelected;
            TutorialScreen.OnStartGame -= StartGame;
            TileUI.OnCardPlaced -= CheckCountPlacedCard;
        }

        private void CardSelected(int index)
        {
            indexGame = index;

            SelectMainImg();
            SelectTilesFromIndex();
        }

        private void StartGame()
        {
            StartCoroutine(StartGameDelay());
        }
        
        private void SelectTilesFromIndex()
        {
            for (int i = 0; i < TilesImg.Length; i++)
            {
                TilesImg[i].SetSprite(tilesList[indexGame].GetTile(i));
                RandomRotate(i);
                TilesImg[i].CheckOrientation();
            }
        }

        private void CheckCountPlacedCard()
        {
            CountTiles += 1;
            if (CountTiles == 16)
            {
                OnWinGame?.Invoke();
            }
        }
        public void RandomRotate(int index)
        {
            int[] rotationAngles = { 90, 180, 270, 0 };
            int randomIndex = Random.Range(0, rotationAngles.Length);
            int randomAngle = rotationAngles[randomIndex];
            
            TilesImg[index].transform.rotation = Quaternion.Euler(0, 0, randomAngle);
        }
        
        private void SelectMainImg()
        {
            mainImg.gameObject.SetActive(false);
            mainImg.sprite = mainImgList[indexGame];
            mainImg.gameObject.SetActive(true);
        }
        
        private IEnumerator StartGameDelay()
        {
            yield return new WaitForSeconds(2f);
            mainImg.gameObject.SetActive(false);
        }
    }
}