using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void RestartGameplay()
    {
        //loading scene 0
        SceneManager.LoadScene(0);
    }
}
