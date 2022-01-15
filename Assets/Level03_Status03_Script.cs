using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level03_Status03_Script : MonoBehaviour
{
    public static bool objective03p1 = false;
    public static bool objective03p2 = false;
    public static bool obj3p12 = false;
    public GameObject text1;
    public GameObject text2;
    public GameObject coll;

    void Update()
    {
        if (level03_Status02_Script.obj12 == true)
        {
            level03_Status02_Script.obj12 = false;
            text1.SetActive(true);
            StartCoroutine("Wait1");
        }

        if ((objective03p1 == true) && (objective03p2 == true))
        {
            obj3p12 = true;
        }
    }

    IEnumerator Wait1()
    {
        text2.SetActive(true);
        text1.SetActive(false);
        yield return new WaitForSeconds(3);
        text2.SetActive(false);
        Destroy(text2);
        Destroy(coll);
    }
}