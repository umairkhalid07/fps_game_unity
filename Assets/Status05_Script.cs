using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Status05_Script : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;
    
    void Update()
    {
        if (Status04_Script.obj678 == true)
        {
            text1.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            StartCoroutine("Wait1");
        }
    }

    IEnumerator Wait1()
    {
        text2.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("InterMission02");
    }
}
