using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;

   
    void Start()
    {
        
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            float randomDelayTime = UnityEngine.Random.Range(2, 6);

            Instantiate(enemy, transform.position, Quaternion.identity);
            
            yield return new WaitForSeconds(randomDelayTime);
        }
    }

  
}
