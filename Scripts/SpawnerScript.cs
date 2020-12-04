using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//HOW TO:
//Создать куб без текстур, растянуть на нужную область в которой будут появляться враги
//Спаунбокс сделать высотой с врага и поставить на землю
//В инспекторе закинуть префаб врага

//Скрипт генерирует enemyCount врагов в рандомных точках внутри спаунбокса к которому он прикреплен
//SpawnEnemies() в Start() существует для теста, дальше будет прописана логика спавна

public class SpawnerScript : MonoBehaviour
{
    [SerializeField]
    public GameObject enemy;
    private float spawnerWidth;
    private float spawnerDepth;
    private int enemyCount = 5;
    private Transform spawner;

    void Start()
    {
        spawner = this.gameObject.transform;
        spawnerWidth = spawner.localScale.x;
        spawnerDepth = spawner.localScale.z;
    }

    //Возможно в этой функции будет непонятно зачем нужны эти строки
    //На самом деле внутри цикла одна строка
    void SpawnEnemies(GameObject en)
    {
        for(int i = 0; i < enemyCount; i++)
        {
            Instantiate(en, 
            new Vector3(
            Random.Range(spawner.position.x - spawnerWidth / 2, spawner.position.x + spawnerWidth / 2), 
            spawner.position.y, 
            Random.Range(spawner.position.z - spawnerDepth / 2, spawner.position.z + spawnerDepth / 2)), 
            Quaternion.identity);
        }
    }


    IEnumerator SpawnEnemiesMultiple(float interval)
    {
        while(true)
        {
            SpawnEnemies(enemy);
            yield return new WaitForSeconds(interval);
        }
    }

    //Для управления из внешних объектов
    //Вызвать эту функцию из объекта который триггерит спавн
    public void StartSpawning(float interval)
    {
        StartCoroutine("SpawnEnemiesMultiple", interval);
    }

    //Вызвать функцию когда нужно закончить спавн
    public void StopSpawning()
    {
        StopCoroutine("SpawnEnemiesMultiple");
    }
}
