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
    bool ifSubscribed = false;
    public ScoreHandler scoreHandler;
    GameObject player;
    Animator animator;

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
        //if the function is subscribed then dont subscribed again
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
        //keep moving towards the player with a certain speed and keep looking at the player
        float enemySteps = enemySpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, enemySteps);
        transform.LookAt(player.transform.position);
    }
    private void Attack()
    {
        //calculates the distance between player and this enemy
        float DistanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        //if the enemy is close then play attack animation
        if (DistanceToPlayer <= attackDistance)
        {
            animator.SetTrigger("Attack");
        }
    }
    private void DamagePlayer()
    {
        //if the shield is not active and the swords componenet exist then reduce the player health
        if (player.GetComponent<SwordsMan>() != null && player.GetComponent<SwordsMan>().IsShieldActivated() == false || player.GetComponent<ArcherScript>() != null)
        {
            player.GetComponent<PlayerScript>().ReducePlayerHealth(enemyDamage);
        }
    }
    private void DeathHandler()
    {
        //if enemy health is less than 0
        if (enemyHealth <= 0)
        {
            //if score is already added then dont add again
            if (scoreAdded == false)
            {
                scoreAdded = true;
                scoreHandler.setScore((int)scorePerKill);
            }
            //play death animation
            animator.SetTrigger("Death");
            enemySpeed = 0;
            transform.rotation = Quaternion.identity;
            //if the item is not dropped yet drop an item
            if (ifItemDropped == false)
            {
                ifItemDropped = true;
                DropAnItem();
            }
            //then destroy this object
            Destroy(this.gameObject, 4.5f);
        }
    }
    private void DropAnItem()
    {
        //random index for random items
        int randomIndex = UnityEngine.Random.Range(0, droppableItems.Length);
        //if droppable item slot in arrays is not empty then drop that item
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

