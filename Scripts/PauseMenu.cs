using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu: MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;
    [SerializeField]
    private GameObject player;
    private ShootingScript ShootActivation;
    private void Start()
    {
        ShootActivation = player.GetComponent<ShootingScript>();
    }
    public void PauseOn()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
        ShootActivation.enabled = false;
    }
    public void PauseOff() 
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        ShootActivation.enabled = true;
    }
    public void ExitMainMenu() 
    {
        SceneManager.LoadScene(0);
    }
}
