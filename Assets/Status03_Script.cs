using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status03_Script : MonoBehaviour
{
    public static bool objective04 = false;
    public static bool objective05 = false;
    public static bool obj45 = false;
    public GameObject coll;
    public GameObject text;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (Status02_Script.obj123 == true)
        {
            text.SetActive(true);
        }

        if ((objective04 == true) && (objective05 == true))
        {
            obj45 = true;
            text.SetActive(false);
            Destroy(coll);
            Destroy(text);
        }
    }
}
