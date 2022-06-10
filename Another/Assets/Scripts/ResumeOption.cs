using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeOption : MonoBehaviour
{
    //Busca el canvas de pausa
    public Canvas PauseMenu;

    //Despausa/Reanuda el juego
    public void Resume()
    {
        PauseMenu.enabled = false;
        Time.timeScale = 1f;
    }
}
