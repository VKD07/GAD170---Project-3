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
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

       
    }

    // Update is called once per frame
    void Update()
    {
        selection = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SelectionScript>();

        if (selection != null)
        {

            isSwordManSelected = selection.IsSwordManSelected();

        }

        print(isSwordManSelected);
    }


}
