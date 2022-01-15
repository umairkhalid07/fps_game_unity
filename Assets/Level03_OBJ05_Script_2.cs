using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level03_OBJ05_Script_2 : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;
    int check01 = 0;
    public AudioSource SFX;
    
    void Start()
    {
        text1.SetActive(false);
        text2.SetActive(false);
    }

    void OnTriggerEnter(Collider player)
    {
        if (check01 == 0)
        {
            if (Level03_OBJ05_Script.arrived == true)
            {
                if (player.gameObject.tag == "Player")
                {
                    text1.SetActive(true);
                }
            }
        }
    }

    void OnTriggerStay()
    {
        if (check01 == 0)
        {
            if (Level03_OBJ05_Script.arrived == true)
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
    }

    void OnTriggerExit()
    {
        if (check01 == 0)
        {
            if (Level03_OBJ05_Script.arrived == true)
            {
                text1.SetActive(false);
            }
        }
    }

    IEnumerator Wait1()
    {
        check01++;
        yield return new WaitForSeconds(3);
        Destroy(text1);
        Destroy(text2);
        Level03_Display04_Code.objective05 = true;
    }
}
