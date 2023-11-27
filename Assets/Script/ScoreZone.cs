using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    public TMPro.TextMeshProUGUI scoreText; 
    public int scoreValue = 10; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Disc"))
        {
           
            UpdateScore(+scoreValue);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Disc"))
        {
            
            UpdateScore(-scoreValue);
        }
    }

    private void UpdateScore(int value)
    {
        
        int currentScore = int.Parse(scoreText.text);
        int newScore = Mathf.Max(0, currentScore + value); 
        scoreText.text = newScore.ToString();
    }
}
