using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level03_Display01_Code : MonoBehaviour
{
    public GameObject text;
    public GameObject collider;
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
            Destroy(collider);
            Destroy(text);
        }
    }
}
