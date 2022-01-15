using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level03_Display03_Code : MonoBehaviour
{
    public GameObject collider;
    public GameObject text;
    int check01 = 0;
    int check02 = 0;
    public static bool objective03_Part01 = false;
    public static bool objective03_Part02 = false;

    void Update()
    {
        if (check01 == 0)
        {
            if (Level03_Display02_Code.objective01 == true && Level03_Display02_Code.objective02 == true)
            {
                text.SetActive(true);
                check01++;
                Destroy(collider);
            }
        }

        if (check02 == 0)
        {
            if ((objective03_Part01 == true) && (objective03_Part02 == true))
            {
                Destroy(text);
                check02++;
            }
        }
    }
}