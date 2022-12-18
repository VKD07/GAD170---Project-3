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
    float playerSpeed;

    [Header("Sound Effects")]
    [SerializeField] AudioClip walkSound;
    [SerializeField] AudioClip swordSwingSound;
    [SerializeField] AudioClip bowSound;
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
        //getting the horizontal and vertical axis
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");
        //player position
        Vector3 playerPos = new Vector3(horizontalAxis, 0f, verticalAxis) * playerSpeed * Time.deltaTime;
        //changing the player position
        transform.position += playerPos;
        //if the player y position is less than 0 then set it to 0
        if(transform.position.y < 0)
        {
            transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
        }
        //Player movement using button keys and playing animations
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S))
        {
            playerSpeed = walkSpeed;
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
        // player Sprinting
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
        // if player press D then character looks right
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.rotation = Quaternion.LookRotation(Vector3.right);
        }
        // if player press A then character looks left
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.rotation = Quaternion.LookRotation(Vector3.left);
        }
        //If player press W then character looks forward direction
        else if (Input.GetKeyDown(KeyCode.W))
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward);
        }
        //IF player press S then character looks Back
        else if (Input.GetKeyDown(KeyCode.S))
        {
            transform.rotation = Quaternion.LookRotation(Vector3.back);
        }
    }
    //calls if character dies
    private void DeathHandler()
    {
        if(playerHealth <= 0)
        {
            //trigger death event
            deathEvent();
            //pause the game
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
        //if collider with a power up then trigger damage power up event and destroy that object
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
    public void PlayBowSound()
    {
        audioSource.PlayOneShot(bowSound);
    }
}
