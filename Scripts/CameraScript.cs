using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//HOW TO:
//Подключить скрипт к камере
//В target объект игрока в инспекторе
//Настроить камеру в редакторе на нужню позицию

public class CameraScript : MonoBehaviour
{
    public Transform target;
    Vector3 pos;
    void Start()
    {
        //transform.LookAt(target);                                //Если нужно направить камеру на игрока разкомментировать эту строчку, иначе убрать
        pos = transform.position - target.position;
    }

    void LateUpdate()
    {
        transform.position = target.position + pos;
    }
}

