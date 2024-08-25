using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIMangager : MonoBehaviour
{
    public GameObject panel;
    private bool panel_state;


    public void ShowPanel()
    { 
        panel_state = !panel_state;
        panel.SetActive(panel_state);
        if(panel_state) Time.timeScale = 0f;
        else Time.timeScale = 1f;

    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ReStartGame()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
        EventSystem.Damage("ReStart");
    }

}
