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

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
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
