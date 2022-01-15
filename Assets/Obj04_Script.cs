using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj04_Script : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;
    public int count;
    public AudioSource SFX;
    
    void Start()
    {
        count = 0;
        text1.SetActive(false);
        text2.SetActive(false);
    }

    void OnTriggerEnter(Collider player)
    {
        if (count == 0)
        {
            if (player.gameObject.tag == "Player")
            {
                text1.SetActive(true);
            }
        }
    }

    void OnTriggerStay()
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

    void OnTriggerExit()
    {
        if (count == 0)
        {
            text1.SetActive(false);
        }
    }

    IEnumerator Wait1()
    {
        count++;
        yield return new WaitForSeconds(3);
        Destroy(text1);
        Destroy(text2);
        Status03_Script.objective04 = true;
    }
}
