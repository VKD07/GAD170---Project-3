using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] int enemyHealth = 100;
    [SerializeField] int enemyDamage = 10;
    [SerializeField] float enemySpeed = 2f;
    [SerializeField] float attackDistance = 3f;
    [SerializeField] float scorePerKill = 100f;

    [Header("Droppable Items")]
    [SerializeField] GameObject[] droppableItems;
    bool ifItemDropped = false;

    [Header("Sound Effects")]
    [SerializeField] AudioClip heavyDeath;
    [SerializeField] AudioClip normalDeath;
    AudioSource audioSource;

    bool scoreAdded = false;
    public ScoreHandler scoreHandler;
    GameObject player;
    Animator animator;
    bool ifSubscribed = false;



    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreHandler = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreHandler>();
        player = GameObject.FindGameObjectWithTag("Player");

        if (ifSubscribed == false)
        {
            ifSubscribed = true;
            player.GetComponent<PlayerScript>().damagePowerUpEvent += DamageHealth;
        }

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

        if (DistanceToPlayer <= attackDistance)
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
        if (enemyHealth <= 0)
        {
            if (scoreAdded == false)
            {
                scoreAdded = true;
                scoreHandler.setScore((int)scorePerKill);
            }
            animator.SetTrigger("Death");
            enemySpeed = 0;
            transform.rotation = Quaternion.identity;

            if (ifItemDropped == false)
            {
                ifItemDropped = true;
                DropAnItem();
            }

            Destroy(this.gameObject, 4.5f);
        }
    }

    private void DropAnItem()
    {
        int randomIndex = UnityEngine.Random.Range(0, droppableItems.Length);

        if (droppableItems[randomIndex] != null)
        {
            Instantiate(droppableItems[randomIndex], transform.position + Vector3.one, Quaternion.identity);
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

    void DamageHealth()
    {
        enemyHealth /= 2;
    }

    //Sound Effects Events
    
    public void PlayHeavyDeath()
    {
        audioSource.PlayOneShot(heavyDeath);
    }

    public void PlayNormalDeath()
    {
        audioSource.PlayOneShot(normalDeath);
    }
}

