using System.Collections;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// To store and update current score and high score.
/// </summary>
public class ScoreController : MonoBehaviour
{
    [SerializeField] private int highScore;
    private readonly string highScoreKey = "HighScore";
    [SerializeField] private int score;
    private readonly string scoreKey = "Score";
    [SerializeField] private Text scoreText;
    [SerializeField] private PauseController pb;
    [SerializeField] private PlayerController pc;

    public void setScoreText(string s)
    {
        scoreText.text = s;
    }

    public void setScoreColor(Color c)
    {
        scoreText.color = c;
    }


    private void Start()
    {
        setScoreText("0");
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        StartCoroutine(incScore());
    }

    private void Update()
    {
        if (!pb.pause)
        {
            setScoreText(score.ToString());
        }
        
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt(scoreKey, score);
        if (score > highScore) PlayerPrefs.SetInt(highScoreKey, score);
        PlayerPrefs.Save();
    }

    private IEnumerator incScore()
    {
        while (true)
        {
                yield return new WaitForSeconds(0.5f);
                if(!pc.pressedStart) continue;
                score += 1;
        }
    }
}