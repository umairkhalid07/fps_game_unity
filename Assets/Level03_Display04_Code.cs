using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level03_Display04_Code : MonoBehaviour
{
    public static bool objective04 = false;
    public static bool objective05 = false;
    public GameObject explosions;
    public GameObject pillars;
    public GameObject bridge;
    public GameObject bridge_destroyed;
    public AudioSource SFX;
    public GameObject text;
    int check01 = 0;
    int check02 = 0;
    int check03 = 0;

    void Start()
    {
        explosions.SetActive(false);
        bridge_destroyed.SetActive(false);
    }

    void Update()
    {
        if (check01 == 0)
        {
            if ((Level03_Display03_Code.objective03_Part01 == true) && (Level03_Display03_Code.objective03_Part02 == true))
            {
                text.SetActive(true);
                check01++;
                StartCoroutine("Wait1");
            }
        }

        if (check03 == 0)
            if (objective04 == true)
            {
                SFX.Play();
                check03++;
            }

        if (check02 == 0)
        {
            if (objective05 == true)
            {
                Destroy(text);
                check02++;
            }
        }
    }

    IEnumerator Wait1()
    {
        yield return new WaitForSeconds(10);
        explosions.SetActive(true);
        Destroy(bridge);
        Destroy(pillars);
        bridge_destroyed.SetActive(true);
        objective04 = true;
    }
}