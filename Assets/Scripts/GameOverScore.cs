using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverScore : MonoBehaviour {


    public Text score;
    public Text HighScore;
	// Use this for initialization
	void Start () {
        score.text = "Score " + "\n " + Score.score.ToString();
        HighScore.text = "High Score" + "\n "+ PlayerPrefs.GetInt("highScore").ToString();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
