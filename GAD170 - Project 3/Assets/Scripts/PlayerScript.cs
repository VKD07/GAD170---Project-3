using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] float walkSpeed = 2f;
    [SerializeField] float runSpeed = 4f;
    public float playerSpeed;

    //Player Components
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        PlayerMovement();
        PlayerRotation();
    }
    private void PlayerMovement()
    {
        //Player Walk
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");


        Vector3 playerPos = new Vector3(horizontalAxis, 0f, verticalAxis) * playerSpeed * Time.deltaTime;

        transform.position += playerPos;

        if(transform.position.y < 0)
        {
            transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
        }

        print(playerPos);

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S))
        {
            playerSpeed = walkSpeed;
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }

        //Sprinting
        if (Input.GetKey(KeyCode.LeftShift) && animator.GetBool("IsWalking") == true)
        {
            animator.SetBool("IsWalking", false);
            animator.SetBool("Run", true);
            playerSpeed = runSpeed;
        }
        else
        {
            animator.SetBool("Run", false);
        }
    }

    private void PlayerRotation()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.rotation = Quaternion.LookRotation(Vector3.right);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.rotation = Quaternion.LookRotation(Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            transform.rotation = Quaternion.LookRotation(Vector3.back);
        }
    }
   
}
