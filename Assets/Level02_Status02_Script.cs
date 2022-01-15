using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level02_Status02_Script : MonoBehaviour
{
    public static bool objective04 = false;
    public static bool obj4 = false;
    public GameObject coll;
    public GameObject text;

    void Update()
    {
        if (Level02_Status01_Script.obj123 == true)
        {
            text.SetActive(true);
        }
        if ((objective04 == true))
        {
            obj4 = true;
            text.SetActive(false);
            Destroy(coll);
            Destroy(text);
        }
    }
}