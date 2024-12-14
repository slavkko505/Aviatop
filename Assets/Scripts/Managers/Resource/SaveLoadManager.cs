using UnityEngine;

namespace Managers.Resource
{
    public class SaveLoadManager
    {
        public int LoadAmount()
        {
            int loadedAmount = PlayerPrefs.GetInt(Constants.ResourceAmount, 0);
            return loadedAmount;
        }

        public void SaveAmount(int amount)
        {
            PlayerPrefs.SetInt(Constants.ResourceAmount, amount);
            PlayerPrefs.Save();
        }
    }
}