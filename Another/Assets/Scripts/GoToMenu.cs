using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//Este c�digo se encarga de enviarte al men� principal 
public class GoToMenu : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene("Main");
    }
}
