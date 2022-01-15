using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level02_OBJ05_Script : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public int count;
    public AudioSource SFX;
    
    void Start()
    {
        count = 0;
        text1.SetActive(false);
        text2.SetActive(false);
        text3.SetActive(false);
    }

     void Update()
    {
        if (count == 0)
        {
            if (Level02_Status02_Script.obj4 == true)
            {
                text3.SetActive(true);
            }
        }
    }

    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            text1.SetActive(true);
        }
    }

    void OnTriggerStay ()
    {
        if (count == 0)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                text1.SetActive(false);
                text2.SetActive(true);
                SFX.Play();
                StartCoroutine("Wait1");
            }
        }
    }

    void OnTriggerExit ()
    {
        if (count == 0)
        {
            text1.SetActive(false);
        }
    }

    IEnumerator Wait1()
    {
        count++;
        yield return new WaitForSeconds(2);
        Destroy(text1);
        Destroy(text2);
        SceneManager.LoadScene("InterMission03");
    }
}
