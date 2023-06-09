using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    public static int score;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Collectible"))
        {
            score++;
            Debug.Log(score);
        }
    }

    public static int GetScore()
    {
        return score;
    }

    public static void SetScore(int newScore)
    {
        score = newScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
