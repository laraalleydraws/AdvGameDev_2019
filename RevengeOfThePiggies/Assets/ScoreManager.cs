﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : Subject
{
    public int score = 0;
    public Observer displayScore;

    // making the constructor private prevents others 
    // from creating an object of this class
    private void Start()
    {
        registerObserver(displayScore);
    }

    public void updateScore(int point)
    {
        score += point;
        Notify(score, NotificationType.ScoreUpdated);
    }

}