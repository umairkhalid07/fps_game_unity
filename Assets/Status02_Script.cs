using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status02_Script : MonoBehaviour
{
    public static bool objective01 = false;
    public static bool objective02 = false;
    public static bool objective03 = false;
    public static bool obj123 = false;
    public GameObject coll;
    public GameObject text;

    void Start()
    {
        
    }

    void Update()
    {
        if (Status01_Script.enteredthebase == true)
        {
            text.SetActive(true);
        }

        if ((objective01 == true) && (objective02 == true) && (objective03 == true))
        {
            obj123 = true;
            Destroy(coll);
            Destroy(text);
        }
    }
}