using System;
using UnityEngine;

namespace Plane.CloundGame
{
    public class PlaneTileChild : MonoBehaviour
    {
        [Header("OutLine Effect")]
        [SerializeField] private Color correctColor;
        [SerializeField] private Color wrongColor;
        [SerializeField] private SpriteRenderer outLine;
        
        private void Start()
        {
            Reset();
        }

        public void PressCorrectLine()
        {
            outLine.color = correctColor;
            ShowOutLine();
        }

        public void PressWrongLine()
        {
            outLine.color = wrongColor;
            ShowOutLine();
        }
        
        public void Reset()
        {
            outLine.gameObject.SetActive(false);
        }
        
        private void ShowOutLine()
        {
            outLine.gameObject.SetActive(true);
        }
    }
}