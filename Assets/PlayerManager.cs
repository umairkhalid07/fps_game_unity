using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class PlayerManager : MonoBehaviour
{
    public int Maxhealth = 100;
    public Transform Player;
    public int currentHealth;
    public HealthBar bar;

    void Start()
    {
        bar.SetMaxHealth(Maxhealth);
        currentHealth = Maxhealth;
    }

    public void ApplyDamage()
    {
        if (currentHealth <= 0)
        {
            return;
        }
        currentHealth -= 5;
        bar.SetHealth(currentHealth);
        
        if (currentHealth <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
