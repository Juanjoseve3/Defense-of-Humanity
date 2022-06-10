using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//Este código se encarga de enviarte al menú principal 
public class GoToMenu : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene("Main");
    }
}
