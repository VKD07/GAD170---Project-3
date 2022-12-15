using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordsMan : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerAttackAndBlock();
    }

    private void PlayerAttackAndBlock()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetTrigger("Attack");
        }
        else if (Input.GetKey(KeyCode.Mouse1))
        {
            animator.SetBool("Shield", true);
        }
        else
        {
            animator.SetBool("Shield", false);
        }
    }
}
