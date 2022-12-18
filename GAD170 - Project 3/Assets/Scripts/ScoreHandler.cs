using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreValue;
    [SerializeField] TextMeshProUGUI deathScreenScore;
    [SerializeField] GameObject deathScreenUI;
    PlayerScript playerScript;
    int TotalScore = 0;
    void Start()
    {
        //setting score value text
        scoreValue.SetText(TotalScore.ToString("000000"));
        playerScript = FindObjectOfType<PlayerScript>();
        playerScript.deathEvent += DisableUI;
    }
    void Update()
    {
        //updating score value text
        scoreValue.SetText(TotalScore.ToString("000000"));
        //if death score exist then set the death screen score text
        if (deathScreenScore != null)
        {
            deathScreenScore.SetText(TotalScore.ToString("000000"));
        }
    }
    //setterMethod
    public void setScore(int score)
    {
        TotalScore += score;
    }
    public void DisableUI()
    {
        //unsubscribing to the event of player script
       playerScript.deathEvent -= DisableUI;
        //Disabling the game objects
       deathScreenUI.SetActive(true);
       this.gameObject.SetActive(false);
    }
}
