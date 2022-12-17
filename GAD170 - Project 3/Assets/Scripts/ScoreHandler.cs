using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreValue;
    int TotalScore = 0;

    void Start()
    {
        scoreValue.SetText(TotalScore.ToString("000000"));
    }

    // Update is called once per frame
    void Update()
    {
        scoreValue.SetText(TotalScore.ToString("000000"));
    }

    //setterMethod
    public void setScore(int score)
    {
        TotalScore += score;
    }
}
