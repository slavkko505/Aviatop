using System;
using Managers.Resource;
using UnityEngine;

namespace Managers
{
    public class GameInstaller : MonoBehaviour
    {
        public static GameInstaller instance;

        public ResourceManager _resourceManager;
        private SaveLoadManager _saveLoadManager;
        private SceneLoader _sceneLoader;
        
        public delegate void Purchase(int amount);
        public static event Purchase OnPurchase;
        
        public void Initialize(SceneLoader sceneLoader)
        {
            _saveLoadManager = new SaveLoadManager();

            int amount = _saveLoadManager.LoadAmount();
            _resourceManager = new ResourceManager(amount);
            _sceneLoader = sceneLoader;
        }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(this);
            }
        }
        
        private void OnEnable()
        {
            LoseScreen.OnScoreClaim += ScoreClaim;
            TimeOverGift.OnScoreClaim += ScoreClaim;
        }

        private void OnDisable()
        {
            LoseScreen.OnScoreClaim -= ScoreClaim;
            TimeOverGift.OnScoreClaim -= ScoreClaim;
        }

        private void ScoreClaim(int score)
        {
            _resourceManager.AddAmount(score);
            _saveLoadManager.SaveAmount(_resourceManager.Amount);
        }
        
        public void StartGame()
        {
            if (_sceneLoader == null)
            {
                return;
            }

            _sceneLoader.LoadSceneAsync("MainScreen");
        }

        public bool CanBuy(int amount) => amount <= _resourceManager.Amount;

        public void BuySkin(int amount)
        {
            _resourceManager.RemoveRes(amount);
            _saveLoadManager.SaveAmount(_resourceManager.Amount);
            OnPurchase?.Invoke(_resourceManager.Amount);
        }
    }
}