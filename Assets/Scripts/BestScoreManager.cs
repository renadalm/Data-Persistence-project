using UnityEngine;
using UnityEngine.UI;
public class BestScoreManager : MonoBehaviour
{
    public Text scoreText;          
    public Text highScoreText;       
    public int currentScore = 0;

    private int highScore;
    private string highScorePlayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScorePlayer = PlayerPrefs.GetString("HighScorePlayer");

        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddScore(int points)
    {
        currentScore += points;
        scoreText.text = "Score: " + currentScore;


        if (currentScore > highScore)
        {
            highScore = currentScore;
            highScorePlayer = PlayerPrefs.GetString("PlayerName", "Player");


            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.SetString("HighScorePlayer", highScorePlayer);
            PlayerPrefs.Save();

            UpdateUI();
        }
    }

    void UpdateUI()
    {
        highScoreText.text = "Best Score: " + highScore + " Name " + highScorePlayer;
    }
}
