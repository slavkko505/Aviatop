using System;
using Managers;
using TMPro;
using UnityEngine;

namespace UI
{
    public class ResourceUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI[] textRes;
       
        private GameInstaller _gameInstaller;

        private void OnEnable()
        {
            GameInstaller.OnPurchase += UpdateTextUI;
        }

        private void OnDisable()
        {
            GameInstaller.OnPurchase -= UpdateTextUI;
        }

        private void Start()
        {
            _gameInstaller = GameInstaller.instance;
            
            if(_gameInstaller!= null)
                UpdateTextUI(_gameInstaller._resourceManager.Amount);
        }

        private void UpdateTextUI(int amount)
        {
            foreach (var text in textRes)
            {
                text.text = amount.ToString();
            }
        }
    }
}
