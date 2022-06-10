using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//Este código se encarga de enviarte al primer nivel
public class GoToFirstLevel : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("Another");
        Time.timeScale = 1f;
    }
}
