using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    private Transform enemy;
    public float dist;
    public float radius=10;
    NavMeshAgent nav;
    [SerializeField]
    private bool isHitCooldown = false;
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist > radius)
        {
            nav.enabled = false;
        }
        else 
        {
            nav.enabled = true;
            nav.SetDestination(player.transform.position);
        }
        if (dist < 6 && !isHitCooldown) 
        {
            nav.enabled = false;
            StartCoroutine(nameof(Hit));
        } 
    }
    IEnumerator Hit()
    {
        isHitCooldown = true;
        player.gameObject.SendMessage("AddDamage", 1);
        yield return new WaitForSeconds(5);
        isHitCooldown = false;
    }
}
