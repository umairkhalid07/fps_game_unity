using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterMission04_Script : MonoBehaviour
{
    public void return_to_main()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
