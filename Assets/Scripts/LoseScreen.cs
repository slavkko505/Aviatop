using Plane;
using Plane.TileGame;
using TMPro;
using UnityEngine;

public class LoseScreen : MonoBehaviour
{
    [SerializeField] private GameObject canvasLose;
    [SerializeField] private TextMeshProUGUI textScore;
    [SerializeField] private int AmountPassedGame;
    
    public delegate void ScoreClaim(int score);
    public static event ScoreClaim OnScoreClaim;
    
    private void Start()
    {
        canvasLose.SetActive(false);
    }

    private void OnEnable()
    {
        HealthUI.OnLosePlayer += Lose;
        TilesGame.OnWinGame += PassedGame;
    }

    private void OnDisable()
    {
        HealthUI.OnLosePlayer -= Lose;
        TilesGame.OnWinGame -= PassedGame;
    }

    private void Lose(int score)
    {
        Time.timeScale = 0;
        OnScoreClaim?.Invoke(score);
        if (textScore != null) 
            textScore.text = "+" + score;
        canvasLose.SetActive(true);
    }

    private void PassedGame()
    {
        Time.timeScale = 0;
        if (textScore != null) 
            textScore.text = "+" + AmountPassedGame;
        OnScoreClaim?.Invoke(AmountPassedGame);
        canvasLose.SetActive(true);
    }
    
}