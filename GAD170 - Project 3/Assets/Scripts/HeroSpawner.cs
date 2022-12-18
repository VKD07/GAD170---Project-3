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
        //finding the game object that has game data tag and get the game data script component
        gameData = GameObject.FindGameObjectWithTag("GameData").GetComponent<GameDataScript>();
        //if the sword man is not selected then spawn the archer
        if (gameData.isSwordManSelected == false)
        {
            Instantiate(archer, transform.position, Quaternion.identity);
        }
        else // if the sword man is selected then spawn the sword man
        {
            Instantiate(swordMan, transform.position, Quaternion.identity);
        }
    }
}
