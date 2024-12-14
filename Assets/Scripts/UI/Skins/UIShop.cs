using System.Collections.Generic;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Skins
{
    public class UIShop : MonoBehaviour
    {
        [Header("List skins")]
        [SerializeField] private List<Skin> skins; 
        
        [Header("Ui content")]
        [SerializeField] private Image skinDisplay;
        [SerializeField] private GameObject coinImg;
        [SerializeField] private TextMeshProUGUI priceText; 
        [SerializeField] private TextMeshProUGUI textInfo; 
        [SerializeField] private TextMeshProUGUI textOnBuyBtn; 
        [SerializeField] private Button buyButton; 
        [SerializeField] private Button leftButton; 
        [SerializeField] private Button rightButton;
        
        [Header("Additional content")]
        [SerializeField] private Image mainButtonSelected;
        [SerializeField] private Sprite GreenBtnSelected;
        [SerializeField] private Sprite RedBtnSelected;
        
        private int currentSkinIndex = 0;

        void Start()
        {
            LoadSkinData();
            UpdateSkinUI();
            UpdateNavigationButtons();
        }

        public void NextSkin()
        {
            if (currentSkinIndex < skins.Count - 1)
            {
                currentSkinIndex++;
                UpdateSkinUI();
                UpdateNavigationButtons();
            }
        }

        public void PreviousSkin()
        {
            if (currentSkinIndex > 0)
            {
                currentSkinIndex--;
                UpdateSkinUI();
                UpdateNavigationButtons();
            }
        }

        public void OnBuyOrSelectButtonClicked()
        {
            Skin currentSkin = skins[currentSkinIndex];

            if (!currentSkin.isBought)
            {
                if (GameInstaller.instance.CanBuy(currentSkin.price))
                {
                    GameInstaller.instance.BuySkin(currentSkin.price);
                    currentSkin.isBought = true;
                    SaveSkinData();
                }
                
            }
            else if (!currentSkin.isSelected)
            {
                DeselectAllSkins();
                currentSkin.isSelected = true;
                SaveSkinIndex();
                SaveSkinData();
            }

            UpdateSkinUI();
        }

        private void DeselectAllSkins()
        {
            foreach (var skin in skins)
            {
                skin.isSelected = false;
            }
        }

        private void UpdateNavigationButtons()
        {
            leftButton.interactable = currentSkinIndex > 0;
            rightButton.interactable = currentSkinIndex < skins.Count - 1;
        }
        
        private void UpdateSkinUI()
        {
            Skin currentSkin = skins[currentSkinIndex];

            skinDisplay.sprite = currentSkin.image;

            if (currentSkin.isBought && !currentSkin.isDefault)
            {
                UiTextSwap(false);
                textInfo.text = "Bought";
            }
            else if (currentSkin.isDefault)
            {
                UiTextSwap(false);
                textInfo.text = "Default";
            }
            else
            {
                UiTextSwap(true);
                priceText.text = currentSkin.price.ToString();
            }

            if (!currentSkin.isBought)
            {
                mainButtonSelected.sprite = GreenBtnSelected;
                textOnBuyBtn.text = "Buy";
            }
            else if (!currentSkin.isSelected)
            {
                mainButtonSelected.sprite = GreenBtnSelected;
                textOnBuyBtn.text = "Select";
            }
            else
            {
                mainButtonSelected.sprite = RedBtnSelected;
                textOnBuyBtn.text = "Selected";
            }
        }

        private void UiTextSwap(bool temp)
        {
            coinImg.SetActive(temp);
            priceText.gameObject.SetActive(temp);
            textInfo.gameObject.SetActive(!temp);
        }

        private void SaveSkinData()
        {
            SkinData skinData = new SkinData(skins);
            string jsonData = JsonUtility.ToJson(skinData);
            PlayerPrefs.SetString(Constants.SaveKey, jsonData);
            PlayerPrefs.Save();
        }

        private void SaveSkinIndex()
        {
            PlayerPrefs.SetInt(Constants.SaveKeySkinIndex, currentSkinIndex);
        }
        private void LoadSkinData()
        {
            if (PlayerPrefs.HasKey(Constants.SaveKey))
            {
                string jsonData = PlayerPrefs.GetString(Constants.SaveKey);
                SkinData skinData = JsonUtility.FromJson<SkinData>(jsonData);

                for (int i = 0; i < skins.Count; i++)
                {
                    if (i < skinData.skins.Count)
                    {
                        skins[i].isBought = skinData.skins[i].isBought;
                        skins[i].isSelected = skinData.skins[i].isSelected;
                    }
                }
            }
        }
    }
}