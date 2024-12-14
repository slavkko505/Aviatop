using Managers;
using UnityEngine;

namespace Bootstrap
{
    public class MainBootstrap : MonoBehaviour
    {
        [SerializeField] SceneLoader loader;

        private GameInstaller _gameInstaller;

        void Start()
        {
            GameObject gameManagerObject = new GameObject("GameInstaller");
            _gameInstaller = gameManagerObject.AddComponent<GameInstaller>();
            loader.transform.parent = _gameInstaller.transform;
            
            _gameInstaller.Initialize(loader);
            _gameInstaller.StartGame();
        }
    }
}