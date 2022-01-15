using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level03_OBJ01_Script : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;
    public GameObject c4;
    int check01;
    public AudioSource SFX;
    
    void Start()
    {
        check01 = 0;
        text1.SetActive(false);
        text2.SetActive(false);
    }

    void OnTriggerEnter(Collider player)
    {
        if (check01 == 0)
        {
            if (player.gameObject.tag == "Player")
            {
                text1.SetActive(true);
            }
        }
    }

    void OnTriggerStay()
    {
        if (check01 == 0)
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
        if (check01 == 0)
        {
            text1.SetActive(false);
        }
    }

    IEnumerator Wait1()
    {
        check01++;
        yield return new WaitForSeconds(3);
        Destroy(text1);
        Destroy(text2);
        c4.SetActive(false);
        Level03_Display02_Code.objective01 = true;
    }
}
