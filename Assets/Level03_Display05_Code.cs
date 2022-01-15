using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level03_Display05_Code : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;
    int check01 = 0;
    int check02 = 0;

    void Start()
    {
        text1.SetActive(false);
        text2.SetActive(false);
    }

    void Update()
    {
        if (check02 == 0)
        {
            if (Level03_Display04_Code.objective05 == true)
            {
                text1.SetActive(true);
                check02++;
            }
        }
    }

    void OnTriggerEnter(Collider player)
    {
        if (Level03_Display04_Code.objective05 == true)
        {
            if (check01 == 0)
            {
                if (player.gameObject.tag == "Player")
                {
                    text2.SetActive(true);
                    StartCoroutine("Wait1");
                }
            }
        }
    }

    IEnumerator Wait1()
    {
        check01++;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("InterMission04");
    }
}