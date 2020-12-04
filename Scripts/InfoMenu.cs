using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject infoPanel;
    [SerializeField]
    private GameObject player;
    private ShootingScript ShootActivation;
    private void Start()
    {
        ShootActivation = player.GetComponent<ShootingScript>();
    }
    public void InfoOn() 
    {
        ShootActivation.enabled = false;
        infoPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void InfoOff()
    {
        ShootActivation.enabled = true;
        infoPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
