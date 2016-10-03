using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour
{
    private Text ScoreText;
    public static int score;
    public static int highScore;

    void Start ()
    {
        score = 0;
        ScoreText = GetComponent<Text>();
	}
	void Update ()
    {
        ScoreText.text = score.ToString();
        if (score >= highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highScore", score);
            PlayerPrefs.Save();
        }
    }
}
