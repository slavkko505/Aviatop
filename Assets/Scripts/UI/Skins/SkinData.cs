using System.Collections.Generic;

namespace UI.Skins
{
    [System.Serializable]
    public class SkinData
    {
        public List<SkinStatus> skins;

        public SkinData(List<Skin> skins)
        {
            this.skins = new List<SkinStatus>();
            foreach (var skin in skins)
            {
                this.skins.Add(new SkinStatus(skin.isBought, skin.isSelected));
            }
        }
    }
}