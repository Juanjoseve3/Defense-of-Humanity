using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public TextMeshPro scoreText;
    public void Update()
    {
        scoreText.text = "Score: " + Invader.ScoreCount();
    }
}
