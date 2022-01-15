using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level03_Status02_Script : MonoBehaviour
{
    public static bool objective01 = false;
    public static bool objective02 = false;
    public static bool obj12 = false;
    public GameObject coll;
    public GameObject text;

    void Update()
    {
        if (Level03_Status01_Script.enteredthebase == true)
        {
            text.SetActive(true);
        }

        if ((objective01 == true) && (objective02 == true))
        {
            obj12 = true;
            Destroy(coll);
            Destroy(text);
        }
    }
}