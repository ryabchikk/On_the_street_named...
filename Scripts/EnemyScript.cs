using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    private Transform enemy;
    [SerializeField]
    private float aggrDistance;                     //Дистанция агра, выставить в инспекторе
    private bool isTriggered = false;
    [SerializeField]
    private float attackDistance;                   //Дистанция атаки, выставить в инспекторе
    private bool isHitCooldown = false;             //Находится атака на кулдауне или нет
    public float speedEnemy;                        //скорость врага
    void Awake()
    {
        enemy = this.transform;
    }

    void Update()
    {
        if (Vector3.Distance(player.position, enemy.position) < aggrDistance || isTriggered)                //Если игрок подошел на дистанцию агра
            Trigger();
        if (Vector3.Distance(player.position, enemy.position) < attackDistance && !isHitCooldown)
            StartCoroutine(nameof(Hit));
    }

    //Сюда можно прописать другую логику триггера
    void Trigger()
    {
        isTriggered = true;
        enemy.position = Vector3.MoveTowards(enemy.position, player.position, Time.deltaTime* speedEnemy);
        //TODO сделать нормальный поворот
        transform.LookAt(player);
    }

    //TODO Можно сделать задержку перед атакой, например 0.5 секунды чтобы можно было уклониться
    IEnumerator Hit()
    {
        isHitCooldown = true;
        player.gameObject.SendMessage("AddDamage", 1);
        yield return new WaitForSeconds(5);
        isHitCooldown = false;
    }
}

