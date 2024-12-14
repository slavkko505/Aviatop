using Plane.CloundGame;
using TMPro;
using UnityEngine;

public class TimeOverGift : TimeOver
{
    [SerializeField] private TextMeshProUGUI textWinPrice;

    private int score = 0;
    
    public delegate void ScoreClaim(int score);
    public static event ScoreClaim OnScoreClaim;
    
    public override void OnEnable()
    {
        base.OnEnable();
        PlaneTile.OnCorrectPlaneSelected += CorrectPlaneSelected;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        PlaneTile.OnCorrectPlaneSelected -= CorrectPlaneSelected;

    }

    private void CorrectPlaneSelected()
    {
        score += 5;
    }

    public override void LoseGame()
    {
        Time.timeScale = 0;
        textWinPrice.text = "+" + score;
        OnScoreClaim?.Invoke(score);
        canvasTimeOver.SetActive(true);
    }
}