using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] float movementSpeed = 2f;
    [SerializeField] float rollSpeed = 10f;
    public float playerSpeed;

    //Player Components
    [SerializeField] Animator animator;

    void Start()
    {
       
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

        playerSpeed = movementSpeed;

        Vector3 playerPos = new Vector3(horizontalAxis, 0f, verticalAxis) * playerSpeed * Time.deltaTime;

        transform.position += playerPos;

        print(playerPos);

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S))
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }

        //roll
        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetTrigger("Roll");
          
        }

    }

    private void PlayerRotation()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.rotation = Quaternion.LookRotation(Vector3.right);
        }
        else if(Input.GetKeyDown(KeyCode.A))
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
