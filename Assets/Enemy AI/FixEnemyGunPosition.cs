using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class FixEnemyGunPosition : MonoBehaviour
{
    public Transform gun;
    Animator anim;
    Vector3 pos;
    Quaternion rot;
    
    void Awake()
    {
        anim = GetComponent<Animator>();
        pos = gun.localPosition;
        rot = gun.localRotation;
    }

    void Start()
    {
        gun.localPosition = new Vector3(0.2f, 0.05f, -0.11f);
        gun.localRotation = Quaternion.Euler(3.3f, 74, -90);
    }

    void Update()
    {
        if (anim.GetAnimatorTransitionInfo(0).IsName("Move -> Shoot"))
        {
            gun.localPosition = new Vector3(0.2f, 0.05f, -0.11f);
            gun.localRotation = Quaternion.Euler(3.3f, 74, -90);
        }
        else if (anim.GetAnimatorTransitionInfo(0).IsName("Shoot -> Move"))
        {
            gun.localPosition = pos;
            gun.localRotation = rot;
        }
    }
}
