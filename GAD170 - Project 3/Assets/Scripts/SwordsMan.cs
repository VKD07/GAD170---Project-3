using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class SwordsMan : MonoBehaviour
{
    [SerializeField] int swordDamage = 50;
    [SerializeField] GameObject blood;
    bool particleSystemPlayed = false;
    bool shieldActive = false;
    Animator animator;
    EnemyScript enemy;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        //handles the attacking and blocking function of the character
        AttackBlock();
    }
    public void AttackEnemy()
    {
        //reduce the health of the enemy and particles is played
        enemy.ReduceHealth(swordDamage);
        particleSystemPlayed = true;
        Instantiate(blood, enemy.transform.position, Quaternion.identity);
    }
    private void AttackBlock()
    {
        //plays animations with using mouse buttons
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetTrigger("Attack");
        }
        else if (Input.GetKey(KeyCode.Mouse1))
        {
            //activating shield
            shieldActive = true;
            animator.SetBool("Shield", true);
        }
        else
        {
            shieldActive = false;
            animator.SetBool("Shield", false);
        }
    }
    //getter functions
    public bool IsShieldActivated()
    {
        return shieldActive;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            enemy = other.GetComponent<EnemyScript>();
        }
    }
}
