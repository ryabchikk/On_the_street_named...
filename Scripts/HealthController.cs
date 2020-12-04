using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public int Health { get; private set; } = 3;
    [SerializeField]public Image[] Lives;
    private int CountLive;

    private void Start()
    {
        CountLive = Lives.Length - 1;
    }
    //При модификации здоровья пользоваться только этими функциями
    void AddDamage(int amount)
    {
        if (Health - amount <= 0) 
        { 
            Die();
        }
        else 
        {
            Health -= 1;
            Lives[CountLive].enabled = false;
            CountLive--;
        }
            
    }
    //Не просили, но я сделал
    /*ну и правильно, что сделал*/
    void AddHeal(int amount)
    {
        if (Health + amount <= 3)
            Health += amount;

    }

    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

