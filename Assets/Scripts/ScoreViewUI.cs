﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreViewUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreView;
    // Start is called before the first frame update
    void Start()
    {
        this.scoreView.text = Score.currentScore.ToString("F0");
        Score.onScoreChanged += this.UpdateScore;
    }

    void UpdateScore(int val){
        this.scoreView.text = val.ToString();
    }
}
