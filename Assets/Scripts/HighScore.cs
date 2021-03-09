using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    private Score _score;
    private Audio _audio;
    
    public TMP_Text highScoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        _score = FindObjectOfType<Score>();
        _audio = FindObjectOfType<Audio>();
        highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetHighScore()
    {
        if (_score.currentScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", _score.currentScore);
            highScoreText.text = _score.currentScore.ToString();
        }
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        highScoreText.text = "0";
    }
}
