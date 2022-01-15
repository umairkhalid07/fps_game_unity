using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level03_Status04_Script : MonoBehaviour
{
    public static bool objective04 = false;
    public static bool objective03p1 = false;
    public static bool objective03p2 = false;
    public static bool obj3p12 = false;
    public GameObject explosions;
    public GameObject pillars;
    public GameObject bridge;
    public GameObject bridge_destroyed;
    public AudioSource SFX;
    public GameObject text1;
    public GameObject text2;
    public GameObject coll;
    public int count = 0;

    void Start()
    {
        explosions.SetActive(false);
        bridge_destroyed.SetActive(false);
    }

    void Update()
    {
        if (level03_Status02_Script.obj12 == true)
        {
            level03_Status02_Script.obj12 = false;
            text1.SetActive(true);
            Destroy(coll);
        }

        if (count == 0)
        {
            if ((objective03p1 == true) && (objective03p2 == true))
            {
                obj3p12 = true;
                count++;
            }
        }

        if (Level03_Status03_Script.obj3p12 == true)
        {
            Level03_Status03_Script.obj3p12 = false;
            StartCoroutine("Wait2");
            StartCoroutine("Wait1");
            SFX.Play();
        }
    }

    IEnumerator Wait1()
    {
        yield return new WaitForSeconds(7);
        explosions.SetActive(true);
        Destroy(bridge);
        Destroy(pillars);
        bridge_destroyed.SetActive(true);
        objective04 = true;
    }

    IEnumerator Wait2()
    {
        text2.SetActive(true);
        Destroy(text1);
        yield return new WaitForSeconds(3);
        text2.SetActive(false);
        Destroy(text2);
    }

}