using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private Health _health;
    private HighScore _highScore;
    private Audio _audio;
    
    public int currentScore;
    public TMP_Text scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        _health = FindObjectOfType<Health>();
        _highScore = FindObjectOfType<HighScore>();
        _audio = FindObjectOfType<Audio>();
        currentScore = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.SetText(currentScore.ToString());
        _highScore.GetHighScore();
        
    }

    public void PointsOne()
    {
        currentScore += 1;
            StartCoroutine(HealthIncrease());
    }
    
    public void PointsTwo()
    {
        currentScore += 2;
        StartCoroutine(HealthIncrease());
    }
    
    public void PointsThree()
    {
        currentScore += 3;
        StartCoroutine(HealthIncrease());
    }

    IEnumerator HealthIncrease()
    {
        if (currentScore % 50 == 0)
        {
            _health.health += 1;
            _audio.PlayHealthIncrease();
        }
        yield return new WaitForSeconds(2);
    }
}
