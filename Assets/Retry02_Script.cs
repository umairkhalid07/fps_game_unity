using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry02_Script : MonoBehaviour
{
    public void retrylevel02()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void quitgame()
    {
        Application.Quit();
    }
}
