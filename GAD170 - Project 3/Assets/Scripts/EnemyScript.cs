using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] int enemyHealth = 100;
    [SerializeField] int enemyDamage = 10;
    [SerializeField] float enemySpeed = 2f;
    [SerializeField] float attackDistance = 2f;

    public GameObject player;
    Animator animator;
    bool attackPlayer = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyMovement();
        Attack();
        DeathHandler();
    }
    private void enemyMovement()
    {
        float enemySteps = enemySpeed * Time.deltaTime;
        Vector3 stoppingDistance = player.transform.position - Vector3.one;
        transform.position = Vector3.MoveTowards(transform.position, stoppingDistance, enemySteps);
        transform.LookAt(player.transform.position);
    }
    private void Attack()
    {
        float DistanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if(DistanceToPlayer <= attackDistance)
        {
            attackPlayer = true;
            animator.SetTrigger("Attack");
        }
    }

    private void DamagePlayer()
    {
        player.GetComponent<PlayerScript>().ReducePlayerHealth(enemyDamage);
    }

    private void DeathHandler()
    {
        if(enemyHealth <= 0)
        {
            animator.SetTrigger("Death");
            enemySpeed = 0;
            Destroy(this.gameObject, 4f);
        }
    }

    //Getter methods
    public void ReduceHealth(int damage)
    {
        enemyHealth -= damage;
    }
}
