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

    Animator animator;
    bool shieldActive = false;

    EnemyScript enemy;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        AttackBlock();
    }

    public void AttackEnemy()
    {
        
        enemy.ReduceHealth(swordDamage);

     
            particleSystemPlayed = true;
            Instantiate(blood, enemy.transform.position, Quaternion.identity);
      

    }

    private void AttackBlock()
    {
  
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetTrigger("Attack");
        }
        else if (Input.GetKey(KeyCode.Mouse1))
        {
            shieldActive = true;
            animator.SetBool("Shield", true);
        }
        else
        {
            shieldActive = false;
            animator.SetBool("Shield", false);
        }

     
    }

    //getter

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
