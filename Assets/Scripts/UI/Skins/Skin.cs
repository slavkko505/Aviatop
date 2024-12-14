using UnityEngine;

namespace UI.Skins
{
    [System.Serializable]
    public class Skin
    {
        public Sprite image;
        public int price;
        public bool isBought = false;
        public bool isSelected = false;
        public bool isDefault = false;
    }
}