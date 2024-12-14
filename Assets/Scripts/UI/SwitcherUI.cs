using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SwitcherUI : MonoBehaviour
    {
        [Header("UI Components")] [SerializeField]
        private Image imgSwitcher;

        [SerializeField] private GameObject onBthThumb;
        [SerializeField] private GameObject offBthThumb;

        [Header("Additional Components")] [SerializeField]
        private Color startColor;

        [SerializeField] private Color switchColor;

        private bool clicked;

        private void Start()
        {
            TurnOn();
        }

        public void OnClick()
        {
            if (clicked)
                TurnOn();
            else
                TurnOff();

            clicked = !clicked;
        }

        private void TurnOff()
        {
            imgSwitcher.color = startColor;
            onBthThumb.SetActive(true);
            offBthThumb.SetActive(false);
        }

        private void TurnOn()
        {
            imgSwitcher.color = switchColor;
            offBthThumb.SetActive(true);
            onBthThumb.SetActive(false);
        }
    }
}