using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionScript : MonoBehaviour
{
    [SerializeField] GameObject archer;
    [SerializeField] GameObject swordsMan;

    private bool swordManSelected = true;
    private bool archerSelected = false;



    public void SelectSwordsMan()
    {
        swordsMan.SetActive(true);
        archer.SetActive(false);

        swordManSelected = true;
        archerSelected = false;
    }

    public void SelectArcher()
    {
        swordsMan.SetActive(false);
        archer.SetActive(true);

        swordManSelected = false;
        archerSelected = true;
    }

    public bool IsSwordManSelected()
    {
        return swordManSelected;
    }

    public void SelectHero()
    {
        SceneManager.LoadScene(1);
    }

}
