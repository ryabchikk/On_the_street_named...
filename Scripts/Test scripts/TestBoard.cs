using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TestBoard : MonoBehaviour
{
    
    [SerializeField]
    //Сюда префаб блока
    private GameObject block;
    private TestBlock[] blocks = new TestBlock[5];
    [SerializeField]
    //Сюда Canvas который находится внутри префаба доски
    private Transform parent;

    [SerializeField]
    //Количество вопросов
    private const int questionsCount = 4;

    //Текущие варианты ответа
    private IEnumerator<string> answersCurr;

    //Все варианты ответа
    private List<string>[] answersAll;

    //Все вопросы
    private IEnumerator<string> questions;

    //Номер текущего вопроса
    private int currentQuestion = 0;

    //Игрок
    private GameObject player;
    private ShootingScript ShootActivation;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        ShootActivation = player.GetComponent<ShootingScript>();
        SetQnA();
        InitBlocks();
    }

    

    #region Init

    //Я не смог красиво это расположить на экране
    //В префабе Block можно поменять размер и расположение кнопки чтобы это выглядело нормально
    //Расположение и размер всех кнопок зависит от положения и размера кнопки в префабе
    //Инициализация кнопок, заполнение массива кнопок
    private void InitBlocks()
    {
        RectTransform rt = block.GetComponent<RectTransform>();
        for (int i = 0; i < 5; i++)
        {
            GameObject b = Instantiate(block, parent);
            b.GetComponent<RectTransform>().anchoredPosition = new Vector3(rt.position.x, rt.position.y - i * rt.sizeDelta.y, rt.position.z);
            blocks[i] = b.GetComponent<TestBlock>();
        }

        //С первой кнопкой взаимодействовать нельзя, в ней текст вопроса
        blocks[0].GetComponent<Button>().interactable = false;

        //Костыль, без этого не загружается текст
        blocks[4].SendMessage("Last");
    }

    //Можно сделать чтение из файла
    private void SetQnA()
    {
        answersAll = new List<string>[questionsCount]
        {
            new List<string> { "Япония", "Германия", "Узбекистан", "Азербайджан" },
            new List<string> { "Инженер", "Разведчик", "Военный врач", "Журналист" },
            new List<string> { "Джек", "Дора", "Кент", "Рамзай" },
            new List<string> { "1941", "1944", "Не присвоено", "1964" },
        };
        questions = new List<string>() { "Зорге родился:", "По образованию был:", "Псевдоним:", "Когда было присвоено звание героя советского союза?" }.GetEnumerator();
    }

    #endregion

    #region Event Handling
    //Переход к следующему вопросу
    private void NextQuestion()
    {
        if (currentQuestion < questionsCount)
        {
            answersCurr = answersAll[currentQuestion].GetEnumerator();
            questions.MoveNext();
            blocks[0].text.text = questions.Current;


            foreach (var b in blocks)
                b.isRight = false;

            int rightAnswer = Random.Range(1, 5);
            blocks[rightAnswer].isRight = true;

            foreach (var b in (from n in blocks where n.isRight == false select n).Skip(1))
            {
                answersCurr.MoveNext();
                b.text.text = answersCurr.Current;
            }
            answersCurr.MoveNext();
            blocks[rightAnswer].text.text = answersCurr.Current;

            currentQuestion++;
        }
        else
            Success();
    }

    //Заглушка
    //Скорее всего нужно будет перенести в другой скрипт и добавить логику успешного завершения
    private void Success()
    {
        Debug.Log("Success");
        player.SendMessage("MinigameState", false);
        Destroy(this.gameObject);
        ShootActivation.enabled = true;
        Time.timeScale = 1;
    }

    //Заглушка
    //Скорее всего нужно будет перенести в другой скрипт и добавить логику неуспешного завершения
    private void Lose()
    {
        Debug.Log("Lose");
        player.SendMessage("MinigameState", false);
        Destroy(this.gameObject);
        ShootActivation.enabled = true;
        Time.timeScale = 1;
        
    }
    #endregion

    
}
