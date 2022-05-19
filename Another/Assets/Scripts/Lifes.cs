using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lifes : MonoBehaviour
{
    public static int LifesCount;
    public Image Life_1;
    public Image Life_2;
    public Image Life_3;

    public Canvas GameOver;

    private void Start()
    {
        LifesCount = 3;
        GameOver.enabled = false;
    }

    private void Update()
    {
        if (LifesCount == 3)
        {
            Life_1.enabled = true;
            Life_2.enabled = true;
            Life_3.enabled = true;
        }

        if (LifesCount == 2)
        {
            Life_1.enabled = false;
            Life_2.enabled = true;
            Life_3.enabled = true;
        }

        if (LifesCount == 1)
        {
            Life_1.enabled = false;
            Life_2.enabled = false;
            Life_3.enabled = true;
        }

        if (LifesCount == 0)
        {
            Life_1.enabled = false;
            Life_2.enabled = false;
            Life_3.enabled = false;

            Time.timeScale = 0;
            GameOver.enabled = true;
        }
    }
}
