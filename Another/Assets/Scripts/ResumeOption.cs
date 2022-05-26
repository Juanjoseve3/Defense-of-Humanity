using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeOption : MonoBehaviour
{
    public Canvas PauseMenu;
    public void Resume()
    {
        PauseMenu.enabled = false;
        Time.timeScale = 1f;
    }
}
