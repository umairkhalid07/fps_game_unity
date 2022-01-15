using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level03_Status01_Script : MonoBehaviour
{
    public GameObject text;
    public GameObject coll;
    public static bool enteredthebase = false;
    void Start()
    {
        text.SetActive(true);
        enteredthebase = false;
    }

    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            text.SetActive(false);
            enteredthebase = true;
            Destroy(coll);
            Destroy(text);
        }
    }
}
