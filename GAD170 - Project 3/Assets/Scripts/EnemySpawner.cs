using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject [] enemies;
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }
    IEnumerator SpawnEnemies()
    {
        while (true) // while true then loop through the game object of array enemies and spawn the enemies with in different spawn times
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                float randomDelayTime = UnityEngine.Random.Range(6, 20);

                Instantiate(enemies[i], transform.position, Quaternion.identity);

                yield return new WaitForSeconds(randomDelayTime); 
            }
        }
    }
}
