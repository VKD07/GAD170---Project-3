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
        //disabling the game objects
        swordsMan.SetActive(true);
        archer.SetActive(false);
        swordManSelected = true;
        archerSelected = false;
    }
    public void SelectArcher()
    {
        //disabling the game objects
        swordsMan.SetActive(false);
        archer.SetActive(true);
        swordManSelected = false;
        archerSelected = true;
    }
    //returning a bool of sword man selected
    public bool IsSwordManSelected()
    {
        return swordManSelected;
    }
    //once the button is pressed the scene will load to scene 1
    public void SelectHero()
    {
        SceneManager.LoadScene(1);
    }
}
