using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("InterMission01");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
