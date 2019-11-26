using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject instructions;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Instructions()
    {
        instructions.SetActive(true);
    }
    public void closeInstructions()
    {
        instructions.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    
}
