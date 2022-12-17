using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int additionalHealthValue = 10;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerScript player = other.GetComponent<PlayerScript>();
           
            if(player.PlayerHealth() < 100)
            {
                player.AddPlayerHealth(additionalHealthValue);
                Destroy(gameObject);
            }
            else if (player.PlayerHealth() + additionalHealthValue > 100)
            {
                player.SetPlayerHealth(100);
                Destroy(gameObject);
            }

           
        }
    }
}
