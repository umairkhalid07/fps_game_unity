using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj05_Script : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;
    public GameObject light1;
    public GameObject light2;
    public GameObject light3;
    public GameObject light4;
    public GameObject light5;
    public GameObject light6;
    public GameObject light7;
    public GameObject light8;
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

    void OnTriggerStay ()
    {
        if (count == 0)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                text1.SetActive(false);
                text2.SetActive(true);
                Destroy(light1);
                Destroy(light2);
                Destroy(light3);
                Destroy(light4);
                Destroy(light5);
                Destroy(light6);
                Destroy(light7);
                Destroy(light8);
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
        yield return new WaitForSeconds(3);
        Destroy(text1);
        Destroy(text2);
        Status03_Script.objective05 = true;
    }
}
