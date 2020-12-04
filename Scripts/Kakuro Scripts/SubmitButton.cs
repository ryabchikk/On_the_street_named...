using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Скрипт кнопки проверки
//Кнопка должна быть внутри Board

public class SubmitButton : MonoBehaviour
{
    private Board board;
    private ShootingScript ShootActivation;
    void Start()
    {
        //Доска
        board = GameObject.FindWithTag("Board").GetComponent<Board>();
        ShootActivation = GameObject.FindWithTag("Player").GetComponent<ShootingScript>();
    }

    //Вызывается по клику
    void Click()
    {
        if (board.CheckSums())
        {
            Destroy(board.gameObject, 1f);
            ShootActivation.enabled = true;
            Time.timeScale = 1;
        }
        else 
        { 
            board.WrongNumbers();
        }
    }
}


