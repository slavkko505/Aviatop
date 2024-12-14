using System;
using System.Collections;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private GameObject loadingScreen;

        private void OnEnable()
        {
            SwichSceneUI.OnPressLoad += LoadSceneAsync;
        }

        private void OnDisable()
        {
            SwichSceneUI.OnPressLoad -= LoadSceneAsync;
        }

        public void LoadSceneAsync(string sceneName)
        {
            StartCoroutine(LoadSceneCoroutine(sceneName));
        }

        private IEnumerator LoadSceneCoroutine(string sceneName)
        {
            loadingScreen.SetActive(true);

            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
            asyncLoad.allowSceneActivation = false;

            while (!asyncLoad.isDone)
            {
                if (asyncLoad.progress >= 0.9f)
                {
                    yield return new WaitForSeconds(0.5f);

                    asyncLoad.allowSceneActivation = true;
                }

                yield return null;
            }

            Time.timeScale = 1;
            loadingScreen.SetActive(false);
        }
    }
}