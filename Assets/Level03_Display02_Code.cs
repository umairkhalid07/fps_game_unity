using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level03_Display02_Code : MonoBehaviour
{
    public static bool objective01 = false;
    public static bool objective02 = false;
    public GameObject collider;
    public GameObject text;
    int check01 = 0;
    int check02 = 0;

    void Update()
    {
        if (check01 == 0)
        {
            if (Level03_Display01_Code.enteredthebase == true)
            {
                text.SetActive(true);
                check01++;
            }
        }

        if (check02 == 0)
        {
            if ((objective01 == true) && (objective02 == true))
            {
                Destroy(collider);
                Destroy(text);
                check02++;
            }
        }
    }
}