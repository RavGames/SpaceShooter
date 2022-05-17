using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    int currentScore = 0;

    public void AddScore(int pointsPerBlock)
    {
        currentScore += pointsPerBlock;
    }

    public int GetScore()
    {
        return currentScore;
    }



}//CLASS
