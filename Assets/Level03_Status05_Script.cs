using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level03_Status05_Script : MonoBehaviour
{
    public GameObject coll;
    public GameObject text1;
    public GameObject text2;
    public int count = 0;
    public static bool objective05 = false;

    void OnTriggerEnter(Collider player)
    {
        if (objective05 == true)
        {
            if (count == 0)
            {
                if (player.gameObject.tag == "Player")
                {
                    text1.SetActive(true);
                    StartCoroutine("Wait1");
                }
            }
        }
    }

    IEnumerator Wait1()
    {
        count++;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("InterMission04");
    }
}