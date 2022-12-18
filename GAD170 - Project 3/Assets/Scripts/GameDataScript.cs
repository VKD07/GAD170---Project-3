using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataScript : MonoBehaviour
{
    private static GameDataScript instance;
    public SelectionScript selection;
    public bool isSwordManSelected = false;
    private void Awake()
    {
        //unpause the game
        Time.timeScale = 1;
        //if the instance exists then destroy this object
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else // else do not destroy this object
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } 
    }
    void Update()
    {
        //finding main camera that has selection script component
        selection = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SelectionScript>();
        //if selection exists
        if (selection != null)
        {
            //get the bool from selection script
            isSwordManSelected = selection.IsSwordManSelected();
        }
        print(isSwordManSelected);
    }
}
