using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status04_Script : MonoBehaviour
{
    public static bool objective06 = false;
    public static bool objective07 = false;
    public static bool objective08 = false;
    public static bool obj678 = false;
    public GameObject coll;
    public GameObject text;

    void Start()
    {
        
    }

    void Update()
    {
        if (Status03_Script.obj45 == true)
        {
            text.SetActive(true);
        }

        if ((objective06 == true) && (objective07 == true) && (objective08 == true))
        {
            obj678 = true;
            Destroy(coll);
            Destroy(text);
        }
    }
}
