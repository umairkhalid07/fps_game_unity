using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry01_Script : MonoBehaviour
{
    public void retrylevel01()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void quitgame()
    {
        Application.Quit();
    }
}
