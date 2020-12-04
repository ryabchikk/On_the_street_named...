using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestBlock : MonoBehaviour
{
    private Button button;
    private TestBoard board;
    public Text text;
    public bool isRight = false;
    private bool isLast = false;

    void Start()
    {
        //Доска
        board = GameObject.FindGameObjectWithTag("Board").GetComponent<TestBoard>();
        //Эта кнопка
        button = GetComponent<Button>();
        //Текст этой кнопки
        text = GetComponentInChildren<Text>();
        if(isLast)
            board.SendMessage("NextQuestion");
    }

    private void Click()
    {
        if (isRight)
            board.SendMessage("NextQuestion");
        else
            board.SendMessage("Lose");
    }

    //Костыль
    private void Last()
    {
        isLast = true;
    }
}
