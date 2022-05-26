using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToFirstLevel : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("Another");
        Time.timeScale = 1f;
    }
}
