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
        while (true)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                float randomDelayTime = UnityEngine.Random.Range(15, 25);

                Instantiate(enemies[i], transform.position, Quaternion.identity);

                yield return new WaitForSeconds(randomDelayTime);
  
            }
           
        }
    }

  
}
