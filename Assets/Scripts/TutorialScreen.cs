using UnityEngine;

public class TutorialScreen : MonoBehaviour
{
    [SerializeField] private GameObject tutor;
    
    public delegate void StartGameHandler();
    public static event StartGameHandler OnStartGame;
    private void Start()
    {
        Time.timeScale = 0;
        tutor.SetActive(true);
    }

    public void StartGame()
    {
        OnStartGame?.Invoke();
        Time.timeScale = 1;
    }
    
    
}