using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// When the game is over;
/// if score>50 ad will be displayed.
/// highscore check and send to play services.
/// score and high score will be displayed.
/// 
/// </summary>
public class GameOverController : MonoBehaviour
{
    private int highScore;
    private readonly string highScoreKey = "HighScore";
    [SerializeField] private Text highScoreText;
    private int score;
    private readonly string ScoreKey = "Score";
    [SerializeField] private Text scoreText;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt(highScoreKey);
        score = PlayerPrefs.GetInt(ScoreKey);

        scoreText.text = "Score: " + score;
        highScoreText.text = "High Score: " + highScore;
        if (score >= 50) AdsController.ShowAd();

        Social.ReportScore(highScore, "CgkIhsv-_akWEAIQBg", success =>
        {
            
        });
    }
}