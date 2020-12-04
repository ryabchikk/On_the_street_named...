using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Поставить врагу тег Enemy
//Скрипт в объект игрока
//Убрать камеру из игрока, обновить скрипт
//Создать слой Terrain и поставить на землю

public class ShootingScript : MonoBehaviour
{
    private LineRenderer LaserLine;
    private AudioSource shootSound;
    private bool isInMinigame = false;
    private void Start()
    {
        LaserLine = GetComponent<LineRenderer>();
        shootSound = GetComponent<AudioSource>();
    }
   
    void Update()
    {
        RaycastHit hit;
        LayerMask mask = LayerMask.GetMask("Terrain");
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, mask);//Каст луча из камеры через курсор чтобы получить точку в мире на которую указывает курсор
        transform.LookAt(hit.point);
        transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);//Исправление вращения. Без этой строчки объект вращается по всем осям, а не тольно по Y
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isInMinigame)
        {
            StartCoroutine(nameof(Shoot));
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        Physics.Raycast(new Ray(gameObject.transform.position+new Vector3(0,-2,0), gameObject.transform.forward), out hit);
        shootSound.Play();
        StartCoroutine("DrawLaser", hit);
        if (hit.collider.tag == "Enemy") 
        {
            
            Destroy(hit.collider.gameObject);
            Debug.Log("popal");
            
        }
    }

    //Для плавности менять цифры в циклах
    //Time.deltaTime вместо константы для того чтобы не зависело от фпс
    //Добавить для луча материал
    IEnumerator DrawLaser(RaycastHit hit)
    {
        LaserLine.SetPosition(0, gameObject.transform.position);
        LaserLine.SetPosition(1, hit.point);

        //Возрастание толщины луча
        while(LaserLine.widthMultiplier < 1)
        {
            LaserLine.SetPosition(0, gameObject.transform.position);
            LaserLine.widthMultiplier += 0.1f;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        //Убывание толщины луча
        while(LaserLine.widthMultiplier > 0)
        {
            LaserLine.SetPosition(0, gameObject.transform.position);
            LaserLine.widthMultiplier -= 0.1f;
            yield return new WaitForSeconds(Time.deltaTime * 0.5f);
        }
    }

    //Вызывать эту функцию через SendMessage когда начинается и кончается мини игра
    //Нужно чтобы заблокировать стрельбу пока игрок находится в мини игре
    //На true вызывается объектом который вызывает мини игру
    //На false вызывается доской
    //Обязательно поставить тег на игрока
    void MinigameState(bool state)
    {
        isInMinigame = state;
    }
}
