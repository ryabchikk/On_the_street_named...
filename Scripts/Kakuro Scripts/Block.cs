using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Скрипт для ячейки
//Должен находиться в префабе Block

public class Block : MonoBehaviour
{
    public int column;
    public int row;
    private int num = 10;
    private Button button;
    private Board board;
    private Text text;


    private void Start()
    {
        //Доска
        board = GameObject.FindGameObjectWithTag("Board").GetComponent<Board>();
        //Эта кнопка
        button = GetComponent<Button>();
        //Текст этой кнопки
        text = GetComponentInChildren<Text>();
        //Является ли эта ячейка крайней, в которой должна быть сумма
        if (column == 0 && row != 0)
        {
            num = board.GetSum(row, false);
            SetNum(num);
            button.interactable = false;
        }
        if (row == 0 && column != 0)
        {
            num = board.GetSum(column, true);
            SetNum(num);
            button.interactable = false;
        }
        if (column == 0 && row == 0)
            button.interactable = false;
    }

    //Вызывается по клику
    void Click()
    {
        num++;
        if (num >= 10)
            num = 1;
        SetNum(num);
    }

    //Установить цифру в текст кнопки
    void SetNum(int n)
    {
        text.text = n.ToString();
    }

    //Получить число этой ячейки
    public int GetNum()
    {
        return num;
    }
}

