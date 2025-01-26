using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 3;

    public SpriteRenderer playerSr;
    public PlayerMovement playerMovement;

    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if(health <= 0)
        {
            playerMovement.dead = true;
            playerMovement.isGrowing = false;
            playerMovement.isJumping = false;
            playerMovement.isIdle = false;
            playerMovement.isWalking = false;
            //playerMovement.enabled = false;
            //SceneManager.LoadScene(1);
        }
        Debug.Log("huh");

    }
}