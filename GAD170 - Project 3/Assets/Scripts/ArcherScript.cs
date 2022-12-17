using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherScript : MonoBehaviour
{
    [SerializeField] Transform arrowSpawner;
    [SerializeField] GameObject arrow;
    [SerializeField] float arrowSpeed;

    Animator animator;

    ArrowScript arrowScript;   
   


    void Start()
    {
        animator = GetComponent<Animator>();
    
    }
    void Update()
    {
        if (arrowScript != null)
        {
            arrowScript = GameObject.FindGameObjectWithTag("Arrow").GetComponent<ArrowScript>();
        }
        Attack();
       
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetTrigger("Attack");
            GameObject arrows = Instantiate(arrow, arrowSpawner.position, Quaternion.identity);
            arrows.GetComponent<Rigidbody>().velocity = transform.forward * arrowSpeed;
        }
    }
}
