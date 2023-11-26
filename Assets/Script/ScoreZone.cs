using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    public TMPro.TextMeshProUGUI scoreText; // Reference to the TextMeshProUGUI component displaying the score
    public int scoreValue = 10; // Score value when a disc is in the zone

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Disc"))
        {
            // Increase the score when a disc with the "Disc" tag enters the zone
            UpdateScore(+scoreValue);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Disc"))
        {
            // Decrease the score when a disc with the "Disc" tag exits the zone
            UpdateScore(-scoreValue);
        }
    }

    private void UpdateScore(int value)
    {
        // Update the score and display it on the UI
        int currentScore = int.Parse(scoreText.text);
        int newScore = Mathf.Max(0, currentScore + value); // Ensure the score doesn't go below zero
        scoreText.text = newScore.ToString();
    }
}
