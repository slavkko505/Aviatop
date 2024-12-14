using UnityEngine;

public class TimeOver : MonoBehaviour
{
    [SerializeField] protected GameObject canvasTimeOver;
    
    public virtual void OnEnable()
    {
        Timer.OnLoseGame += LoseGame;
    }
    
    public virtual void OnDisable()
    {
        Timer.OnLoseGame -= LoseGame;
    }

    private void Start()
    {
        canvasTimeOver.SetActive(false);
    }

    public virtual void LoseGame()
    {
        Time.timeScale = 0;
        canvasTimeOver.SetActive(true);
    }
    
    
}