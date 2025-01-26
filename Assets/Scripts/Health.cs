using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int maxHealth;                           //determines max amount of health the player can have
    public int currentHealth;                       //tracks current health of the player

    public GameObject hp1;
    public GameObject hp2;
    public GameObject hp3;


    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 3;                              
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;                    //lower health
        if (currentHealth == 3)
        {
            hp3.SetActive(false);
        }
        if (currentHealth == 2)
        {
            hp2.SetActive(false);
        }
        if (currentHealth == 1)
        {
            hp1.SetActive(false);
        }
        if (currentHealth <= 0)                     //if health equals zero
        {
            SceneManager.LoadScene("GameOver");     //go to gameover scene
        }
    }
}


