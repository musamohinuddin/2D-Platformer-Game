﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private int score = 0;
    private int keys = 0;    

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        RefreshUI();
    }

    public void IncreaseScore(int increment)
    {
        score += increment;
        keys += 1;
        RefreshUI();
    }

    private void RefreshUI()
    {
        scoreText.text = "Score: " + score + "  " + "Keys: " + keys;
    }

}
