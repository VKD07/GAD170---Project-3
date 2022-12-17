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

        if (enemyScript != null)
        {
            slider.value = enemyScript.EnemyHealth();
        }else if(thisIsAPlayer == true)
        {
            playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
            slider.value = playerScript.PlayerHealth();
            playerScript.deathEvent += DisableUI;
        }
    }

    // Update is called once per frame
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
        playerScript.deathEvent -= DisableUI;
        this.gameObject.SetActive(false);
    }
}
