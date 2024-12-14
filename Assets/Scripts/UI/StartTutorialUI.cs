using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class StartTutorialUI : MonoBehaviour
    {
        [Header("Main Menu")] 
        [SerializeField] private GameObject mainMenu;
        [SerializeField] private GameObject tutorialMenu;
        
        [Header("UI Component")] 
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private Image image;
        [SerializeField] private TextMeshProUGUI buttonText;

        [Header("Pages Example")] [SerializeField]
        private Sprite Page1Img;

        [SerializeField] private Sprite Page2Img;
        private string BtnPage1Text = "Next";
        private string BtnPage2Text = "Start";

        private string page1Text =
            "Welcome to Aviatop!\nTake off into a world of thrilling airplane adventures with Aviatop - Flight Frenzy!";

        private string page2Text =
            "Prepare for fun, challenges, and sky-high excitement!  \nLet’s get started and conquer the skies!";

        private bool IsPressed;

        void Start()
        {
            if (!PlayerPrefs.HasKey(Constants.TutorialGame))
            {
                StartUIGame();
                PlayerPrefs.SetInt(Constants.TutorialGame, 1);
            }
            else
            {
                tutorialMenu.SetActive(false);
                mainMenu.SetActive(true);
            }
        }

        private void StartUIGame()
        {
            mainMenu.SetActive(false);
            tutorialMenu.SetActive(true);
            
            text.text = page1Text;
            image.sprite = Page1Img;
            buttonText.text = BtnPage1Text;
        }

        public void onClick()
        {
            if (!IsPressed)
            {
                text.text = page2Text;
                image.sprite = Page2Img;
                buttonText.text = BtnPage2Text;

                IsPressed = true;
            }
            else
            {
                tutorialMenu.SetActive(false);
                mainMenu.SetActive(true);
            }
        }
    }
}