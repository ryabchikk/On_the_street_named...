using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelCodeActivate : MonoBehaviour
{
    [SerializeField]
    private GameObject board;               //В инспекторе сюда префаб доски
    [SerializeField]
    private GameObject player;
    private ShootingScript ShootActivation;
    private void Start()
    {
        ShootActivation = player.GetComponent<ShootingScript>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown("e"))
            {
                board.SetActive(true);
                ShootActivation.enabled = false;
                Time.timeScale = 0;
            }
        }
    }
}
