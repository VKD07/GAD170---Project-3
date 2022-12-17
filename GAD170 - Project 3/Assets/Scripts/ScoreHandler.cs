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
        scoreValue.SetText(TotalScore.ToString("000000"));
        playerScript = FindObjectOfType<PlayerScript>();
        playerScript.deathEvent += DisableUI;
    }

    // Update is called once per frame
    void Update()
    {
        scoreValue.SetText(TotalScore.ToString("000000"));
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
        playerScript.deathEvent -= DisableUI;
     
       deathScreenUI.SetActive(true);
       this.gameObject.SetActive(false);

    }

}
