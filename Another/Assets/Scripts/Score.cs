using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public TextMeshPro scoreText;

    //Se llama un campo de texto para que contenga un texto Score y el puntaje para ponerlos en pantalla
    public void Update()
    {
        scoreText.text = "Score: " + GeneralScore();
    }

    //Toma el valor del enemigo y la persona y las suma, esta suma se guarda en un método que actúa de puntaje
    public int GeneralScore()
    {
        return Invader.ScoreCount() + Person.ScoreCount();
    }
}
