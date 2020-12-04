using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

//Скрипт доски
//Должен находиться в префабе Board
//Если кто нибудь захочет искать здесь Update то его здесь нет

public class Board : MonoBehaviour
{
    [SerializeField]
    //Сюда префаб блока
    private GameObject block;
    private Block[] blocks = new Block[16];
    [SerializeField]
    //Сюда Canvas который находится внутри префаба доски
    private Transform parent;
    public int[] colSums;
    public int[] rowSums;
    private GameObject player;
    void Start()
    {
        //С рандомом видимо решений не получится, поэтому одно заготовленное
        //Для проверки к нему ответы 8 9 6 6 4 3 4 2 1
        colSums = new int[3] { 18, 15, 10 };
        rowSums = new int[3] { 23, 13, 7 };
        player = GameObject.FindWithTag("Player");
        BlocksInit();
    }

    //Вызывается кнопкой проверки, возвращает в нее true если доска заполнена правильно
    //Разбито на две функции для проверки сумм столбцов и строк отдельно
    public bool CheckSums()
    {
        bool flag;
        flag = CheckSumsInCols();
        if (flag)
            flag = CheckSumsInRows();
        if(flag)
            player.SendMessage("MinigameState", false);
        return flag;
    }

    //Проверка сумм столбцов
    //Функции для сток и столбцов работают практически одинаково
    //В nums выбираются из массива всех клеток только клетки одной строки(столбца)
    //По nums проходит цикл который складывает значения
    //Если значения не совпадают сразу возвращается false
    //Если все значения совпадают циклы завершаются и возвращается true
    //Это можно было бы записать в одну функцию, но потом
    private bool CheckSumsInCols()
    {
        int sum = 0;
        for (int i = 1; i < 4; i++)
        {
            sum = (from n in blocks where n.column == i && n.row != 0 select n.GetNum()).Sum();

            if (sum != colSums[i - 1])
                return false;

            sum = 0;
        }
        return true;
    }

    //Проверка сумм строк
    private bool CheckSumsInRows()
    {
        int sum = 0;
        for (int i = 1; i < 4; i++)
        {
            sum = (from n in blocks where n.column != 0 && n.row == i select n.GetNum()).Sum();

            if (sum != rowSums[i - 1])
                return false;

            sum = 0;
        }
        return true;
    }

    //Заглушка для неверного ответа
    public void WrongNumbers()
    {
        Debug.Log("WrongNumbers");
    }

    //Инициализация блоков и размещение по позициям
    private void BlocksInit()
    {
        RectTransform rt = block.GetComponent<RectTransform>();
        int cnt = 0;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                GameObject b = Instantiate(block, parent);
                b.GetComponent<RectTransform>().anchoredPosition = new Vector3(rt.position.x + j * rt.sizeDelta.x * 0.98f, rt.position.y - i * rt.sizeDelta.y * 0.98f, rt.position.z);
                blocks[cnt] = b.GetComponent<Block>();
                blocks[cnt].column = j;
                blocks[cnt].row = i;
                cnt++;
            }
        }
    }

    //Получение суммы для блока
    public int GetSum(int num, bool isCol)
    {
        if (isCol)
            return colSums[num - 1];
        else
            return rowSums[num - 1];
    }
}

