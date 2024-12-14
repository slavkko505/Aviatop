using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class SwichSceneUI : MonoBehaviour
    {
        public delegate void PressLoad(string name);
        public static event PressLoad OnPressLoad;

        public void LoadScene(string nameScene)
        {
            Time.timeScale = 1;
            OnPressLoad?.Invoke(nameScene);
        }
        
        public void ReloadScene()
        {
            string nameScene = SceneManager.GetActiveScene().name;
            Time.timeScale = 1;
            
            OnPressLoad?.Invoke(nameScene);
        }
    }
}