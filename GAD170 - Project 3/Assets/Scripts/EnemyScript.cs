using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] float enemySpeed = 2f;
    public Transform playerPosition;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        enemyMovement();
    }

    private void enemyMovement()
    {
        float enemySteps = enemySpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, playerPosition.position, enemySteps);
    }
}
