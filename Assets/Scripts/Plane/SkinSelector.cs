using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Plane
{
    public class SkinSelector : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer planeSprite;
        [SerializeField] private Image planeSpriteImg;
        [SerializeField] protected List<Sprite> allSkins;

        private void Start()
        {
            SelectSkin();
        }

        private void SelectSkin()
        {
           int index =  PlayerPrefs.GetInt(Constants.SaveKeySkinIndex, 0);
           if (index >= allSkins.Count)
               index = 0;
           
           if(planeSprite!=null)
               planeSprite.sprite = allSkins[index];
           if(planeSpriteImg!=null)
               planeSpriteImg.sprite = allSkins[index];
        }
    }
}