using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText; 
    public float timerDuration = 60f; 

    private float timeRemaining;
    private bool isRunning = false;

    public delegate void LoseGameHandler();
    public static event LoseGameHandler OnLoseGame;
    private void OnEnable()
    {
        TutorialScreen.OnStartGame += StartCounting;
    }

    private void OnDisable()
    {
        TutorialScreen.OnStartGame -= StartCounting;
    }

    void Start()
    {
        timeRemaining = timerDuration;
        isRunning = true;
    }

    private void StartCounting()
    {
        StartCoroutine(StartTimer());

    }
    
    private IEnumerator StartTimer()
    {
        while (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerText();
            yield return null;
        }

        isRunning = false;
        TimerFinished();
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        if (timerText != null)
        {
            if(seconds >=0 )
                timerText.text = string.Format("{0}:{1:00}", minutes, seconds);
        }
    }

    private void TimerFinished()
    {
        OnLoseGame?.Invoke();
    }

    
}
