using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField]
    private ShootingScript ShootActivation;
    [SerializeField]
    private GameObject Board;
    void Start()
    {
        Time.timeScale = 0;
        ShootActivation.enabled = false;
    }
    public void begin() 
    {
        Time.timeScale = 1;
        ShootActivation.enabled = true;
        Destroy(Board);
    }
}
