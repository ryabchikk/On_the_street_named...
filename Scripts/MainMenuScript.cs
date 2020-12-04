using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void OnClickStart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void OnclickExit()
    {
        Application.Quit();
    }
}
