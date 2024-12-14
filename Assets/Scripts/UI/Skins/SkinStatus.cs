namespace UI.Skins
{
    [System.Serializable]
    public class SkinStatus
    {
        public bool isBought;
        public bool isSelected;

        public SkinStatus(bool isBought, bool isSelected)
        {
            this.isBought = isBought;
            this.isSelected = isSelected;
        }
    }
}