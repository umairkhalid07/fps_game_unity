using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level03_OBJ05_Script : MonoBehaviour
{
    public GameObject vehicles;
    public GameObject soldiers;
    public GameObject convoy_object;
    public float speed = 13;
    public static bool arrived = false;
    int check01 = 0;
    int check02 = 0;
    public Vector3 targetPosition = new Vector3(570,24,763);
    public Vector3 currentPosition; 

    void Start()
    {
        soldiers.SetActive(false);
    }

    void Update()
    {
        if (check01 == 0)
        {
            if (Level03_Display03_Code.objective03_Part01 == true && Level03_Display03_Code.objective03_Part02 == true)
            {
                MoveTowardsTarget();
            }
        }

        if (arrived == false)
        {
            currentPosition = convoy_object.transform.position;
            if (currentPosition == targetPosition || convoy_object.transform.position.x < 570)
            {
                check01++;
                arrived = true;
                soldiers.SetActive(true);
            }
        }
    }

    public void MoveTowardsTarget()
    {
        currentPosition = convoy_object.transform.position;
        Vector3 directionOfTravel = targetPosition - currentPosition;
        directionOfTravel.Normalize();
        convoy_object.transform.Translate((directionOfTravel.x * speed * Time.deltaTime),(directionOfTravel.y * speed * Time.deltaTime),(directionOfTravel.z * speed * Time.deltaTime),Space.World);
    }
}
