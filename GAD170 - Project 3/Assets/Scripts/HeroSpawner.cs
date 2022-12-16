using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSpawner : MonoBehaviour
{
    [SerializeField] GameObject archer;
    [SerializeField] GameObject swordMan;

    public GameDataScript gameData;

    void Start()
    {
        gameData = GameObject.FindGameObjectWithTag("GameData").GetComponent<GameDataScript>();

        if (gameData.isSwordManSelected == false)
        {
            Instantiate(archer, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(swordMan, transform.position, Quaternion.identity);
        }
    }

   
}
