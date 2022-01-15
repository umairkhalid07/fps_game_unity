using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry03_Script : MonoBehaviour
{
    public void retrylevel03()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void quitgame()
    {
        Application.Quit();
    }
}
