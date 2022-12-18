using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] EnemyScript enemyScript;
    [SerializeField] bool thisIsAPlayer;
    [SerializeField] PlayerScript playerScript;
    void Start()
    {
        // if enemy script exists then set the slider value
        if (enemyScript != null)
        {
            slider.value = enemyScript.EnemyHealth();
        }else if(thisIsAPlayer == true) // if the script is being used by player then trigger this
        {
            playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
            slider.value = playerScript.PlayerHealth();
            playerScript.deathEvent += DisableUI;
        }
    }
    void Update()
    {
        SettingHealthBar();
    }
    private void SettingHealthBar()
    {
        if (enemyScript != null)
        {
            slider.value = enemyScript.EnemyHealth();
        }
        else if (thisIsAPlayer == true)
        {
            slider.value = playerScript.PlayerHealth();
        }
    }
    public void DisableUI()
    {
        //unsubscribing to the player script death event
        playerScript.deathEvent -= DisableUI;
        this.gameObject.SetActive(false);
    }
}
