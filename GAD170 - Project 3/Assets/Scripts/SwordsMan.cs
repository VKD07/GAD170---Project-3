using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordsMan : MonoBehaviour
{
    [SerializeField] int swordDamage = 50;

    Animator animator;
    Collider collider;
    bool isAttacking = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        AttackBlock();
    }

    private void AttackEnemy()
    {
        if(isAttacking == true && collider != null)
        {
            collider.GetComponent<EnemyScript>().ReduceHealth(swordDamage);
        }   
    }

    private void AttackBlock()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetTrigger("Attack");
            isAttacking = true;
        }
        else if (Input.GetKey(KeyCode.Mouse1))
        {
            isAttacking=false;
            animator.SetBool("Shield", true);
        }
        else
        {
            animator.SetBool("Shield", false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            collider = other;
        }
    }
}
