using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject ammo;
    public AudioSource death_sound;
    int health = 100;
    bool alive = true;
    Animator anim;
    
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void ApplyDamage(int damage)
    {
        if (health <= 0)
        {
            return;
        }
        health -= damage;
        if (health <= 0 && alive)
        {
            alive = false;
            anim.SetBool("Dying", true);
            death_sound.Play();
            Invoke("stopanim", 0.1f);
            Instantiate(ammo, transform.position + Vector3.up / 2, transform.rotation);
            GetComponent<EnemyAI>().enabled = false;
            GetComponent<SphereCollider>().enabled = false;
            GetComponent<CapsuleCollider>().enabled = false;
        }
    }
    public void Headshot()
    {
        if (health > 0 && alive)
        {
            health = 0;
            alive = false;
            anim.SetBool("Headshot", true);
            Invoke("stopanim", 0.1f);
            Instantiate(ammo, transform.position + Vector3.up / 2, transform.rotation);
            GetComponent<EnemyAI>().enabled = false;
            GetComponent<SphereCollider>().enabled = false;
            GetComponent<CapsuleCollider>().enabled = false;
        }
    }

    void stopanim()
    {
        anim.SetBool("Dying", false);
        anim.SetBool("Headshot", false);
    }
}
