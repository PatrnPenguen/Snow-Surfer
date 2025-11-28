using _2_Scripts;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    int score;
    
    public void AddScore(int addScore)
    {
        score += addScore;
        scoreText.text = $"Score: {score}";
    } 
}
