using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DisplayScore : MonoBehaviour
{
    TextMeshProUGUI scoreTextCounter;

    GameSession gameSession;

    private void Start()
    {
        scoreTextCounter = GetComponent<TextMeshProUGUI>();
        gameSession = FindObjectOfType<GameSession>();
    }

    private void Update()
    {
        scoreTextCounter.text = gameSession.GetScore().ToString();       
    }

}
