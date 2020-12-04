using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnActivate : MonoBehaviour
{
    [SerializeField] SpawnerScript[] spawns;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        foreach (var x in spawns)
        {
            x.StartSpawning(5);
        }
        foreach (var x in spawns)
        {
            x.StopSpawning();
        }
    }
}
