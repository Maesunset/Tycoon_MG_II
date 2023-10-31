using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pause_Manager : MonoBehaviour
{
    //Variables publicas
    public GameObject UI, pausePanel;
    //Variables privadas
    private bool ispause;
    // Start is called before the first frame update
    void Start()
    {
        ispause = false;
        CursorState(false);
        pausePanel.SetActive(false);
        UI.SetActive(true);
    }
    private void Update()
    {
        pauseInput();
    }
    void pauseInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || (Input.GetKeyDown(KeyCode.P)))
        {
            if (ispause)
            {
                Resume();
            }
            else
            {
                pause();
            }
        }
    }
    
    public void pause()
    {
        UI.SetActive(false);
        pausePanel.SetActive(true);
        ispause = true;
        CursorState(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        pausePanel.SetActive(false);
        UI.SetActive(true);
        ispause = false;
        CursorState(false);
        Time.timeScale = 1f;
    }
    public void CursorState(bool State)
    {
        Cursor.visible = State;
        if(State)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;   
        }
    }
}
