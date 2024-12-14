using System;
using Plane.CloundGame;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Plane
{
    public class HealthUI : MonoBehaviour
    {
        [SerializeField] private Image[] imgHealth;
        [SerializeField] private TextMeshProUGUI textScore;

        private int countHealth;
        private int score;
        
        public delegate void LosePlayer(int score);
        public static event LosePlayer OnLosePlayer;

        private void Start()
        {
            score = 0;
        }

        private void OnEnable()
        {
            Health.OnItemTouched += ItemTouched;
            PlaneTouch.OnItemTouched += CoinTouched;
            Health.OnCoinTouched += CoinTouched;
            PlaneTile.OnWrongPlaneSelected += ItemTouched;

        }
        
        private void OnDisable()
        {
            Health.OnItemTouched -= ItemTouched;
            PlaneTouch.OnItemTouched -= CoinTouched;
            Health.OnCoinTouched -= CoinTouched;
            PlaneTile.OnWrongPlaneSelected -= ItemTouched;
        }

        private void CoinTouched()
        {
            score += 1;
            textScore.text = score.ToString("D3");
        }

        private void ItemTouched()
        {
            countHealth += 1;

            if (countHealth > 3)
            {
                OnLosePlayer?.Invoke(score);
                return;
            }
            
            for (int i = 0; i < countHealth; i++)
            {
                imgHealth[i].gameObject.SetActive(false);
            }
        }
        
    }
}