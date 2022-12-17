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
        }
    }

    // Update is called once per frame
    void Update()
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
}
