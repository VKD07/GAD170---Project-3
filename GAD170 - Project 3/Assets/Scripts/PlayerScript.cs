using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    [Header("Player Stats")]
    [SerializeField] int playerHealth = 100;

    [Header("Player Movement")]
    [SerializeField] float walkSpeed = 2f;
    [SerializeField] float runSpeed = 4f;
    public float playerSpeed;

    [Header("Sound Effects")]
    [SerializeField] AudioClip walkSound;
    [SerializeField] AudioClip swordSwingSound;
    AudioSource audioSource;


    //Player Components
    Animator animator;

    //events and delegates
    public delegate void DamagePowerUpDelegate();
    public DamagePowerUpDelegate damagePowerUpEvent;

    public delegate void DeathDelegate();
    public DeathDelegate deathEvent;
 


    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        PlayerMovement();
        PlayerRotation();
        DeathHandler();
        print("Player Health: " +playerHealth);
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

    private void DeathHandler()
    {
        if(playerHealth <= 0)
        {
            deathEvent();
            Time.timeScale = 0;
        }
    
    }

    //Setter Function
    public void ReducePlayerHealth(int zombieDamage)
    {
        playerHealth -= zombieDamage;
    }

    public void AddPlayerHealth(int health)
    {
        playerHealth += health;
    }

    public void SetPlayerHealth(int health)
    {
        playerHealth = health;
    }

    //Getter function

    public int PlayerHealth()
    {
        return playerHealth;
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "DamagePowerUp")
        {
            damagePowerUpEvent();
            Destroy(other.gameObject);
        }
    }

    //Sound Effects
    public void PlayFootSound()
    {
        audioSource.PlayOneShot(walkSound);
    }

    public void PlaySwingSword()
    {
        audioSource.PlayOneShot(swordSwingSound);
    }

}
