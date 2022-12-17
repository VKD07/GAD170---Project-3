using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] int enemyHealth = 100;
    [SerializeField] int enemyDamage = 10;
    [SerializeField] float enemySpeed = 2f;
    [SerializeField] float attackDistance = 3f;
    [SerializeField] float scorePerKill = 100f;

    bool scoreAdded = false;
    public ScoreHandler scoreHandler;
    GameObject player;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
      
    }

    // Update is called once per frame
    void Update()
    {
        scoreHandler = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreHandler>();
        player = GameObject.FindGameObjectWithTag("Player");
        enemyMovement();
        Attack();
        DeathHandler();
    }
    private void enemyMovement()
    {
        float enemySteps = enemySpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, enemySteps);
        transform.LookAt(player.transform.position);
    }
    private void Attack()
    {
        float DistanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if(DistanceToPlayer <= attackDistance)
        {
            animator.SetTrigger("Attack");
        }
    }

    private void DamagePlayer()
    {
        if (player.GetComponent<SwordsMan>() != null && player.GetComponent<SwordsMan>().IsShieldActivated() == false || player.GetComponent<ArcherScript>() != null)
        {
            player.GetComponent<PlayerScript>().ReducePlayerHealth(enemyDamage);
        }
    }

    private void DeathHandler()
    {
        if(enemyHealth == 0)
        {
            if (scoreAdded == false)
            {
                scoreAdded = true;
                scoreHandler.setScore((int)scorePerKill);
            }

            animator.SetTrigger("Death");
            enemySpeed = 0;
            transform.rotation = Quaternion.identity;  
            Destroy(this.gameObject, 4f);
        }
    }

    //Getter methods
    public void ReduceHealth(int damage)
    {
        enemyHealth -= damage;
    }

    public int EnemyHealth()
    {
        return enemyHealth;
    }


}
